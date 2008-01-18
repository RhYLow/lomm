using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace LOTROMusicManager
{
    // Delegate to defer reading the cursor location until after the text box has moved it.
    // Otherwise we get the change notification during the key or mouse processing and we're
    // one location behine. We use this delegate to push over to a thread to make the check.
    // Basically, the thread waits on the UI message queue via InvokeRequired/Invoke
    public delegate void UpdateCursorLocationDel(Object state);

    public partial class FormMain: Form
    {
    #region Properties and types
        //private String          _strFileNameShowing;
        protected int             _nSelectedFile = -1;
        protected ColumnSorter    _sorter = new ColumnSorter();
        
        private   enum PlayTypes {Immediate, Sync}
        private   enum KeepFocus {LOMM, LOTRO}
        protected static Regex HEADER_REGEX = new Regex("^[ \t]*([^ \t]:|%)", RegexOptions.ExplicitCapture | RegexOptions.Compiled);

        private bool IsCommand(String s) {return s.Trim()[0] == '/';}

        protected ABCRef _abcref = new ABCRef();
    #endregion

    #region Form methods
        public FormMain()
        {//====================================================================
            InitializeComponent();
            dlgSaveAs.InitialDirectory   = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Properties.Settings.Default.MusicSubfolder;
            dlgOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Properties.Settings.Default.MusicSubfolder;
            return;
        }

        private void OnLoad(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            ReloadFileList();
            ShowSelectedFile();
            InsertMenuItems(Properties.Settings.Default.Dances,     mniDances,    OnEmote);
            InsertMenuItems(Properties.Settings.Default.Emotes,     mniEmotes,    OnEmote);
            InsertMenuItems(Properties.Settings.Default.Moods,      mniMoods,     OnEmote);
            InsertMenuItems(Properties.Settings.Default.Bestowals,  mniBestowals, OnEmote);

            mniOpacity.SelectedIndex = (int)(10*(1-Opacity));
            //TODO: Get EditorFontSize menu an initial value 

            // Auto-binding size or AOT causes all sorts of mess 
            Size = (Size)Properties.Settings.Default.WindowSize;
            TopMost = Properties.Settings.Default.AOT;
            Location = (Point)Properties.Settings.Default.WindowLocation;

            // Simulate a click on the "Title" column. Much more useful than starting with
            // the filename sorted.
            ColumnClickEventArgs eClick = new ColumnClickEventArgs(0);
            OnColumnClick(new object(), eClick);

            // Default to immediate play
            btnPlay.Tag  = PlayTypes.Immediate;
            btnPlay.Text = mniDDPlay.Text;

            return;
        }                           

        private void OnClosing(object sender, FormClosingEventArgs e)
        {//--------------------------------------------------------------------
            Properties.Settings.Default.WindowLocation = Location;
            Properties.Settings.Default.WindowSize = Size;
            Properties.Settings.Default.AOT = TopMost;
            Properties.Settings.Default.Save();
            return;
        }

        private void OnQuickReference(object sender, EventArgs e)
        {//====================================================================
            _abcref.Show();
            _abcref.WindowState = FormWindowState.Normal;
            _abcref.Visible = true;
            return;
        }

        private void OnHelpAbout(object sender, EventArgs e)
        {//====================================================================
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
            return;
        }

        private void OnExit(object sender, EventArgs e)
        {//====================================================================
            _abcref.Close();
            Close();
            return;            
        }

    #endregion

    #region Sending Keys and Commands to LOTRO
        private void ExecuteString(string str, KeepFocus kf)
        {//====================================================================
            System.Diagnostics.Process[] ap = System.Diagnostics.Process.GetProcessesByName(Properties.Settings.Default.ClientAppID);
            if (ap.Length > 0)
            {
                SDK.BringWindowToTop(ap[0].MainWindowHandle);

                // Send RETURN, string, RETURN
                SendVK(SDK.VK_RETURN);
                SendString(str);
                SendVK(SDK.VK_RETURN);

                if (kf == KeepFocus.LOMM) System.Threading.Thread.Sleep(Properties.Settings.Default.MillisWaitOnCommand);
            }
            else
            {
                MessageBox.Show("Unable to find LOTRO client to send commands", "LOTRO Music Manager", MessageBoxButtons.OK);
            }
            return;
        }

        private void SendString(String str)
        {//--------------------------------------------------------------------
            for (int i = 0; i < str.Length; i += 1)
            {
                // Send a keydown followed by a keyup and use unicode so we 
                // don't have to mess with converting to VK codes
                //
                // Note: Only sends succesfully when there is an insertion 
                // caret on the LOTRO screen. Cannot send in-play keys
                //
                // To send keypresses when there is no insertion caret, send VKs
                SendChar(str[i]);
            }
            return;
        }

        private void SendVK(short vk)
        {//--------------------------------------------------------------------
            // Convert the VK to a scancode
            IntPtr hkl = SDK.GetKeyboardLayout(0);
            uint scEnter = SDK.MapVirtualKeyEx((uint)vk, (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, hkl);

            // Now send the scancode as a press and depress
            SDK.INPUT input = new SDK.INPUT();
            input.type = (int)SDK.InputType.INPUT_KEYBOARD;
            input.ki.wVk = 0;
            input.ki.time = 0;
            input.ki.dwExtraInfo = (IntPtr)0;
            input.ki.wScan = (short)scEnter;

            input.ki.dwFlags = (int)SDK.KEYEVENTF.SCANCODE;
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));
            input.ki.dwFlags |= (int)SDK.KEYEVENTF.KEYUP;
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));

            return;
        }

        private void SendChar(char ch)
        {//--------------------------------------------------------------------
            // Use SendInput so even DirectX apps get the keys
            SDK.INPUT input = new SDK.INPUT();
            input.type = (int)SDK.InputType.INPUT_KEYBOARD;
            input.ki.wVk = 0;
            input.ki.time = 0;
            input.ki.dwFlags = 0;
            input.ki.dwExtraInfo = (IntPtr)0;
            input.ki.wScan = (short)ch;
            
            input.ki.dwFlags = (int)SDK.KEYEVENTF.UNICODE & ~(int)SDK.KEYEVENTF.KEYUP;  // Not Keyup
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));

            input.ki.dwFlags = (int)SDK.KEYEVENTF.UNICODE |  (int)SDK.KEYEVENTF.KEYUP;   // And now lift the key up
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));
            return;
        } // SendChar
    #endregion

    #region File List Management
        private void OnColumnClick(object sender, ColumnClickEventArgs e)
        {//--------------------------------------------------------------------
            _sorter.CurrentCol = e.Column;
            lstFiles.ListViewItemSorter = _sorter as System.Collections.IComparer;
            lstFiles.Sort();
            return;
        }

        private void OnSaveAs(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            if (dlgSaveAs.ShowDialog() == DialogResult.OK)
            {
                SaveFileAs(dlgSaveAs.FileName);
                ReloadFileList();
                ListViewItem item = lstFiles.FindItemWithText(new FileInfo(dlgSaveAs.FileName).Name);
                if (item != null) 
                {
                    item.Selected = true;
                    lstFiles.EnsureVisible(item.Index);
                }
                ShowSelectedFile();
            }
            return;
        }

        private void OnFileNew(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            if (dlgSaveAs.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(dlgSaveAs.FileName);
                Stream stm = this.GetType().Assembly.GetManifestResourceStream("LOTROMusicManager.Resources.NewABC.txt");
                Byte[] ab = new Byte[stm.Length + 1];
                stm.Read(ab, 0, (int)stm.Length);  // If someone tries to make a default ABC file over (signed int) in length, they deserve to phail
                FileStream fs = fi.Open(FileMode.Create);
                fs.Write(ab, 0, (int)stm.Length);
                fs.Close();
                
                ReloadFileList();
                ListViewItem item = lstFiles.FindItemWithText(new FileInfo(dlgSaveAs.FileName).Name);
                if (item != null) 
                {
                    item.Selected = true;
                    lstFiles.EnsureVisible(item.Index);
                }
                ShowSelectedFile();
            }
            return;
        }

        private void ReloadFileList()
        {//====================================================================
            String strTmp = "";
            String strDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DirectoryInfo di = new DirectoryInfo(strDir);
            di = di.GetDirectories(@"The Lord of the Rings Online\music")[0];

            lstFiles.SuspendLayout();
            lstFiles.Items.Clear();
            FileInfo[] afi = di.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo fi in afi)
            {
                // Get headers of interest for tooltip. Not especially useful,
                // but fun to do.
                String strTitle       = "";
                String strNotes       = "";
                String strKey         = ""; //   \
                String strUnit        = ""; //    > These should be combined into one line
                String strTempo       = ""; //    /
                String strMeter       = ""; //  /
                String strAuthor      = "";
                String strOrigin      = "";
                String strHistory     = "";
                String strTranscriber = "";

                Boolean bHeadersDone  = false;
                
                StreamReader sr = new StreamReader(fi.FullName);
                while (!sr.EndOfStream && !bHeadersDone)
                {
                    strTmp = sr.ReadLine();
                    if (strTmp.Length > 1 && (strTmp.Substring(1,1) != ":" || strTmp.Trim().Substring(0,1) != "%")) 
                    {
                        if (!HEADER_REGEX.IsMatch(strTmp)) 
                        {
                            bHeadersDone = true;
                        }
                        else
                        if (strTmp.Length > 1)
                        {
                            if (strTmp.StartsWith(Properties.Settings.Default.ABCTagTitle,       StringComparison.InvariantCultureIgnoreCase))
                            {strTitle       += strTmp.Substring(2) + "\n";}
                            else
                            if (strTmp.StartsWith(Properties.Settings.Default.ABCTagAuthor,      StringComparison.InvariantCultureIgnoreCase))
                            {strAuthor      += strTmp.Substring(2) + "\n";}
                            else
                            if (strTmp.StartsWith(Properties.Settings.Default.ABCTagHistory,     StringComparison.InvariantCultureIgnoreCase))
                            {strHistory     += strTmp.Substring(2) + "\n";}
                            else
                            if (strTmp.StartsWith(Properties.Settings.Default.ABCTagKey,         StringComparison.InvariantCultureIgnoreCase))
                            {strKey         += strTmp.Substring(2) + "\n";}
                            else
                            if (strTmp.StartsWith(Properties.Settings.Default.ABCTagMeter,       StringComparison.InvariantCultureIgnoreCase))
                            {strMeter       += strTmp.Substring(2) + "\n";}
                            else
                            if (strTmp.StartsWith(Properties.Settings.Default.ABCTagNote,        StringComparison.InvariantCultureIgnoreCase))
                            {strNotes       += strTmp.Substring(2) + "\n";}
                            else
                            if (strTmp.StartsWith(Properties.Settings.Default.ABCTagOrigin,      StringComparison.InvariantCultureIgnoreCase))
                            {strOrigin      += strTmp.Substring(2) + "\n";}
                            else
                            if (strTmp.StartsWith(Properties.Settings.Default.ABCTagTempo,       StringComparison.InvariantCultureIgnoreCase))
                            {strTempo       += strTmp.Substring(2) + "\n";}
                            else
                            if (strTmp.StartsWith(Properties.Settings.Default.ABCTagUnit,        StringComparison.InvariantCultureIgnoreCase))
                            {strUnit       += strTmp.Substring(2) + "\n";}
                            else
                            if (strTmp.StartsWith(Properties.Settings.Default.ABCTagTranscriber, StringComparison.InvariantCultureIgnoreCase))
                            {strTranscriber += strTmp.Substring(2) + "\n";}
                        } // Still could be a header
                    } // Long enough line to examine
                } // Loop over lines until headers are done
                sr.Close();
                sr.Dispose();

                // Assemble the tooltip
                String strTooltip = "";
                if (strTitle.Length > 0) strTooltip += strTitle; // Includes a \n
                strTooltip += (strMeter.Length > 0 ? (strMeter.Remove(strMeter.Length - 1) + " time") : "free meter")
                            + (strKey.Length   > 0 ? (" in " + strKey.Remove(strKey.Length - 1)) : " no key") + "\t"
                            + (strTempo.Length > 0 ? strTempo.Remove(strTempo.Length - 1) : "") + "\t"
                            + (strUnit.Length  > 0 ? strUnit.Remove(strUnit.Length - 1)   : "1/8")     + " unit\n";
                if (strAuthor.Length > 0) strTooltip += strAuthor; // Includes a \n
                if (strOrigin.Length > 0) strTooltip += strOrigin; // Includes a \n
                if (strTranscriber.Length > 0) strTooltip += strTranscriber; // Includes a \n
                if (strNotes.Length > 0) strTooltip += //Double newline if we have text before
                            (strTooltip.Length > 0 ? "\n" : "")  + strNotes; 
                if (strHistory.Length > 0) strTooltip += //Double newline if we have text before
                            (strTooltip.Length > 0 ? "\n" : "")  + strHistory; 

                ListViewItem li = new ListViewItem(strTitle);
                if (strTooltip.Length > 0) li.ToolTipText = strTooltip.Remove(strTooltip.Length - 1);
                li.SubItems.Add(new ListViewItem.ListViewSubItem(li, fi.FullName.Substring((strDir + @"\" + @"The Lord of the Rings Online\music").Length + 1)));
                lstFiles.Items.Add(li);
            }
            lstFiles.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstFiles.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstFiles.ResumeLayout();
            return;
        }

        private void OnRefresh(object sender, EventArgs e)
        {//====================================================================
            ReloadFileList();
            return;
        }

        private void OnFileSelect(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            if (btnSave.Enabled)
            {
                DialogResult res = MessageBox.Show("The text in the ABC file has changed. Do you want to save the changes?", "LOTRO Music Manager", MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    default:
                        // This is a weird error condition.
                        break;
                    
                    case DialogResult.Yes:
                        // Just save and continue
                        //TODO: Need FQN
                        SaveFileAs(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Properties.Settings.Default.MusicSubfolder + lstFiles.Items[_nSelectedFile].SubItems[1].Text);
                        break;
                    
                    case DialogResult.Cancel:
                        // Re-select the old line
                        try
                        {
                            lstFiles.Items[_nSelectedFile].Selected = true;
                        }
                        catch (Exception ex){ex.ToString();} // Makes the warning go away. I *know* I want to ignore this error case.
                        break;

                    case DialogResult.No:
                        // Nothing to do. Just exit the switch and carry on
                        break;                               
                }
            }
            ShowSelectedFile();
            if (lstFiles.SelectedItems.Count > 0)
            {
                _nSelectedFile = lstFiles.SelectedIndices[0];
            }
            else
            {
                _nSelectedFile = -1;
            }
            btnPlay.Enabled = true;
            return;
        } // OnFileSelect

        private void OnFileDoubleClick(object sender, EventArgs e)
        {//====================================================================
            if (lstFiles.SelectedItems.Count > 0)
            {
                PlayFile(lstFiles.SelectedItems[0].SubItems[1].Text);
            }
            return;
        }
    #endregion

    #region LOTRO Music
        private void OnToggleMusicMode(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            ExecuteString(Properties.Settings.Default.ToggleMusicCommand, KeepFocus.LOMM);
            Activate(); // Return focus to the app
            return;
        }

        private void PlayFile(String strFileName)
        {//====================================================================
            String str;
            switch ((PlayTypes)btnPlay.Tag)
            {
                default:
                    // this is an error
                    throw new Exception("Unknown type of performance");
                    //break; -- unreachable
                case PlayTypes.Immediate:
                    str = String.Format(Properties.Settings.Default.PlayFileCommand, strFileName);
                    break;
                case PlayTypes.Sync:
                    str = String.Format(Properties.Settings.Default.PlaySyncCommand, strFileName);
                    break;
            }
            ExecuteString(str, KeepFocus.LOTRO);
            return;
        }

        private void OnPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // This means the "Play" button has been pressed. But it might be
            // the "wait to play" button at the moment. We'll pull that fact 
            // off the button tag.
            if (lstFiles.SelectedItems.Count > 0)
            {
                SaveFile();
                PlayFile(lstFiles.SelectedItems[0].SubItems[1].Text);
            }
            return;
        } // OnPlay

        private void OnDDStartSync(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be sync from now on
            btnPlay.Tag  = PlayTypes.Sync;
            btnPlay.Text = mniDDPlaySync.Text;
            btnPlay.PerformClick();
            return;
        }

        private void OnDDWaitToPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be sync from now on
            btnPlay.Tag = PlayTypes.Sync;
            btnPlay.Text = mniDDPlaySync.Text;
            btnPlay.PerformClick();
            return;
        }

        private void OnDDStartSyncPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be sync from now on
            btnPlay.Tag = PlayTypes.Sync;
            btnPlay.Text = mniDDPlaySync.Text;
            ExecuteString(Properties.Settings.Default.StartSyncCommand, KeepFocus.LOTRO);
            return;
        }

        private void OnDDPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be immediate from now on
            btnPlay.Tag  = PlayTypes.Immediate;
            btnPlay.Text = mniDDPlay.Text;
            btnPlay.PerformClick();
            return;
        }
    #endregion
    
    #region File Editing
        private void SetChangedState(bool b)
        {//====================================================================
            btnSave.Enabled = b; mniSaveABC.Enabled = b;
            btnUndo.Enabled = b; mniUndoAll.Enabled = b;
            return;
        }

        String ConvertNonDosFile(String str)
        {
            // If we have any dos newlines, use the file as-is
            if (str.IndexOf('\r') != -1) return str;

            // split on unix newlines and join with dos newlines
            Char[]   aLF = { '\n' };
            String[] aLines = str.Split(aLF, StringSplitOptions.None);
            return String.Join("\r\n", aLines);
        }

        private void ShowSelectedFile()
        {//--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                String strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Properties.Settings.Default.MusicSubfolder + lstFiles.SelectedItems[0].SubItems[1].Text;
                StreamReader sr = new StreamReader(strFileName);
                txtABC.Text = ConvertNonDosFile(sr.ReadToEnd());
                sr.Close();
                sr.Dispose();

                txtABC.Enabled  = true; // Allow edits
            }
            else
            {
                txtABC.Clear();
                txtABC.Enabled  = false; // Disallow edits
            }
            slEditLocation.Text = "";
            SetChangedState(false); // No changes yet, so no save or undo
            return;
        } // ShowSelectedFile

        private void OnABCChanged(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            SetChangedState(true);
            return;
        }

        private void OnUndoAll(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Just re-load the file
            ShowSelectedFile();
            return;
        } // OnUndoAll

        private void SaveFileAs(String strFileName)
        {//--------------------------------------------------------------------
            StreamWriter sw = new StreamWriter(strFileName, false);
            sw.Write(txtABC.Text);
            sw.Close();
            sw.Dispose();

            SetChangedState(false);            
        }
        
        private void SaveFile()
        {//--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                String strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Properties.Settings.Default.MusicSubfolder + lstFiles.SelectedItems[0].SubItems[1].Text;
                SaveFileAs(strFileName);
            }
        }

        private void OnSaveABC(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            SaveFile();
            return;
        }

        private void OnEditorKeyUp   (object sender, KeyEventArgs e)     {OnUpdateEditor(sender, e);}
        private void OnEditorMouseUp (object sender, MouseEventArgs e)   {OnUpdateEditor(sender, e);}
        private void OnEditorKeyPress(object sender, KeyPressEventArgs e){OnUpdateEditor(sender, e);}
        private void OnEditorClick   (object sender, EventArgs e)        {OnUpdateEditor(sender, e);}
        private void OnUpdateEditor  (object sender, EventArgs e)
        {//--------------------------------------------------------------------
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(UpdateCursorLocation));
            return;
        }

        private void UpdateCursorLocation(Object state)
        {//--------------------------------------------------------------------
            // Get to the right thread
            if (txtABC.InvokeRequired)
            {
                UpdateCursorLocationDel ucp = new UpdateCursorLocationDel(UpdateCursorLocation);
                txtABC.Invoke(ucp, new object[] {state});
                return;
            }

            int nRow = txtABC.GetLineFromCharIndex(txtABC.SelectionStart);
            int nCol = txtABC.SelectionStart - txtABC.GetFirstCharIndexFromLine(nRow);
            nRow += 1; nCol += 1; // 1-base instead of 0-base
            slEditLocation.Text = "Line " + (nRow).ToString() + ", Character " + (nCol).ToString();
            return;
        }

    #endregion
    
    #region Settings
        private void OnToggleAOT(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            TopMost = mniAlwaysOnTop.Checked;
            return;
        }

        private void OnFontSizeChanged(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            txtABC.Font = new Font(txtABC.Font.FontFamily, Int32.Parse(mniEditorFontSize.Text));
            return;
        }

        private void OnOpacityChanged(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            Opacity = double.Parse(mniOpacity.Text) / 100.0;
            return;
        }
    #endregion

    #region Emotes
        private void OnEmote(object sender, EventArgs e)
        {//====================================================================
            ToolStripItem item = (ToolStripItem)sender;
            if (IsCommand(item.Text))
            {
                String s = item.Text;
                // If it has a parens in it, remove it. That's a comment.
                if (s.Contains("("))
                {
                    s = s.Remove(s.IndexOf('('));
                }
                ExecuteString(s.Trim(), KeepFocus.LOMM);
                Activate(); // Keep focus for multiple emotes
            }
            else
            {
                // Windows tried to close the menu because something was selected. Re-show it/
                ((ToolStripMenuItem)item.OwnerItem).ShowDropDown();
            }
            return;
        }

        private void InsertMenuItems(System.Collections.Specialized.StringCollection src, ToolStripMenuItem mnu, EventHandler func)
        {//--------------------------------------------------------------------
            foreach (String s in src)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)mnu.DropDownItems.Add(s, null, func);
                item.DisplayStyle = ToolStripItemDisplayStyle.Text;

                // If it isn't actually a command, make it look special
                if (!IsCommand(s))
                {
                    item.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder);
                }
            }
            return;
        }
    #endregion

    } // class

    public class ColumnSorter : System.Collections.IComparer
    {
        public    int           CurrentCol      {get;set;} // Yay for new 2008 simple property syntax!
        protected List<String>  _lstIgnore      = new List<string>();
        protected static char[] PATH_SEPARATORS = @"/\".ToCharArray();
        protected static String CURRENT_DIR     = @".\";

        public ColumnSorter()
        {//--------------------------------------------------------------------
            // Remove A, An, and The for purposes of comparing
            _lstIgnore.Add("a ");
            _lstIgnore.Add("an ");
            _lstIgnore.Add("the ");
            return;
        }

        int System.Collections.IComparer.Compare(object x, object y)
        {//====================================================================
            String strA = ((ListViewItem)x).SubItems[CurrentCol].Text;
            String strB = ((ListViewItem)y).SubItems[CurrentCol].Text;
            switch (CurrentCol)
            {
                default: throw new Exception("Unknown column being sorted");
                case 0:  return SortTitle(strA, strB); // First column is the title
                case 1:  return SortPath(strA, strB);  // Second columns is the file path and name
            }
        }
        int SortTitle(String strA, String strB)
        {//--------------------------------------------------------------------
            // Remove any prefixes we want to ignore
            // Note that this code will turn "A to Z Waltz" and "The A to Z 
            // Waltz" into "to Z Waltz" for comparison, putting them in the Ts. 
            // This is not necessarily desirable, but is a PITA to fix.
            foreach (String s in _lstIgnore)
            {
                if (strA.StartsWith(s, StringComparison.CurrentCultureIgnoreCase)) strA = strA.Substring(s.Length);
                if (strB.StartsWith(s, StringComparison.CurrentCultureIgnoreCase)) strB = strB.Substring(s.Length);
            }
            return String.Compare(strA, strB);
        }

        int SortPath(String strA, String strB)
        {//--------------------------------------------------------------------
            // One or more has as subdir in it
            // Cases to consider:
            //   bbb.abc           stuff/aaa.abc > bbb is first
            //   stuff/bbb.abc     tmp/aaa.abc   > bbb is first
            //   stuff/zzz/bbb.abc tmp/aaa.abc   > bbb is first
            
            // We're going to make parallel-but-possibly-ragged arrays of
            // the subdir structure and compare parallel depths. We need to 
            // fake up a dir name for files in the root so we have parallelism: 
            // .\zzz.abc and stuff\bbb.abc have to compare at the same depths.
            // Without this we compare zzz.abc to stuff, which is wrong. The 
            // root should always sort to the top (simulating a depth-first 
            // recursion like dir /s)
            if (strA.IndexOfAny(PATH_SEPARATORS) == -1) strA = CURRENT_DIR + strA;
            if (strB.IndexOfAny(PATH_SEPARATORS) == -1) strB = CURRENT_DIR + strB;

            String[] aPartsA = strA.Split(PATH_SEPARATORS);
            String[] aPartsB = strB.Split(PATH_SEPARATORS);
            
            // Compare parallel elements of the arrays
            for (int i = 0; i < (aPartsA.Length < aPartsB.Length ? aPartsA.Length : aPartsB.Length); i += 1)
            {
                if (aPartsA[i] != aPartsB[i]) return String.Compare(aPartsA[i], aPartsB[i]);
            }
            
            // Okay, we walked off the end of one of the arrays, so return the lower 
            // depth of the two as first
            return aPartsA.Length - aPartsB.Length; // Will be negative if B is longer, making A first. And vice-versa.
        }
    }
} // namespace