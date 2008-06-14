using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using LotroMusicManager.Properties;
using System.Configuration;
//using LotroMusicManager.MyLotroBand;
using System.Collections.Specialized;

namespace LotroMusicManager
{
    public partial class FormMain: Form      
    {
    #region Properties and types
        protected int             _nSelectedFile = -1;
        protected ColumnSorter    _sorter = new ColumnSorter();
        protected int             _nEditFirstLine = 0;
        
        private enum SONG_COLUMN  {Title = 0, Path = 1, Index = 2};
        private enum PROMPT_LOGIN {Yes, No};

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
            lstFiles.Columns[2].Tag = SortType.INTEGER;

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

            lstFiles.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstFiles.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstFiles.Columns[2].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);


            // Default to immediate play
            btnPlay.Tag  = Song.PlayType.Immediate;
            btnPlay.Text = mniDDPlay.Text;

            // And to recite lyrics in the first option, probably /say
            cmbReciteChannel.SelectedIndex = 0;

            // Fill in the tags if they've been customized
            if (Settings.Default.TagsEdit    != null) rteEdit.Tags    = Settings.Default.TagsEdit;
            if (Settings.Default.TagsPerform != null) rtePerform.Tags = Settings.Default.TagsPerform;

            rteEdit.AutoTag = Settings.Default.HighlightABC;

            menustripMain.Left = 0;
            
            //Macro mac = new Macro("Test Macro");
            //mac.AddAction(new MacroActionSay(MacroAction.Channel.Say, "Some text"));
            //mac.AddAction(new MacroActionBinding(LotroFunction.Functions["ToggleCraftingPanel"]));
            //mac.Execute();
            FormMacroManager fmm = new FormMacroManager();
            fmm.ShowDialog();


            // Kick off the timer that makes LOTRO music play while LOMM has focus
            _focuser.Start();

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
                ReloadFileList(); //TODO: Is this too slow?
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
            //TODO: should this include a "using" statement?
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

                ReloadFileList(); //TODO: Is this too slow?
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

        private void AddFilesToList(FileInfo[] afi)
        {//====================================================================   
            foreach (FileInfo fi in afi)
            {
                List<Song> lstSongs = Song.SongsFromFile(fi);
                foreach (Song song in lstSongs)
                {
                    ListViewItem li = new ListViewItem(song.Title);
                    li.Tag = song;
                    // These have to be in this order or else we get an argument out of range. 
                    // There might be a way to set the number of columns in the subitems collection, 
                    // but this works
                    li.SubItems.Insert((int)SONG_COLUMN.Path,  new ListViewItem.ListViewSubItem(li, song.ShortName));
                    li.SubItems.Insert((int)SONG_COLUMN.Index, new ListViewItem.ListViewSubItem(li, song.Index));
                    li.ToolTipText = song.ToolTip;
                    lstFiles.Items.Add(li);
                }
            }

            return;
        }

        private void ReloadFileList()
        {   //====================================================================
            // Get a prompt to save the file if necessary
            if (lstFiles.SelectedItems.Count > 0) lstFiles.SelectedItems[0].Selected = false;
            
            lstFiles.Items.Clear();
            lstLyrics.Items.Clear();
            rteEdit.Clear();
            rtePerform.Clear();
            SetChangedState(false);

            DirectoryInfo di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Resources.MusicSubfolder);
            AddFilesToList(di.GetFiles("*.abc", SearchOption.AllDirectories));
            AddFilesToList(di.GetFiles("*.txt", SearchOption.AllDirectories));

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
                DialogResult res = MessageBox.Show("The song has changed. Do you want to save the changes?", "LOTRO Music Manager", MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    default:
                        // This is a weird error condition.
                        break;
                    
                    case DialogResult.Yes:
                        // Just save and continue
                        //TODO: Need FQN
                        ((Song)lstFiles.Items[_nSelectedFile].Tag).Save();
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
        {   //====================================================================
            PlaySong(Song.PlayType.Immediate);
            return;
        }

        private void OnOpenInEditor(object sender, EventArgs e)
        {   //====================================================================
            if (0 == lstFiles.SelectedItems.Count) return;

            if (((Song)lstFiles.SelectedItems[0].Tag).FileName.ToLower().EndsWith(".txt"))
            {
                // Just execute the file, since they may have a preferred editor
                Process.Start("\"" + ((Song)lstFiles.SelectedItems[0].Tag).FileName + "\"");
            }
            else
            if (((Song)lstFiles.SelectedItems[0].Tag).FileName.ToLower().EndsWith(".abc"))
            {
                // They may not have an association for .abc
                Process.Start("notepad.exe", "\"" + ((Song)lstFiles.SelectedItems[0].Tag).FileName + "\"");
            }

            return;
        }
    #endregion

    #region LOTRO Music
        private void PlaySong(Song.PlayType playtype)
        {   //====================================================================
            if (lstFiles.SelectedItems.Count == 0) return;

            SaveFile();
            ((Song)lstFiles.SelectedItems[0].Tag).Play(playtype);
            _focuser.Start();
            return;
        }

        private void OnToggleMusicMode(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            RemoteController.SendText(Resources.ToggleMusicCommand);
            Activate(); // Return focus to the app
            return;
        }

        private void OnPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // This means the "Play" button has been pressed. But it might be
            // the "wait to play" button at the moment. We'll pull that fact 
            // off the button tag.
            PlaySong((Song.PlayType)btnPlay.Tag);
            return;
        } // OnPlay

        private void OnStartSync(object sender, EventArgs e)
        {
        }

        private void OnWaitToPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be sync from now on
            btnPlay.Tag = Song.PlayType.Sync;
            btnPlay.Text = mniDDPlaySync.Text;
            btnPlay.PerformClick();
            return;
        }

        private void OnStartSyncPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be sync from now on
            btnPlay.Tag = Song.PlayType.Sync;
            btnPlay.Text = mniDDPlaySync.Text;
            RemoteController.SendText(Resources.StartSyncCommand);
            return;
        }

        private void OnDropDownPlay(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Switch the button to be immediate from now on
            btnPlay.Tag  = Song.PlayType.Immediate;
            btnPlay.Text = mniDDPlay.Text;
            btnPlay.PerformClick();
            return;
        }

        private void OnStopSong(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            btnPlay.Text = mniDDPlay.Text;
            btnPlay.Tag  = Song.PlayType.Immediate;
            RemoteController.ExecuteFunction("MusicEndSong");
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
                                                          
        private void ShowSelectedFile()
        {//--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                // Clear selections because we can get in a weird state otherwise
                rteEdit.SelectionStart    = 0;  rteEdit.SelectionLength    = 0;
                rtePerform.SelectionStart = 0;  rtePerform.SelectionLength = 0;
                
                _nEditFirstLine = ((Song)lstFiles.SelectedItems[0].Tag).FirstLine;

                rteEdit.Text = ((Song)lstFiles.SelectedItems[0].Tag).Text;
                rtePerform.Text = rteEdit.Text;
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

            if (MessageBox.Show("Really delete " + ((Song)lstFiles.SelectedItems[0].Tag).FileName + "?", "LOMM File Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(((Song)lstFiles.SelectedItems[0].Tag).FileName);
                fi.Delete();

                ReloadFileList();
                SetChangedState(false);
            }
            return;
        }

        private void SaveFileAs(String strFileName)
        {//--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                ((Song)lstFiles.SelectedItems[0].Tag).Text = rteEdit.Text;
                ((Song)lstFiles.SelectedItems[0].Tag).SaveAs(strFileName);
                SetChangedState(false);            
            }
        }
        
        private void SaveFile()
        {//--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                ((Song)lstFiles.SelectedItems[0].Tag).Text = rteEdit.Text;
                ((Song)lstFiles.SelectedItems[0].Tag).Save();
                SetChangedState(false);            
            }
        }

        private void OnSaveABC(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            SaveFile();
            return;
        }

        private void OnCaretMoved(object sender, MarkedEditBox.CaretMovedEventArgs e)
        {   //====================================================================
            slEditLocation.Text = "Line " + (e.Row + _nEditFirstLine).ToString() + ", Character " + (e.Col + 1).ToString();
            return;
        }

        private void OnEditorSelectAll(object sender, EventArgs e)
        {   //====================================================================
            rteEdit.SelectAll();
            return;
        }

        private void OnEditCopy(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            rteEdit.Copy();
            return;
        }

        private void OnEditCut(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            rteEdit.Cut();
            return;
        }

        private void OnEditPaste(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            rteEdit.Paste();
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

                rteEdit.AutoTag = Settings.Default.HighlightABC;
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

    #endregion

    #region Lyrics Playing
        private void ReciteLine()
        {   //--------------------------------------------------------------------
            if (lstLyrics.SelectedItems.Count != 1) return;

            RemoteController.SendText(cmbReciteChannel.Text + " " + lstLyrics.SelectedItem.ToString());
            lstLyrics.SelectedIndex = (lstLyrics.SelectedIndex < lstLyrics.Items.Count) ? lstLyrics.SelectedIndex + 1 : 0;
            lstLyrics.Focus();
        }

        protected static bool _bInProgrammaticUIChange = false;
        private void OnPerformCaretMoved(object sender, MarkedEditBox.CaretMovedEventArgs e)
        {   //====================================================================
            if (_bInProgrammaticUIChange) return;
            _bInProgrammaticUIChange = true;

            rtePerform.SelectLine(rtePerform.InsertionRow);

            if (rtePerform.Lines.Length > 0 && ABC.IsLyrics(rtePerform.Lines[rtePerform.InsertionRow]))
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
            e.Handled = false;
            switch (e.KeyChar)
            {
                // No right and left, only up and down
                case (char)System.Windows.Forms.Keys.Right:
                    e.KeyChar = (char)System.Windows.Forms.Keys.Down;
                    break;
                case (char)System.Windows.Forms.Keys.Left:
                    e.KeyChar = (char)System.Windows.Forms.Keys.Up;
                    break;

                // Return means to play the line
                case (char)System.Windows.Forms.Keys.Return:
                    ReciteLine();
                    e.Handled = true;
                    break;
            }
            return;
        }

        private void OnPerformButton(object sender, EventArgs e)
        {   //====================================================================
            ReciteLine();
            return;
        }

        private void OnPerformTextPaneSizeChanged(object sender, EventArgs e)
        {   //====================================================================
            // For some reason, the Fill property isn't resizing the marked edit
            // control properly, so let's do it manually.
            rtePerform.Width= splitPerform.Panel2.Width;
            rtePerform.Height = splitPerform.Panel2.Height;
            return;
        }

        private void OnPlayNow(object sender, EventArgs e)
        {   //====================================================================
            PlaySong(Song.PlayType.Immediate);
            return;                                                               
        }

        private void OnPerformPlayAndRecite(object sender, EventArgs e)
        {   //====================================================================
            if (lstLyrics.Items.Count > 0) lstLyrics.SelectedIndex = 0;
            PlaySong(Song.PlayType.Immediate);
            ReciteLine();
            return;
        }

        private void OnPerformStopSong(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            RemoteController.ExecuteFunction("MusicEndSong");
            return;
        }

        private void OnPerformWaitToPlay(object sender, EventArgs e)
        {   //====================================================================
            PlaySong(Song.PlayType.Sync);
            return;                                                               

        }

        private void OnPerformStartGroup(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            RemoteController.SendText(Resources.StartSyncCommand);
            return;
        }

        private void OnPerformStartGroupAndRecite(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            if (lstLyrics.Items.Count > 0) lstLyrics.SelectedIndex = 0;
            RemoteController.SendText(Resources.StartSyncCommand);
            ReciteLine();
            return;
        }

        private void OnLyricListDblClick(object sender, EventArgs e)
        {//====================================================================
            ReciteLine();
            return;
        }

        private void OnLyricListKeyPress(object sender, KeyPressEventArgs e)
        {   //--------------------------------------------------------------------
            ReciteLine();
            return;
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
                Clipboard.SetText(((Song)lstFiles.SelectedItems[0].Tag).ShortName);
            }
            return;
        }

        private void OnSongListCopyFQFilename(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            if (lstFiles.SelectedItems.Count > 0)
            {
                Clipboard.SetText(((Song)lstFiles.SelectedItems[0].Tag).FileName);
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

        private void OnManageMacros(object sender, EventArgs e)
        {
            FormMacroManager fmm = new FormMacroManager();
            fmm.ShowDialog();
            return;
        }

    } // class

} // namespace