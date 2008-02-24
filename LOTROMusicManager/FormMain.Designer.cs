namespace LOTROMusicManager
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.MenuStrip menuStrip1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripMenuItem mniFileExit;
            System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
            System.Windows.Forms.SplitContainer splitContainer1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.TableLayoutPanel layoutButtons;
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mniNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSaveABC = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUndoAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniOpacity = new System.Windows.Forms.ToolStripComboBox();
            this.mniEditorFontSizeParent = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEditorFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.resetAllSettingsToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBCQuickReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDances = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEmotes = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMoods = new System.Windows.Forms.ToolStripMenuItem();
            this.mniBestowals = new System.Windows.Forms.ToolStripMenuItem();
            this.lstFiles = new System.Windows.Forms.ListView();
            this.Title = new System.Windows.Forms.ColumnHeader();
            this.File = new System.Windows.Forms.ColumnHeader();
            this.mnuListContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniListContextPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mniListContextRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tabsMain = new System.Windows.Forms.TabControl();
            this.tpgEdit = new System.Windows.Forms.TabPage();
            this.rteEdit = new MarkedEditBox.RegexTaggedEdit();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnToggleMusicMode = new System.Windows.Forms.Button();
            this.btnPlay = new InstantUpdate.Controls.SplitButton();
            this.mnuPlay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniDDPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDDStopSong = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mniDDPlaySync = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDDStartSync = new System.Windows.Forms.ToolStripMenuItem();
            this.tpgPerform = new System.Windows.Forms.TabPage();
            this.rtePerform = new MarkedEditBox.RegexTaggedEdit();
            this.layoutPerformButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnPerform = new InstantUpdate.Controls.SplitButton();
            this.mnuPerform = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reciteLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.playSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playSongsayFirstLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.waitToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startGroupandSayFirstLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbReciteChannel = new System.Windows.Forms.ComboBox();
            this.tpgMyLotroBand = new System.Windows.Forms.TabPage();
            this.layoutMyLotroBand = new System.Windows.Forms.TableLayoutPanel();
            this.layoutMyLotroBandButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogin = new InstantUpdate.Controls.SplitButton();
            this.mnuMyLotroBandLogin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forgetLoginInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstMyLotroBand = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colArtist = new System.Windows.Forms.ColumnHeader();
            this.colParts = new System.Windows.Forms.ColumnHeader();
            this.colAddedBy = new System.Windows.Forms.ColumnHeader();
            this.colCreated = new System.Windows.Forms.ColumnHeader();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.dlgSaveAs = new System.Windows.Forms.SaveFileDialog();
            this.statPane = new System.Windows.Forms.StatusStrip();
            this.slEditLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            mniFileExit = new System.Windows.Forms.ToolStripMenuItem();
            contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            layoutButtons = new System.Windows.Forms.TableLayoutPanel();
            menuStrip1.SuspendLayout();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            this.mnuListContext.SuspendLayout();
            this.tabsMain.SuspendLayout();
            this.tpgEdit.SuspendLayout();
            layoutButtons.SuspendLayout();
            this.mnuPlay.SuspendLayout();
            this.tpgPerform.SuspendLayout();
            this.layoutPerformButtons.SuspendLayout();
            this.mnuPerform.SuspendLayout();
            this.tpgMyLotroBand.SuspendLayout();
            this.layoutMyLotroBand.SuspendLayout();
            this.layoutMyLotroBandButtons.SuspendLayout();
            this.mnuMyLotroBandLogin.SuspendLayout();
            this.statPane.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStripMenuItem1,
            this.mniDances,
            this.mniEmotes,
            this.mniMoods,
            this.mniBestowals});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(746, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniPlay,
            toolStripSeparator3,
            this.mniNew,
            this.mniSaveABC,
            this.mniSaveAs,
            this.mniDelete,
            this.mniUndoAll,
            toolStripSeparator2,
            this.mniRefresh,
            toolStripSeparator1,
            mniFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mniPlay
            // 
            this.mniPlay.Name = "mniPlay";
            this.mniPlay.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mniPlay.Size = new System.Drawing.Size(242, 22);
            this.mniPlay.Text = "&Play File";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(239, 6);
            // 
            // mniNew
            // 
            this.mniNew.Name = "mniNew";
            this.mniNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mniNew.Size = new System.Drawing.Size(242, 22);
            this.mniNew.Text = "&New";
            this.mniNew.Click += new System.EventHandler(this.OnFileNew);
            // 
            // mniSaveABC
            // 
            this.mniSaveABC.Enabled = false;
            this.mniSaveABC.Name = "mniSaveABC";
            this.mniSaveABC.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mniSaveABC.Size = new System.Drawing.Size(242, 22);
            this.mniSaveABC.Text = "&Save Changes";
            this.mniSaveABC.Click += new System.EventHandler(this.OnSaveABC);
            // 
            // mniSaveAs
            // 
            this.mniSaveAs.Name = "mniSaveAs";
            this.mniSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.A)));
            this.mniSaveAs.Size = new System.Drawing.Size(242, 22);
            this.mniSaveAs.Text = "Save &As";
            this.mniSaveAs.Click += new System.EventHandler(this.OnSaveAs);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mniDelete.Size = new System.Drawing.Size(242, 22);
            this.mniDelete.Text = "Delete";
            this.mniDelete.Click += new System.EventHandler(this.OnDeleteFile);
            // 
            // mniUndoAll
            // 
            this.mniUndoAll.Enabled = false;
            this.mniUndoAll.Name = "mniUndoAll";
            this.mniUndoAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.Z)));
            this.mniUndoAll.Size = new System.Drawing.Size(242, 22);
            this.mniUndoAll.Text = "&Undo All Changes";
            this.mniUndoAll.Click += new System.EventHandler(this.OnUndoAll);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(239, 6);
            // 
            // mniRefresh
            // 
            this.mniRefresh.Name = "mniRefresh";
            this.mniRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mniRefresh.Size = new System.Drawing.Size(242, 22);
            this.mniRefresh.Text = "Re&fresh File List";
            this.mniRefresh.Click += new System.EventHandler(this.OnRefresh);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // mniFileExit
            // 
            mniFileExit.Name = "mniFileExit";
            mniFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            mniFileExit.Size = new System.Drawing.Size(242, 22);
            mniFileExit.Text = "E&xit";
            mniFileExit.Click += new System.EventHandler(this.OnExit);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAlwaysOnTop,
            this.opacityToolStripMenuItem,
            this.mniEditorFontSizeParent,
            this.toolStripSeparator8,
            this.resetAllSettingsToDefaultToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // mniAlwaysOnTop
            // 
            this.mniAlwaysOnTop.CheckOnClick = true;
            this.mniAlwaysOnTop.Name = "mniAlwaysOnTop";
            this.mniAlwaysOnTop.Size = new System.Drawing.Size(215, 22);
            this.mniAlwaysOnTop.Text = "&Always on Top";
            this.mniAlwaysOnTop.Click += new System.EventHandler(this.OnToggleAOT);
            // 
            // opacityToolStripMenuItem
            // 
            this.opacityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniOpacity});
            this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            this.opacityToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.opacityToolStripMenuItem.Text = "&Opacity";
            // 
            // mniOpacity
            // 
            this.mniOpacity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mniOpacity.Items.AddRange(new object[] {
            "100",
            "90",
            "80",
            "70",
            "60",
            "50",
            "40",
            "30"});
            this.mniOpacity.Name = "mniOpacity";
            this.mniOpacity.Size = new System.Drawing.Size(121, 23);
            this.mniOpacity.SelectedIndexChanged += new System.EventHandler(this.OnOpacityChanged);
            // 
            // mniEditorFontSizeParent
            // 
            this.mniEditorFontSizeParent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniEditorFontSize});
            this.mniEditorFontSizeParent.Name = "mniEditorFontSizeParent";
            this.mniEditorFontSizeParent.Size = new System.Drawing.Size(215, 22);
            this.mniEditorFontSizeParent.Text = "Editor Font Si&ze";
            // 
            // mniEditorFontSize
            // 
            this.mniEditorFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mniEditorFontSize.Items.AddRange(new object[] {
            "8",
            "10",
            "12",
            "14",
            "16"});
            this.mniEditorFontSize.Name = "mniEditorFontSize";
            this.mniEditorFontSize.Size = new System.Drawing.Size(121, 23);
            this.mniEditorFontSize.SelectedIndexChanged += new System.EventHandler(this.OnFontSizeChanged);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(212, 6);
            // 
            // resetAllSettingsToDefaultToolStripMenuItem
            // 
            this.resetAllSettingsToDefaultToolStripMenuItem.Name = "resetAllSettingsToDefaultToolStripMenuItem";
            this.resetAllSettingsToDefaultToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.resetAllSettingsToDefaultToolStripMenuItem.Text = "Reset all settings to default";
            this.resetAllSettingsToDefaultToolStripMenuItem.Click += new System.EventHandler(this.OnResetSettings);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            contentsToolStripMenuItem,
            this.aBCQuickReferenceToolStripMenuItem,
            this.toolStripSeparator4,
            aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            contentsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            contentsToolStripMenuItem.Text = "Contents";
            // 
            // aBCQuickReferenceToolStripMenuItem
            // 
            this.aBCQuickReferenceToolStripMenuItem.Name = "aBCQuickReferenceToolStripMenuItem";
            this.aBCQuickReferenceToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.aBCQuickReferenceToolStripMenuItem.Text = "ABC Quick Reference...";
            this.aBCQuickReferenceToolStripMenuItem.Click += new System.EventHandler(this.OnQuickReference);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(192, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            aboutToolStripMenuItem.Text = "&About...";
            aboutToolStripMenuItem.Click += new System.EventHandler(this.OnHelpAbout);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = " ";
            // 
            // mniDances
            // 
            this.mniDances.Checked = true;
            this.mniDances.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.mniDances.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mniDances.Name = "mniDances";
            this.mniDances.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.mniDances.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mniDances.ShowShortcutKeys = false;
            this.mniDances.Size = new System.Drawing.Size(53, 20);
            this.mniDances.Text = "Dances";
            // 
            // mniEmotes
            // 
            this.mniEmotes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mniEmotes.Name = "mniEmotes";
            this.mniEmotes.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.mniEmotes.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mniEmotes.ShowShortcutKeys = false;
            this.mniEmotes.Size = new System.Drawing.Size(54, 20);
            this.mniEmotes.Text = "Emotes";
            // 
            // mniMoods
            // 
            this.mniMoods.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mniMoods.Name = "mniMoods";
            this.mniMoods.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mniMoods.Size = new System.Drawing.Size(52, 20);
            this.mniMoods.Text = "Moods";
            // 
            // mniBestowals
            // 
            this.mniBestowals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mniBestowals.Name = "mniBestowals";
            this.mniBestowals.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.mniBestowals.Size = new System.Drawing.Size(71, 20);
            this.mniBestowals.Text = "Bestowals";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 22);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(this.lstFiles);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(this.tabsMain);
            splitContainer1.Size = new System.Drawing.Size(746, 574);
            splitContainer1.SplitterDistance = 247;
            splitContainer1.TabIndex = 1;
            // 
            // lstFiles
            // 
            this.lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.File});
            this.lstFiles.ContextMenuStrip = this.mnuListContext;
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.FullRowSelect = true;
            this.lstFiles.HideSelection = false;
            this.lstFiles.Location = new System.Drawing.Point(0, 0);
            this.lstFiles.MultiSelect = false;
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.ShowItemToolTips = true;
            this.lstFiles.Size = new System.Drawing.Size(746, 247);
            this.lstFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstFiles.TabIndex = 0;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Details;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.OnFileSelect);
            this.lstFiles.DoubleClick += new System.EventHandler(this.OnFileDoubleClick);
            this.lstFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnColumnClick);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            // 
            // File
            // 
            this.File.Text = "File";
            // 
            // mnuListContext
            // 
            this.mnuListContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniListContextPlay,
            this.mniListContextRefresh});
            this.mnuListContext.Name = "mnuListContext";
            this.mnuListContext.Size = new System.Drawing.Size(114, 48);
            // 
            // mniListContextPlay
            // 
            this.mniListContextPlay.Name = "mniListContextPlay";
            this.mniListContextPlay.Size = new System.Drawing.Size(113, 22);
            this.mniListContextPlay.Text = "Play";
            this.mniListContextPlay.Click += new System.EventHandler(this.OnPlay);
            // 
            // mniListContextRefresh
            // 
            this.mniListContextRefresh.Name = "mniListContextRefresh";
            this.mniListContextRefresh.Size = new System.Drawing.Size(113, 22);
            this.mniListContextRefresh.Text = "Refresh";
            this.mniListContextRefresh.Click += new System.EventHandler(this.OnRefresh);
            // 
            // tabsMain
            // 
            this.tabsMain.Controls.Add(this.tpgEdit);
            this.tabsMain.Controls.Add(this.tpgPerform);
            this.tabsMain.Controls.Add(this.tpgMyLotroBand);
            this.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsMain.Location = new System.Drawing.Point(0, 0);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(746, 323);
            this.tabsMain.TabIndex = 1;
            // 
            // tpgEdit
            // 
            this.tpgEdit.Controls.Add(this.rteEdit);
            this.tpgEdit.Controls.Add(layoutButtons);
            this.tpgEdit.Location = new System.Drawing.Point(4, 22);
            this.tpgEdit.Name = "tpgEdit";
            this.tpgEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tpgEdit.Size = new System.Drawing.Size(738, 297);
            this.tpgEdit.TabIndex = 0;
            this.tpgEdit.Text = "Edit";
            this.tpgEdit.UseVisualStyleBackColor = true;
            // 
            // rteEdit
            // 
            this.rteEdit.AutoTag = true;
            this.rteEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rteEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rteEdit.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rteEdit.HoverDelay = 1500;
            this.rteEdit.InsertionCol = 0;
            this.rteEdit.InsertionRow = 0;
            this.rteEdit.Location = new System.Drawing.Point(3, 3);
            this.rteEdit.Name = "rteEdit";
            this.rteEdit.Size = new System.Drawing.Size(732, 256);
            this.rteEdit.TabIndex = 3;
            this.rteEdit.Tags = new MarkedEditBox.RegexTag[] {
        ((MarkedEditBox.RegexTag)(resources.GetObject("rteEdit.Tags"))),
        ((MarkedEditBox.RegexTag)(resources.GetObject("rteEdit.Tags1"))),
        ((MarkedEditBox.RegexTag)(resources.GetObject("rteEdit.Tags2"))),
        ((MarkedEditBox.RegexTag)(resources.GetObject("rteEdit.Tags3"))),
        ((MarkedEditBox.RegexTag)(resources.GetObject("rteEdit.Tags4"))),
        ((MarkedEditBox.RegexTag)(resources.GetObject("rteEdit.Tags5"))),
        ((MarkedEditBox.RegexTag)(resources.GetObject("rteEdit.Tags6"))),
        ((MarkedEditBox.RegexTag)(resources.GetObject("rteEdit.Tags7")))};
            this.rteEdit.Text = "";
            this.rteEdit.WordWrap = false;
            this.rteEdit.CaretMoved += new System.EventHandler<MarkedEditBox.CaretMovedEventArgs>(this.OnCaretMoved);
            // 
            // layoutButtons
            // 
            layoutButtons.ColumnCount = 4;
            layoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            layoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            layoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            layoutButtons.Controls.Add(this.btnSave, 0, 0);
            layoutButtons.Controls.Add(this.btnUndo, 1, 0);
            layoutButtons.Controls.Add(this.btnToggleMusicMode, 2, 0);
            layoutButtons.Controls.Add(this.btnPlay, 3, 0);
            layoutButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            layoutButtons.Location = new System.Drawing.Point(3, 259);
            layoutButtons.Name = "layoutButtons";
            layoutButtons.RowCount = 1;
            layoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            layoutButtons.Size = new System.Drawing.Size(732, 35);
            layoutButtons.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save ABC";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnSaveABC);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(83, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(111, 28);
            this.btnUndo.TabIndex = 2;
            this.btnUndo.Text = "Undo All Changes";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.OnUndoAll);
            // 
            // btnToggleMusicMode
            // 
            this.btnToggleMusicMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleMusicMode.Location = new System.Drawing.Point(510, 3);
            this.btnToggleMusicMode.Name = "btnToggleMusicMode";
            this.btnToggleMusicMode.Size = new System.Drawing.Size(94, 28);
            this.btnToggleMusicMode.TabIndex = 5;
            this.btnToggleMusicMode.Text = "Toggle /music";
            this.btnToggleMusicMode.UseVisualStyleBackColor = true;
            this.btnToggleMusicMode.Click += new System.EventHandler(this.OnToggleMusicMode);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.AutoSize = true;
            this.btnPlay.ContextMenuStrip = this.mnuPlay;
            this.btnPlay.Location = new System.Drawing.Point(629, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(100, 27);
            this.btnPlay.SplitMenu = this.mnuPlay;
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.OnPlay);
            // 
            // mnuPlay
            // 
            this.mnuPlay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniDDPlay,
            this.mniDDStopSong,
            this.toolStripSeparator5,
            this.mniDDPlaySync,
            this.mniDDStartSync});
            this.mnuPlay.Name = "mnuPlay";
            this.mnuPlay.ShowImageMargin = false;
            this.mnuPlay.Size = new System.Drawing.Size(113, 98);
            // 
            // mniDDPlay
            // 
            this.mniDDPlay.Name = "mniDDPlay";
            this.mniDDPlay.Size = new System.Drawing.Size(112, 22);
            this.mniDDPlay.Text = "&Play";
            this.mniDDPlay.Click += new System.EventHandler(this.OnDDPlay);
            // 
            // mniDDStopSong
            // 
            this.mniDDStopSong.Name = "mniDDStopSong";
            this.mniDDStopSong.Size = new System.Drawing.Size(112, 22);
            this.mniDDStopSong.Text = "Stop Song";
            this.mniDDStopSong.Click += new System.EventHandler(this.OnDDStopSong);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(109, 6);
            // 
            // mniDDPlaySync
            // 
            this.mniDDPlaySync.Name = "mniDDPlaySync";
            this.mniDDPlaySync.Size = new System.Drawing.Size(112, 22);
            this.mniDDPlaySync.Text = "&Wait to play";
            this.mniDDPlaySync.Click += new System.EventHandler(this.OnDDWaitToPlay);
            // 
            // mniDDStartSync
            // 
            this.mniDDStartSync.Name = "mniDDStartSync";
            this.mniDDStartSync.Size = new System.Drawing.Size(112, 22);
            this.mniDDStartSync.Text = "&Start group";
            this.mniDDStartSync.Click += new System.EventHandler(this.OnDDStartSyncPlay);
            // 
            // tpgPerform
            // 
            this.tpgPerform.Controls.Add(this.rtePerform);
            this.tpgPerform.Controls.Add(this.layoutPerformButtons);
            this.tpgPerform.Location = new System.Drawing.Point(4, 22);
            this.tpgPerform.Name = "tpgPerform";
            this.tpgPerform.Padding = new System.Windows.Forms.Padding(3);
            this.tpgPerform.Size = new System.Drawing.Size(738, 297);
            this.tpgPerform.TabIndex = 1;
            this.tpgPerform.Text = "Perform";
            this.tpgPerform.UseVisualStyleBackColor = true;
            // 
            // rtePerform
            // 
            this.rtePerform.AutoTag = true;
            this.rtePerform.AutoWordSelection = true;
            this.rtePerform.BackColor = System.Drawing.SystemColors.Window;
            this.rtePerform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtePerform.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtePerform.ForeColor = System.Drawing.Color.Gray;
            this.rtePerform.HideSelection = false;
            this.rtePerform.HoverDelay = 1500;
            this.rtePerform.InsertionCol = 0;
            this.rtePerform.InsertionRow = 0;
            this.rtePerform.Location = new System.Drawing.Point(3, 3);
            this.rtePerform.Name = "rtePerform";
            this.rtePerform.ReadOnly = true;
            this.rtePerform.ShowSelectionMargin = true;
            this.rtePerform.Size = new System.Drawing.Size(732, 256);
            this.rtePerform.TabIndex = 1;
            this.rtePerform.Tags = new MarkedEditBox.RegexTag[] {
        ((MarkedEditBox.RegexTag)(resources.GetObject("rtePerform.Tags"))),
        ((MarkedEditBox.RegexTag)(resources.GetObject("rtePerform.Tags1")))};
            this.rtePerform.Text = "";
            this.rtePerform.WordWrap = false;
            this.rtePerform.CaretMoved += new System.EventHandler<MarkedEditBox.CaretMovedEventArgs>(this.OnPerformCaretMoved);
            // 
            // layoutPerformButtons
            // 
            this.layoutPerformButtons.ColumnCount = 4;
            this.layoutPerformButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPerformButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPerformButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.layoutPerformButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.layoutPerformButtons.Controls.Add(this.btnPerform, 3, 0);
            this.layoutPerformButtons.Controls.Add(this.cmbReciteChannel, 0, 0);
            this.layoutPerformButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutPerformButtons.Location = new System.Drawing.Point(3, 259);
            this.layoutPerformButtons.Name = "layoutPerformButtons";
            this.layoutPerformButtons.RowCount = 1;
            this.layoutPerformButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPerformButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.layoutPerformButtons.Size = new System.Drawing.Size(732, 35);
            this.layoutPerformButtons.TabIndex = 0;
            // 
            // btnPerform
            // 
            this.btnPerform.AutoSize = true;
            this.btnPerform.ContextMenuStrip = this.mnuPerform;
            this.btnPerform.Location = new System.Drawing.Point(614, 3);
            this.btnPerform.Name = "btnPerform";
            this.btnPerform.Size = new System.Drawing.Size(100, 27);
            this.btnPerform.SplitMenu = this.mnuPerform;
            this.btnPerform.TabIndex = 0;
            this.btnPerform.Text = "Recite Line";
            this.btnPerform.UseVisualStyleBackColor = true;
            // 
            // mnuPerform
            // 
            this.mnuPerform.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reciteLineToolStripMenuItem,
            this.toolStripSeparator7,
            this.playSongToolStripMenuItem,
            this.playSongsayFirstLineToolStripMenuItem,
            this.stopSongToolStripMenuItem,
            this.toolStripSeparator6,
            this.waitToPlayToolStripMenuItem,
            this.startGroupToolStripMenuItem,
            this.startGroupandSayFirstLineToolStripMenuItem});
            this.mnuPerform.Name = "mnuPerform";
            this.mnuPerform.Size = new System.Drawing.Size(231, 170);
            // 
            // reciteLineToolStripMenuItem
            // 
            this.reciteLineToolStripMenuItem.Name = "reciteLineToolStripMenuItem";
            this.reciteLineToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.reciteLineToolStripMenuItem.Text = "Recite Line";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(227, 6);
            // 
            // playSongToolStripMenuItem
            // 
            this.playSongToolStripMenuItem.Name = "playSongToolStripMenuItem";
            this.playSongToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.playSongToolStripMenuItem.Text = "Play Song";
            // 
            // playSongsayFirstLineToolStripMenuItem
            // 
            this.playSongsayFirstLineToolStripMenuItem.Name = "playSongsayFirstLineToolStripMenuItem";
            this.playSongsayFirstLineToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.playSongsayFirstLineToolStripMenuItem.Text = "Play Song (and say first line)";
            // 
            // stopSongToolStripMenuItem
            // 
            this.stopSongToolStripMenuItem.Name = "stopSongToolStripMenuItem";
            this.stopSongToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.stopSongToolStripMenuItem.Text = "Stop Song";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(227, 6);
            // 
            // waitToPlayToolStripMenuItem
            // 
            this.waitToPlayToolStripMenuItem.Name = "waitToPlayToolStripMenuItem";
            this.waitToPlayToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.waitToPlayToolStripMenuItem.Text = "Wait to Play";
            // 
            // startGroupToolStripMenuItem
            // 
            this.startGroupToolStripMenuItem.Name = "startGroupToolStripMenuItem";
            this.startGroupToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.startGroupToolStripMenuItem.Text = "Start Group";
            // 
            // startGroupandSayFirstLineToolStripMenuItem
            // 
            this.startGroupandSayFirstLineToolStripMenuItem.Name = "startGroupandSayFirstLineToolStripMenuItem";
            this.startGroupandSayFirstLineToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.startGroupandSayFirstLineToolStripMenuItem.Text = "Start Group (and say first line)";
            // 
            // cmbReciteChannel
            // 
            this.cmbReciteChannel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbReciteChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReciteChannel.FormattingEnabled = true;
            this.cmbReciteChannel.Items.AddRange(new object[] {
            "/say",
            "/f",
            "/ra",
            "/rpc",
            "/region"});
            this.cmbReciteChannel.Location = new System.Drawing.Point(3, 7);
            this.cmbReciteChannel.Name = "cmbReciteChannel";
            this.cmbReciteChannel.Size = new System.Drawing.Size(121, 21);
            this.cmbReciteChannel.TabIndex = 1;
            // 
            // tpgMyLotroBand
            // 
            this.tpgMyLotroBand.Controls.Add(this.layoutMyLotroBand);
            this.tpgMyLotroBand.Location = new System.Drawing.Point(4, 22);
            this.tpgMyLotroBand.Name = "tpgMyLotroBand";
            this.tpgMyLotroBand.Padding = new System.Windows.Forms.Padding(3);
            this.tpgMyLotroBand.Size = new System.Drawing.Size(738, 297);
            this.tpgMyLotroBand.TabIndex = 2;
            this.tpgMyLotroBand.Text = "MyLotroBand";
            this.tpgMyLotroBand.UseVisualStyleBackColor = true;
            // 
            // layoutMyLotroBand
            // 
            this.layoutMyLotroBand.ColumnCount = 1;
            this.layoutMyLotroBand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMyLotroBand.Controls.Add(this.layoutMyLotroBandButtons, 0, 1);
            this.layoutMyLotroBand.Controls.Add(this.lstMyLotroBand, 0, 0);
            this.layoutMyLotroBand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMyLotroBand.Location = new System.Drawing.Point(3, 3);
            this.layoutMyLotroBand.Name = "layoutMyLotroBand";
            this.layoutMyLotroBand.RowCount = 2;
            this.layoutMyLotroBand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMyLotroBand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.layoutMyLotroBand.Size = new System.Drawing.Size(732, 291);
            this.layoutMyLotroBand.TabIndex = 2;
            // 
            // layoutMyLotroBandButtons
            // 
            this.layoutMyLotroBandButtons.ColumnCount = 5;
            this.layoutMyLotroBandButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.8297F));
            this.layoutMyLotroBandButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.170305F));
            this.layoutMyLotroBandButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.layoutMyLotroBandButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.layoutMyLotroBandButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.layoutMyLotroBandButtons.Controls.Add(this.btnLogin, 0, 0);
            this.layoutMyLotroBandButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutMyLotroBandButtons.Location = new System.Drawing.Point(3, 259);
            this.layoutMyLotroBandButtons.Name = "layoutMyLotroBandButtons";
            this.layoutMyLotroBandButtons.RowCount = 1;
            this.layoutMyLotroBandButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutMyLotroBandButtons.Size = new System.Drawing.Size(726, 29);
            this.layoutMyLotroBandButtons.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLogin.AutoSize = true;
            this.btnLogin.ContextMenuStrip = this.mnuMyLotroBandLogin;
            this.btnLogin.Location = new System.Drawing.Point(3, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(103, 23);
            this.btnLogin.SplitMenu = this.mnuMyLotroBandLogin;
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Get Song List";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.OnMyLotroBandLogin);
            // 
            // mnuMyLotroBandLogin
            // 
            this.mnuMyLotroBandLogin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.forgetLoginInformationToolStripMenuItem});
            this.mnuMyLotroBandLogin.Name = "mnuMyLotroBandLogin";
            this.mnuMyLotroBandLogin.Size = new System.Drawing.Size(208, 48);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.loginToolStripMenuItem.Text = "Get Song List";
            // 
            // forgetLoginInformationToolStripMenuItem
            // 
            this.forgetLoginInformationToolStripMenuItem.Name = "forgetLoginInformationToolStripMenuItem";
            this.forgetLoginInformationToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.forgetLoginInformationToolStripMenuItem.Text = "Forget Login Information";
            this.forgetLoginInformationToolStripMenuItem.Click += new System.EventHandler(this.OnMyLotroBandForgetLoginInformation);
            // 
            // lstMyLotroBand
            // 
            this.lstMyLotroBand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colArtist,
            this.colParts,
            this.colAddedBy,
            this.colCreated});
            this.lstMyLotroBand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMyLotroBand.FullRowSelect = true;
            this.lstMyLotroBand.Location = new System.Drawing.Point(3, 3);
            this.lstMyLotroBand.Name = "lstMyLotroBand";
            this.lstMyLotroBand.Size = new System.Drawing.Size(726, 250);
            this.lstMyLotroBand.TabIndex = 0;
            this.lstMyLotroBand.UseCompatibleStateImageBehavior = false;
            this.lstMyLotroBand.View = System.Windows.Forms.View.Details;
            this.lstMyLotroBand.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnColumnClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colArtist
            // 
            this.colArtist.Text = "Artist";
            // 
            // colParts
            // 
            this.colParts.Text = "Parts";
            // 
            // colAddedBy
            // 
            this.colAddedBy.Text = "Added By";
            // 
            // colCreated
            // 
            this.colCreated.Text = "Added On";
            this.colCreated.Width = 123;
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.Filter = "Music Files|*.abc|All Files|*.*";
            this.dlgOpenFile.RestoreDirectory = true;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Size = new System.Drawing.Size(746, 593);
            // 
            // dlgSaveAs
            // 
            this.dlgSaveAs.DefaultExt = "abc";
            this.dlgSaveAs.RestoreDirectory = true;
            this.dlgSaveAs.Title = "Save Music File";
            // 
            // statPane
            // 
            this.statPane.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slEditLocation});
            this.statPane.Location = new System.Drawing.Point(0, 596);
            this.statPane.Name = "statPane";
            this.statPane.Size = new System.Drawing.Size(746, 22);
            this.statPane.TabIndex = 1;
            this.statPane.Text = "statusStrip1";
            // 
            // slEditLocation
            // 
            this.slEditLocation.Name = "slEditLocation";
            this.slEditLocation.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(746, 0);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(746, 22);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Location = new System.Drawing.Point(3, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(111, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = global::LOTROMusicManager.Properties.Settings.Default.WindowSize;
            this.Controls.Add(splitContainer1);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statPane);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::LOTROMusicManager.Properties.Settings.Default, "WindowLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::LOTROMusicManager.Properties.Settings.Default.WindowLocation;
            this.MainMenuStrip = menuStrip1;
            this.Name = "FormMain";
            this.Text = "LOTRO Music Manager";
            this.Load += new System.EventHandler(this.OnLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.ResumeLayout(false);
            this.mnuListContext.ResumeLayout(false);
            this.tabsMain.ResumeLayout(false);
            this.tpgEdit.ResumeLayout(false);
            layoutButtons.ResumeLayout(false);
            layoutButtons.PerformLayout();
            this.mnuPlay.ResumeLayout(false);
            this.tpgPerform.ResumeLayout(false);
            this.layoutPerformButtons.ResumeLayout(false);
            this.layoutPerformButtons.PerformLayout();
            this.mnuPerform.ResumeLayout(false);
            this.tpgMyLotroBand.ResumeLayout(false);
            this.layoutMyLotroBand.ResumeLayout(false);
            this.layoutMyLotroBandButtons.ResumeLayout(false);
            this.layoutMyLotroBandButtons.PerformLayout();
            this.mnuMyLotroBandLogin.ResumeLayout(false);
            this.statPane.ResumeLayout(false);
            this.statPane.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.SaveFileDialog dlgSaveAs;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.StatusStrip statPane;
        private System.Windows.Forms.ToolStripStatusLabel slEditLocation;
        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnToggleMusicMode;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniPlay;
        private System.Windows.Forms.ToolStripMenuItem mniNew;
        private System.Windows.Forms.ToolStripMenuItem mniSaveABC;
        private System.Windows.Forms.ToolStripMenuItem mniSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mniUndoAll;
        private System.Windows.Forms.ToolStripMenuItem mniRefresh;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniAlwaysOnTop;
        private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox mniOpacity;
        private System.Windows.Forms.ToolStripMenuItem mniEditorFontSizeParent;
        private System.Windows.Forms.ToolStripComboBox mniEditorFontSize;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mniDances;
        private System.Windows.Forms.ToolStripMenuItem mniEmotes;
        private System.Windows.Forms.ToolStripMenuItem mniMoods;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ContextMenuStrip mnuListContext;
        private System.Windows.Forms.ToolStripMenuItem mniListContextPlay;
        private System.Windows.Forms.ToolStripMenuItem mniListContextRefresh;
        private System.Windows.Forms.ToolStripMenuItem aBCQuickReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniBestowals;
        private InstantUpdate.Controls.SplitButton btnPlay;
        private System.Windows.Forms.ContextMenuStrip mnuPlay;
        private System.Windows.Forms.ToolStripMenuItem mniDDPlay;
        private System.Windows.Forms.ToolStripMenuItem mniDDPlaySync;
        private System.Windows.Forms.ToolStripMenuItem mniDDStartSync;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.ToolStripMenuItem mniDDStopSong;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TabControl tabsMain;
        private System.Windows.Forms.TabPage tpgEdit;
        private System.Windows.Forms.TabPage tpgPerform;
        private MarkedEditBox.RegexTaggedEdit rtePerform;
        private System.Windows.Forms.TableLayoutPanel layoutPerformButtons;
        private InstantUpdate.Controls.SplitButton btnPerform;
        private System.Windows.Forms.ContextMenuStrip mnuPerform;
        private System.Windows.Forms.ToolStripMenuItem playSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playSongsayFirstLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem waitToPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startGroupandSayFirstLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reciteLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private MarkedEditBox.RegexTaggedEdit rteEdit;
        private System.Windows.Forms.ComboBox cmbReciteChannel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem resetAllSettingsToDefaultToolStripMenuItem;
        private System.Windows.Forms.TabPage tpgMyLotroBand;
        private System.Windows.Forms.ListView lstMyLotroBand;
        public System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.TableLayoutPanel layoutMyLotroBandButtons;
        private System.Windows.Forms.ColumnHeader colArtist;
        private System.Windows.Forms.ColumnHeader colParts;
        private System.Windows.Forms.ColumnHeader colAddedBy;
        private System.Windows.Forms.ColumnHeader colCreated;
        private System.Windows.Forms.TableLayoutPanel layoutMyLotroBand;
        private InstantUpdate.Controls.SplitButton btnLogin;
        private System.Windows.Forms.ContextMenuStrip mnuMyLotroBandLogin;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forgetLoginInformationToolStripMenuItem;
    }
}

