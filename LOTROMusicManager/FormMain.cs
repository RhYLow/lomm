using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace LOTROMusicManager
{
    // Delegate to defer reading the curson location until after the text box has moved it.
    // Otherwise we get the change notification during the key or mouse processing and we're
    // one location behine. We use this delegate to push over to a thread to make the check.
    // Basically, the thread waits on the UI message queue via InvokeRequired/Invoke
    public delegate void UpdateCursorLocationDel(Object state);

    public partial class FormMain: Form
    {
    #region Properties and types
        private String          _strFileNameShowing;
        private ColumnSorter    _sorter = new ColumnSorter();
        
        private enum PlayTypes {Immediate, Sync}
        private PlayTypes       _playtype = PlayTypes.Immediate; // Default to playing now
        
        private bool IsCommand(String s) {return s.Trim()[0] == '/';}

        private ABCRef _abcref = new ABCRef();
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
            InsertMenuItems(Properties.Settings.Default.Dances, mniDances, OnEmote);
            InsertMenuItems(Properties.Settings.Default.Emotes, mniEmotes, OnEmote);
            InsertMenuItems(Properties.Settings.Default.Moods,  mniMoods,  OnEmote);

            mniOpacity.SelectedIndex = (int)(10*(1-Opacity));
            //TODO: Get EditorFontSize menu an initial value 

            // Auto-binding size causes all sorts of mess with minimizing and maximizing
            Size = (Size)Properties.Settings.Default.WindowSize;

            // Simulate a click on the "Title" column. Much more useful than starting with
            // the filename sorted.
            ColumnClickEventArgs eClick = new ColumnClickEventArgs(1);
            OnColumnClick(new object(), eClick);
            return;
        }                           

        private void OnClosing(object sender, FormClosingEventArgs e)
        {//--------------------------------------------------------------------
            Properties.Settings.Default.WindowSize = Size;
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
    #endregion

    #region Sending Keys and Commands to LOTRO
        private void ExecuteString(string str)
        {//====================================================================
            System.Diagnostics.Process[] ap = System.Diagnostics.Process.GetProcessesByName(Properties.Settings.Default.ClientAppID);
            if (ap.Length > 0)
            {
                SDK.BringWindowToTop(ap[0].MainWindowHandle);

                // Send RETURN, string, RETURN
                SendVK(SDK.VK_RETURN);
                SendString(str);
                SendVK(SDK.VK_RETURN);
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
            input.ki.wScan = 0;
            input.ki.time = 0;
            input.ki.dwFlags = 0;
            input.ki.dwExtraInfo = (IntPtr)0;
            input.ki.wScan = (short)ch;

            input.ki.dwFlags = (int)SDK.KEYEVENTF.UNICODE;  // Nothing added implies keydown
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));

            input.ki.dwFlags |= (int)SDK.KEYEVENTF.KEYUP;   // And now lift the key up... UNICODE is still set
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
                fi.Create();
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
            FileInfo[] afi = di.GetFiles();
            foreach (FileInfo fi in afi)
            {
                //TODO: Find the T: line, if any
                String strTitle = "";
                Boolean bFoundTitle = false;
                StreamReader sr = new StreamReader(fi.FullName);
                while (!sr.EndOfStream && !bFoundTitle)
                {
                    strTmp = sr.ReadLine();
                    if (strTmp.StartsWith(Properties.Settings.Default.ABCTagTitle, StringComparison.InvariantCultureIgnoreCase))
                    {
                        strTitle = strTmp.Substring(2).Trim();
                        bFoundTitle = true;
                    }
                }
                sr.Close();
                sr.Dispose();

                ListViewItem li = new ListViewItem(fi.Name);
                li.SubItems.Add(new ListViewItem.ListViewSubItem(li, strTitle));
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
                        SaveFileAs(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Properties.Settings.Default.MusicSubfolder + _strFileNameShowing);
                        break;
                    
                    case DialogResult.Cancel:
                        // Re-select the old line
                        ListViewItem lvi = lstFiles.FindItemWithText(_strFileNameShowing);
                        if (lvi != null)
                        {
                            lvi.Selected = true;
                            return;
                        }
                        break;
                    
                    case DialogResult.No:
                        // Nothing to do. Just exit the switch and carry on
                        break;                               
                }
            }
            ShowSelectedFile();
            if (lstFiles.SelectedItems.Count > 0)
            {
                _strFileNameShowing = lstFiles.SelectedItems[0].Text;
            }
            else
            {
                _strFileNameShowing = null;
            }
            btnPlay.Enabled = true;
            return;
        } // OnFileSelect

        private void OnFileDoubleClick(object sender, EventArgs e)
        {//====================================================================
            if (lstFiles.SelectedItems.Count > 0)
            {
                PlayFile(lstFiles.SelectedItems[0].Text);
            }
            return;
        }
    #endregion

    #region LOTRO Music
        private void OnToggleMusicMode(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            ExecuteString(Properties.Settings.Default.ToggleMusicCommand);
            return;
        }

        private void PlayFile(String strFileName)
        {//====================================================================
            String str;
            switch (_playtype)
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
            ExecuteString(str);
            return;
        }

        private void OnPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                SaveFile();
                PlayFile(lstFiles.SelectedItems[0].Text);
            }
            return;
        } // OnPlay
    #endregion
    
    #region File Editing
        private void SetChangedState(bool b)
        {//====================================================================
            btnSave.Enabled = b; mniSaveABC.Enabled = b;
            btnUndo.Enabled = b; mniUndoAll.Enabled = b;
            return;
        }

        private void ShowSelectedFile()
        {//--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                String strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Properties.Settings.Default.MusicSubfolder + lstFiles.SelectedItems[0].Text;
                StreamReader sr = new StreamReader(strFileName);
                txtABC.Text = sr.ReadToEnd();
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
                String strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Properties.Settings.Default.MusicSubfolder + lstFiles.SelectedItems[0].Text;
                SaveFileAs(strFileName);
            }
        }

        private void OnSaveABC(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            SaveFile();
            return;
        }

        private void OnUpdateEditor(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            
            // e could be a MouseEventArgs, a KeyEventArgs, or a generic
            // EventArgs, if we ever care
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
    
    #region Play Now or Synchronize
	    private void SetPlayType(PlayTypes pt)
        {//====================================================================
            _playtype = pt;
            mniPlayTypeImmediate.Checked = _playtype == PlayTypes.Immediate;
            mniPlayTypeSync.Checked      = _playtype == PlayTypes.Sync;
            btnStartSync.Enabled = _playtype == PlayTypes.Sync;
            return;
        }

        private void OnSelectPlayImmediate(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            SetPlayType(PlayTypes.Immediate);
            return;
        }

        private void OnSelectPlaySync(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            SetPlayType(PlayTypes.Sync);
            return;
        }

        private void OnToggleSync(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            SetPlayType(chkSync.Checked ? PlayTypes.Sync : PlayTypes.Immediate);
            return;
        }

        private void OnStartSync(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            ExecuteString(Properties.Settings.Default.PlaySyncCommand);
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
                ExecuteString(item.Text.Trim());
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
                ToolStripItem item = mnu.DropDownItems.Add(s, null, func);
                item.DisplayStyle = ToolStripItemDisplayStyle.Text;

                // If it is 't actually a command, make it look special
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
        private int _nCurrentCol = 0;
        public int CurrentCol {get {return _nCurrentCol;} set {_nCurrentCol = value;}}
        int System.Collections.IComparer.Compare(object x, object y)
        {
            List<String> lstIgnore = new List<string>();
            lstIgnore.Add("the ");
            lstIgnore.Add("an ");
            lstIgnore.Add("a ");

            ListViewItem rowA = (ListViewItem)x; String strA = rowA.SubItems[CurrentCol].Text.Trim();
            ListViewItem rowB = (ListViewItem)y; String strB = rowB.SubItems[CurrentCol].Text.Trim();
            
            foreach (String s in lstIgnore)
            {
                if (strA.StartsWith(s, StringComparison.CurrentCultureIgnoreCase)) strA = strA.Substring(s.Length);
                if (strB.StartsWith(s, StringComparison.CurrentCultureIgnoreCase)) strB = strB.Substring(s.Length);
            }
            return String.Compare(strA, strB); 
        }
        public ColumnSorter() {}
    }
} // namespace