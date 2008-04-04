using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using LOTROMusicManager.Properties;
using System.Configuration;
using LOTROMusicManager.MyLotroBand;
using System.Collections.Specialized;

namespace LOTROMusicManager
{
    public partial class FormMain: Form      
    {
    #region Properties and types
        //private String          _strFileNameShowing;  
        protected int             _nSelectedFile = -1;
        protected ColumnSorter    _sorter = new ColumnSorter();
        
        private enum PlayTypes   {Immediate, Sync}           
        private enum SONG_COLUMN {Title = 0, Path = 1};
        private enum PROMPT_LOGIN{Yes, No};

        private bool IsCommand(String s) {return s.Trim()[0] == '/';}

        protected FormABCRef _abcref = new FormABCRef();

        private LOTROFocuser _focuser = new LOTROFocuser();
    #endregion

    #region Form methods
        public FormMain()
        {//====================================================================
            InitializeComponent();
            dlgSaveAs.InitialDirectory   = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Resources.MusicSubfolder; 
            dlgOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Resources.MusicSubfolder;
            return;
        }

        private void OnLoad(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Set up the sorting style we want in the list views
            lstFiles.Columns[0].Tag = SortType.TITLE;
            lstFiles.Columns[1].Tag = SortType.PATH; 

            ReloadFileList();
            ShowSelectedFile();
            InsertMenuItems(Settings.Default.Dances,     mniDances,    OnEmote);
            InsertMenuItems(Settings.Default.Emotes,     mniEmotes,    OnEmote);
            InsertMenuItems(Settings.Default.Moods,      mniMoods,     OnEmote);
            InsertMenuItems(Settings.Default.Bestowals,  mniBestowals, OnEmote);

            // Auto-binding size or AOT causes all sorts of mess 
            Size = (Size)Settings.Default.WindowSize;
            TopMost = Settings.Default.AOT;
            Location = (Point)Settings.Default.WindowLocation;

            // Simulate a click on the "Title" column. Much more useful than starting with
            // the filename sorted.
            ColumnClickEventArgs eClick = new ColumnClickEventArgs(0);
            OnColumnClick(lstFiles, eClick);

            // Default to immediate play
            btnPlay.Tag  = PlayTypes.Immediate;
            btnPlay.Text = mniDDPlay.Text;

            // And to recite lyrics in the first option, probably /say
            cmbReciteChannel.SelectedIndex = 0;

            lstMyLotroBand.Columns[0].Tag = SortType.TITLE;
            lstMyLotroBand.Columns[1].Tag = SortType.TITLE;
            lstMyLotroBand.Columns[2].Tag = SortType.INTEGER;
            lstMyLotroBand.Columns[3].Tag = SortType.DEFAULT;
            lstMyLotroBand.Columns[4].Tag = SortType.DATE;

            // Fill in the tags if they've been customized
            if (Settings.Default.TagsEdit    != null) rteEdit.Tags    = Settings.Default.TagsEdit;
            if (Settings.Default.TagsPerform != null) rtePerform.Tags = Settings.Default.TagsPerform;

            CreateTestEmotes();
            LoadEmotes();

            // Kick off the timer that makes LOTRO music play while LOMM has focus
            _focuser.Start();

            return;
        }

        private static void CreateTestEmotes()
        {   //====================================================================
            EmoteGroup eg1 = new EmoteGroup(); eg1.Name = "Dances";
            eg1.Emotes.Add(new Emote("Clap Hands", new String[] { "/dance" }));
            eg1.Emotes.Add(new Emote("Dance 1", new String[] { "/dance1" }));
            eg1.Emotes.Add(new Emote("Hobbit", new String[] { "/dance_hobbit" }));
            eg1.Emotes.Add(new Emote("Elf", new String[] { "/dance_elf" }));
            eg1.Emotes.Add(new Emote("Dwarf", new String[] { "/dance_dwarf" }));

            //--------------------------------------------------------------------
            EmoteGroup eg2 = new EmoteGroup(); eg2.Name = "Social";
            eg2.Emotes.Add(new Emote("Scold x 5 (grants The Naughty at 100)", new String[] { "/scold", "/scold", "/scold", "/scold", "/scold" }));

            //--------------------------------------------------------------------
            EmoteGroup eg3 = new EmoteGroup(); eg3.Name = "Experiments";

            Emote emKey = new Emote(); emKey.Name = "Send key 8";
            emKey.EmoteBlocks.Add(new EmoteBlock(EmoteLine.LineType.KEY, new String[] { "8" }));
            eg3.Emotes.Add(emKey);

            Emote emChance = new Emote(); emChance.Name = "A4, B4, C1";
            EmoteBlock ebA = new EmoteBlock(EmoteLine.LineType.Say, new String[] { "A" }); ebA.Chance = 4;
            EmoteBlock ebB = new EmoteBlock(EmoteLine.LineType.Say, new String[] { "B" }); ebB.Chance = 4;
            EmoteBlock ebC = new EmoteBlock(EmoteLine.LineType.Say, new String[] { "C" }); ebC.Chance = 1;
            emChance.EmoteBlocks.Add(ebA);
            emChance.EmoteBlocks.Add(ebB);
            emChance.EmoteBlocks.Add(ebC);
            eg3.Emotes.Add(emChance);


            Emote emRP = new Emote(); emRP.Name = "Text and then 8";
            EmoteBlock ebRP = new EmoteBlock();
            ebRP.Lines.Add(new EmoteLine(EmoteLine.LineType.Say, "/t ;target Heal incoming"));
            ebRP.Lines.Add(new EmoteLine(EmoteLine.LineType.KEY, "8"));
            emRP.EmoteBlocks.Add(ebRP);
            eg3.Emotes.Add(emRP);

            EmoteGroup eg = new EmoteGroup();
            eg.Groups.Add(eg1);
            eg.Groups.Add(eg2);
            eg.Groups.Add(eg3);

            Settings.Default.EmoteList = eg;
            Settings.Default.Save();

            return;
        }                           

        private void OnClosing(object sender, FormClosingEventArgs e)
        {//--------------------------------------------------------------------
            _focuser.Stop();

            Settings.Default.TagsPerform = new MarkedEditBox.RegexTagBag(rtePerform.Tags);
            Settings.Default.TagsEdit = new MarkedEditBox.RegexTagBag(rteEdit.Tags);
            Settings.Default.WindowLocation = Location;
            Settings.Default.WindowSize = Size;
            Settings.Default.AOT = TopMost;
            Settings.Default.Save();
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

        private void OnActivated(object sender, EventArgs e)
        {   //====================================================================
            _focuser.Start();
            return;
        }

    #endregion

    #region File List Management
        private void OnColumnClick(object sender, ColumnClickEventArgs e)
        {//--------------------------------------------------------------------
            ListView lv = sender as ListView;
            _sorter.CurrentCol = e.Column;
            _sorter.SortType = (SortType)lv.Columns[e.Column].Tag;
            lv.ListViewItemSorter = _sorter as System.Collections.IComparer;
            lv.Sort();
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

        private void MakeNewFile(String strName)
        {//--------------------------------------------------------------------
            FileInfo fi = new FileInfo(strName);
            if (fi.Exists) fi.Delete();

            // Here's something annoying: StreamWriter doesn't Close() when it goes out of scope
            String strBaseABC = Resources.NewABC + "\0";
            StreamWriter sw = fi.CreateText();
            sw.Write(strBaseABC);
            sw.Close();
        }

        private void OnFileNew(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            if (dlgSaveAs.ShowDialog() == DialogResult.OK)
            {
                String strName = dlgSaveAs.FileName;
                MakeNewFile(strName);

                ReloadFileList();
                ListViewItem item = lstFiles.FindItemWithText(new FileInfo(strName).Name);
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
            String strDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DirectoryInfo di = new DirectoryInfo(strDir);
            di = di.GetDirectories(@"The Lord of the Rings Online\music")[0];

            lstFiles.SuspendLayout();
            lstFiles.Items.Clear();
            FileInfo[] afiTxt = di.GetFiles("*.txt", SearchOption.AllDirectories);
            FileInfo[] afiAbc = di.GetFiles("*.abc", SearchOption.AllDirectories);

            AddFilesToList(strDir, afiAbc);
            AddFilesToList(strDir, afiTxt);

            lstFiles.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstFiles.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstFiles.ResumeLayout();
            return;
        } // ReloadFileList

        private void AddFilesToList(String strDir, FileInfo[] afi)
        {//--------------------------------------------------------------------
            String strTmp = "";
            foreach (FileInfo fi in afi)
            {
                // Get headers of interest for tooltip. Not especially useful,
                // but fun to do.
                String strTitle       = "";
                String strNotes       = "";
                String strKey         = ""; //   \
                String strUnit        = ""; //    > These should be combined into one line
                String strTempo       = ""; //   /
                String strMeter       = ""; //  /
                String strAuthor      = "";
                String strOrigin      = "";
                String strHistory     = "";
                String strTranscriber = "";

                Boolean bHeadersDone = false;

                StreamReader sr = new StreamReader(fi.FullName);
                while (!sr.EndOfStream && !bHeadersDone)
                {
                    strTmp = sr.ReadLine();
                    if (!ABC.IsHeader(strTmp))
                    {
                        bHeadersDone = true;
                    }
                    else
                    {
                        if (ABC.IsTitle(strTmp))      {strTitle       += strTmp.Substring(2).Trim();}
                        else
                        if (ABC.IsAuthor(strTmp))     {strAuthor      += strTmp.Substring(2).Trim();}
                        else
                        if (ABC.IsHistory(strTmp))    {strHistory     += strTmp.Substring(2).Trim();}
                        else
                        if (ABC.IsKey(strTmp))        {strKey         += strTmp.Substring(2).Trim();}
                        else
                        if (ABC.IsMeter(strTmp))      {strMeter       += strTmp.Substring(2).Trim();}
                        else
                        if (ABC.IsNotes(strTmp))      {strNotes       += strTmp.Substring(2).Trim();}
                        else
                        if (ABC.IsOrigin(strTmp))     {strOrigin      += strTmp.Substring(2).Trim();}
                        else
                        if (ABC.IsTempo(strTmp))      {strTempo       += strTmp.Substring(2).Trim();}
                        else                                           
                        if (ABC.IsUnit(strTmp))       {strUnit        += strTmp.Substring(2).Trim();}
                        else
                        if (ABC.IsTranscriber(strTmp)){strTranscriber += strTmp.Substring(2).Trim();}
                    } // Header line
                } // Loop over lines until headers are done
                sr.Close();
                sr.Dispose();

                // Assemble the tooltip
                String strTooltip = "";
                if (strTitle.Length > 0) strTooltip += strTitle + Environment.NewLine; 
                strTooltip += (strMeter.Length > 0 ? (strMeter + " time") : "free meter")
                            + (strKey.Length   > 0 ? (" in " + strKey) : " no key") + Environment.NewLine;
                strTooltip += (strTempo.Length > 0 ? strTempo + " bpm with " : "")
                            + (strUnit.Length  > 0 ? strUnit : "1/8") + " as the beat unit" + Environment.NewLine;
                if (strAuthor.Length > 0) strTooltip += "By: " + strAuthor + Environment.NewLine; 
                if (strOrigin.Length > 0) strTooltip += "Origin: " + strOrigin + Environment.NewLine; 
                if (strTranscriber.Length > 0) strTooltip += "Transcribed by: " + strTranscriber + Environment.NewLine; 
                
                if (strNotes.Length > 0) strTooltip += //Double newline if we have text before
                            (strTooltip.Length > 0 ? Environment.NewLine : "") + strNotes;
                
                if (strHistory.Length > 0) strTooltip += //Double newline if we have text before
                            (strTooltip.Length > 0 ? Environment.NewLine : "") + strHistory;

                ListViewItem li = new ListViewItem(strTitle);
                if (strTooltip.Length > 0) li.ToolTipText = strTooltip.Remove(strTooltip.Length - 1);
                li.SubItems.Insert((int)SONG_COLUMN.Path, new ListViewItem.ListViewSubItem(li, fi.FullName.Substring((strDir + @"\" + @"The Lord of the Rings Online\music").Length + 1)));
                lstFiles.Items.Add(li);
            }
            return;
        } // AddFilesToList

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
                        SaveFileAs(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Resources.MusicSubfolder + lstFiles.Items[_nSelectedFile].SubItems[(int)SONG_COLUMN.Title].Text);
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
                PlayFile(lstFiles.SelectedItems[0].SubItems[(int)SONG_COLUMN.Title].Text);
            }
            return;
        }
    #endregion

    #region LOTRO Music
        private void OnToggleMusicMode(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            RemoteController.SendText(Resources.ToggleMusicCommand);
            Activate(); // Return focus to the app
            return;
        }

        private void PlayWithLyrics(String strFileName)
        {//====================================================================
            PlayFile(strFileName);
            return;
        }

        private void PlayFile(String strFileName)
        {//====================================================================
            // Make the string to send
            String str;
            switch ((PlayTypes)btnPlay.Tag)
            {
                default:
                    // this is an error
                    throw new Exception("Unknown type of performance");
                    //break; -- unreachable
                case PlayTypes.Immediate:
                    str = String.Format(Resources.PlayFileCommand, strFileName);
                    break;
                case PlayTypes.Sync:
                    str = String.Format(Resources.PlaySyncCommand, strFileName);
                    break;
            }
            RemoteController.SendText(str);
            _focuser.Start();
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
                PlayWithLyrics(lstFiles.SelectedItems[0].SubItems[(int)SONG_COLUMN.Path].Text);
            }
            return;
        } // OnPlay

        private void OnStartSync(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be sync from now on
            btnPlay.Tag  = PlayTypes.Sync;
            btnPlay.Text = mniDDPlaySync.Text;
            btnPlay.PerformClick();
            return;
        }

        private void OnWaitToPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be sync from now on
            btnPlay.Tag = PlayTypes.Sync;
            btnPlay.Text = mniDDPlaySync.Text;
            btnPlay.PerformClick();
            return;
        }

        private void OnStartSyncPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be sync from now on
            btnPlay.Tag = PlayTypes.Sync;
            btnPlay.Text = mniDDPlaySync.Text;
            RemoteController.SendText(Resources.StartSyncCommand);
            return;
        }

        private void OnDropDownPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be immediate from now on
            btnPlay.Tag  = PlayTypes.Immediate;
            btnPlay.Text = mniDDPlay.Text;
            btnPlay.PerformClick();
            return;
        }

        private void OnStopSong(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            btnPlay.Text = mniDDPlay.Text;
            btnPlay.Tag  = PlayTypes.Immediate;
            //RemoteController.SendKey('`', RemoteController.Focus.LOCAL); //TODO: Make the stop-song configurable
            RemoteController.SendChars(new char[]{'`'}, new BuckyBits {Alt = false, Shift = false, Control = false});
            return;
        } // OnDDStopSong

    #endregion
    
    #region File Editing
        private void SetChangedState(bool b)
        {//====================================================================
            btnSave.Enabled = b; mniSaveABC.Enabled = b;
            btnUndo.Enabled = b; mniUndoAll.Enabled = b;
            return;
        }
                                                          
        private String ConvertNonDosFile(String str)
        {//====================================================================
            // If we have any dos newlines, use the file as-is
            if (str.IndexOf('\r') != -1) return str;

            // split on unix newlines and join with dos newlines
            Char[]   aLF = { '\n' };
            String[] aLines = str.Split(aLF, StringSplitOptions.None);
            return String.Join(Environment.NewLine, aLines);
        }

        private void ShowSelectedFile()
        {//--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                // Clear selections because we can get in a weird state otherwise
                rteEdit.SelectionStart    = 0;  rteEdit.SelectionLength    = 0;
                rtePerform.SelectionStart = 0;  rtePerform.SelectionLength = 0;
                
                String strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Resources.MusicSubfolder + lstFiles.SelectedItems[0].SubItems[(int)SONG_COLUMN.Path].Text;
                StreamReader sr = new StreamReader(strFileName);
                rteEdit.Text = ConvertNonDosFile(sr.ReadToEnd());
                
                rtePerform.Text = rteEdit.Text;
                sr.Close();
                sr.Dispose();

                rteEdit.Enabled  = true; // Allow edits

                for (int i = 0; i < rteEdit.Lines.Length; i += 1)
                {
                    if (ABC.IsLyrics(rteEdit.Lines[i])) 
                    {
                        lstLyrics.Items.Add(new ABCLine(ABC.RemoveHeaderTag(rteEdit.Lines[i]), i));
                    }
                }
            }
            else
            {
                lstLyrics.Items.Clear();
                rteEdit.Clear();
                rtePerform.Clear();
                rteEdit.Enabled  = false; // Disallow edits
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

        private void OnDeleteFile(object sender, EventArgs e)
        {//====================================================================
            if (lstFiles.SelectedItems.Count == 0) return;

            String strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Resources.MusicSubfolder + lstFiles.SelectedItems[0].SubItems[(int)SONG_COLUMN.Title].Text;
            FileInfo fi = new FileInfo(strFileName);
            fi.Delete();

            ReloadFileList();
            return;
        }

        private void SaveFileAs(String strFileName)
        {//--------------------------------------------------------------------
            StreamWriter sw = new StreamWriter(strFileName, false);
            sw.Write(rteEdit.Text);
            sw.Close();
            sw.Dispose();

            SetChangedState(false);            
        }
        
        private void SaveFile()
        {//--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                String strFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Resources.MusicSubfolder + lstFiles.SelectedItems[0].SubItems[(int)SONG_COLUMN.Path].Text;
                SaveFileAs(strFileName);
            }
        }

        private void OnSaveABC(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            SaveFile();
            return;
        }

        private void OnCaretMoved(object sender, MarkedEditBox.CaretMovedEventArgs e)
        {   //====================================================================
            slEditLocation.Text = "Line " + (e.Row + 1).ToString() + ", Character " + (e.Col + 1).ToString();
            return;
        }

    #endregion
    
    #region Settings
        private void OnOptions(object sender, EventArgs e)
        {
            FormOptions dlg = new FormOptions(this);
            if (dlg.ShowDialog() == DialogResult.OK) 
            {
                Settings.Default.KeepLOTROFocused = dlg.KeepLOTROFocused;
                Settings.Default.Opacity          = Opacity.ToString();
                
                Settings.Default.AOT              = dlg.AOT;
                TopMost = Settings.Default.AOT;

                Settings.Default.Save();
            }
            else
            {
                Opacity = Double.Parse(Settings.Default.Opacity);
            }
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
                RemoteController.SendText(s.Trim());
                Activate(); // Keep focus for multiple emotes
            }
            else
            {
                // Windows tried to close the menu because something was selected. Re-show it/
                ((ToolStripMenuItem)item.OwnerItem).ShowDropDown();
            }
            return;
        }

        private void InsertMenuItems(StringCollection src, ToolStripMenuItem mnu, EventHandler func)
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

        private void LoadEmotes()
        {//====================================================================
            EmoteGroup egTop = Settings.Default.EmoteList;
            foreach (EmoteGroup eg in egTop.Groups)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)menustripEmotes.Items.Add(eg.Name);
                AddEmoteGroupToMenuItem(eg, item);
            }
            return;
        }

        private void AddEmoteGroupToMenuItem(EmoteGroup eg, ToolStripMenuItem tsi)
        {   //====================================================================
            foreach (EmoteGroup egInner in eg.Groups)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)tsi.DropDownItems.Add(egInner.Name);
                item.Tag = egInner;
                AddEmoteGroupToMenuItem(egInner, item);
            }

            foreach (Emote e in eg.Emotes)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)tsi.DropDownItems.Add(e.Name, null, OnCustomEmote);
                item.Tag = e;
            }
            return;
        }

        private void OnCustomEmote(object sender, EventArgs e)
        {   //====================================================================
            Emote em = (Emote)(((ToolStripMenuItem)sender).Tag);
            em.Execute();
            return;
        }
    #endregion

    #region MyLotroBand
        private void OnMyLotroBandLogin(object sender, EventArgs e)
        {//====================================================================
            Credentials creds = GetMyLotroBandCredentials(PROMPT_LOGIN.Yes);
            MyLotroBand.MyLotroBand mlb = new MyLotroBand.MyLotroBand();
            SongResponse songs = mlb.GetSongList(creds);
            //TODO: error handling around song response

            foreach (Song s in songs.Song)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = s.SongName;
                lvi.SubItems.Add(s.ArtistName);
                lvi.SubItems.Add(s.NumParts.ToString());
                lvi.SubItems.Add(s.AddedBy);
                lvi.SubItems.Add(s.Created.ToShortDateString());
                lvi.SubItems.Add(s.SongId.ToString());
                lstMyLotroBand.Items.Add(lvi);
            }

            return;
        }

        private Boolean CredsIsBad(Credentials creds)
        {   //====================================================================
            return creds.Password == null || creds.Password.Length < 1 || creds.Email == null || creds.Email.Length < 1;
        }

        private Credentials GetMyLotroBandCredentials(PROMPT_LOGIN prompt)
        {   //====================================================================
            Credentials credsRet = null;
            Credentials creds = new Credentials();
            creds.Email = Properties.Settings.Default.MyLotroBandLoginEmail;
            creds.Password = Properties.Settings.Default.MyLotroBandLoginPW;

            if (prompt == PROMPT_LOGIN.Yes && CredsIsBad(creds))
            {
                FormMyLotroBandLogin dlg = new FormMyLotroBandLogin();
                dlg.RememberLoginInformation = Properties.Settings.Default.MyLotroBandRememberLoginInformation;

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    creds.Email = dlg.Email;
                    creds.Password = dlg.Password;

                    Properties.Settings.Default.MyLotroBandRememberLoginInformation = dlg.RememberLoginInformation;
                    Properties.Settings.Default.MyLotroBandLoginEmail = dlg.RememberLoginInformation ? creds.Email : String.Empty;
                    Properties.Settings.Default.MyLotroBandLoginPW = dlg.RememberLoginInformation ? creds.Password : String.Empty;
                    Properties.Settings.Default.Save();

                    credsRet = creds;
                }
            }
            else
            {
                credsRet = creds;
            }
            return credsRet;
        }

        private void OnMyLotroBandForgetLoginInformation(object sender, EventArgs e)
        {   //====================================================================
            Properties.Settings.Default.MyLotroBandLoginEmail = String.Empty;
            Properties.Settings.Default.MyLotroBandLoginPW = String.Empty;
            Properties.Settings.Default.Save();
        }

        private void OnMyLotroBandVisitSite(object sender, EventArgs e)
        {   //====================================================================
            Process.Start("http://mylotroband.joshkraker.com/");
            return;
        }

        private void OnMyLotroBandCreateAccount(object sender, EventArgs e)
        {   //====================================================================
            Process.Start("http://mylotroband.joshkraker.com/CreateMember.aspx"); //TODO: Replace with web service call when available
            return;
        }
    
        private void OnMyLotroBandSongSelectionChange(object sender, EventArgs e)
        {   //====================================================================
            if (lstMyLotroBand.SelectedItems.Count > 0) btnMyLotroBandActions.Enabled = true;
            return;
        }

        private void OnMyLotroBandClick(object sender, EventArgs e)
        {   //====================================================================
            if (lstMyLotroBand.SelectedItems.Count > 0)
            {
                DownloadAllParts(lstMyLotroBand.SelectedItems[0].SubItems[5].Text, lstMyLotroBand.SelectedItems[0].Text);
            }
            return;
        }

        private void DownloadAllParts(String strSongId, String strSongName)
        {   //--------------------------------------------------------------------
            Credentials creds = GetMyLotroBandCredentials(PROMPT_LOGIN.No);
            if (null == creds) return;

            MyLotroBand.MyLotroBand mlb = new MyLotroBand.MyLotroBand();
            PartResponse parts = mlb.GetSongParts(creds, Int32.Parse(strSongId));
            foreach (Part p in parts.Part)
            {
                String strBaseName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Resources.MusicSubfolder + @"\" + strSongName;
                FileInfo fi = new FileInfo(strBaseName + " - part " + p.PartId.ToString()+".abc");
                int i = 0;
                while (fi.Exists && i < 100) fi = new FileInfo(strBaseName + " - part " + p.PartId.ToString() + " (" + (++i).ToString() + ").abc");
                if (i >= 100) break; //TODO: Sounds like a major error condition here!
                StreamWriter sw = fi.CreateText();
                sw.Write(p.Abc);
                sw.Flush();
                sw.Close();
            }
            return;
        }
    #endregion

    #region Lyrics Playing
        protected static bool _bInProgrammaticUIChange = false;
        private void OnPerformCaretMoved(object sender, MarkedEditBox.CaretMovedEventArgs e)
        {   //====================================================================
            if (_bInProgrammaticUIChange) return;
            _bInProgrammaticUIChange = true;

            rtePerform.SelectLine(rtePerform.InsertionRow);

            if (ABC.IsLyrics(rtePerform.Lines[rtePerform.InsertionRow]))
            {
                // We have a lyrics line
                btnPerform.Text = "Recite Line";

                // Select the right item in the listbox
                lstLyrics.SelectedIndex = -1;
                for (int i = 0; i < lstLyrics.Items.Count; i += 1)
                {
                    ABCLine line = (ABCLine)lstLyrics.Items[i];
                    if (line.SourceLine == rtePerform.InsertionRow) 
                    {
                        lstLyrics.SelectedIndex = i;
                        break;
                    }
                }
            } // Lyrics line
            else
            {
                btnPerform.Text = "Recite Next Line";
            } // Not a lyrics line

            _bInProgrammaticUIChange = false;
            return;
        }
    
        private void OnLyricsListSelectedIndexChanged(object sender, EventArgs e)
        {   //====================================================================
            if (_bInProgrammaticUIChange) return;
            _bInProgrammaticUIChange = true;
            
            // Select the right line in the rtf view
            ABCLine line = (ABCLine)lstLyrics.SelectedItem;
            rtePerform.SelectLine(line.SourceLine);
            
            _bInProgrammaticUIChange = false;
            return;
        }

        private void OnPerformKeyPress(object sender, KeyPressEventArgs e)
        {   //====================================================================
            // No right and left, only up and down
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Right) e.KeyChar = (char)System.Windows.Forms.Keys.Down;
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Left)  e.KeyChar = (char)System.Windows.Forms.Keys.Up;
            e.Handled = false;
        }

    #endregion

    #region Song List Context Menu
        private void OnSongListCopyTitle(object sender, EventArgs e)
        {   //====================================================================
            if (lstFiles.SelectedItems.Count > 0)
            {
                Clipboard.SetText(lstFiles.SelectedItems[0].Text);
            }
            return;
        }

        private void OnSongListCopyFilename(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                Clipboard.SetText(lstFiles.SelectedItems[0].SubItems[(int)SONG_COLUMN.Path].Text);
            }
            return;
        }

        private void OnSongListCopyFQFilename(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                Clipboard.SetText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                  Resources.MusicSubfolder +
                                  lstFiles.SelectedItems[0].SubItems[(int)SONG_COLUMN.Path].Text);
            }
            return;
        }

        private void OnSongListCopyInfoBlock(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                Clipboard.SetText(lstFiles.SelectedItems[0].ToolTipText);
            }
            return;
        }
    #endregion

    } // class
} // namespace