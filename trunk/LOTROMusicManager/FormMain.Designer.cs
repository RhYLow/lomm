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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.SplitContainer splitContainer1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
            System.Windows.Forms.MenuStrip menuStrip1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripMenuItem mniFileExit;
            System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lstFiles = new System.Windows.Forms.ListView();
            this.Title = new System.Windows.Forms.ColumnHeader();
            this.File = new System.Windows.Forms.ColumnHeader();
            this.mnuListContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniListContextPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mniListContextRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.txtABC = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnToggleMusicMode = new System.Windows.Forms.Button();
            this.btnPlay = new InstantUpdate.Controls.SplitButton();
            this.mnuPlay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniDDPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDDPlaySync = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDDStartSync = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mniNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSaveABC = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUndoAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniOpacity = new System.Windows.Forms.ToolStripComboBox();
            this.mniEditorFontSizeParent = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEditorFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBCQuickReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDances = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEmotes = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMoods = new System.Windows.Forms.ToolStripMenuItem();
            this.mniBestowals = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            mniFileExit = new System.Windows.Forms.ToolStripMenuItem();
            contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            this.mnuListContext.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            this.mnuPlay.SuspendLayout();
            menuStrip1.SuspendLayout();
            this.statPane.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new System.Drawing.Size(746, 618);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(3, 28);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(this.lstFiles);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(this.txtABC);
            splitContainer1.Size = new System.Drawing.Size(740, 527);
            splitContainer1.SplitterDistance = 227;
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
            this.lstFiles.Size = new System.Drawing.Size(740, 227);
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
            // txtABC
            // 
            this.txtABC.AcceptsReturn = true;
            this.txtABC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtABC.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtABC.Location = new System.Drawing.Point(0, 0);
            this.txtABC.Multiline = true;
            this.txtABC.Name = "txtABC";
            this.txtABC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtABC.Size = new System.Drawing.Size(740, 296);
            this.txtABC.TabIndex = 0;
            this.txtABC.WordWrap = false;
            this.txtABC.TextChanged += new System.EventHandler(this.OnABCChanged);
            this.txtABC.Click += new System.EventHandler(this.OnEditorClick);
            this.txtABC.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnEditorKeyUp);
            this.txtABC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnEditorKeyPress);
            this.txtABC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnEditorMouseUp);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            tableLayoutPanel2.Controls.Add(this.btnSave, 0, 0);
            tableLayoutPanel2.Controls.Add(this.btnUndo, 1, 0);
            tableLayoutPanel2.Controls.Add(this.btnToggleMusicMode, 2, 0);
            tableLayoutPanel2.Controls.Add(this.btnPlay, 3, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 561);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(740, 54);
            tableLayoutPanel2.TabIndex = 2;
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
            this.btnToggleMusicMode.Location = new System.Drawing.Point(518, 3);
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
            this.btnPlay.Location = new System.Drawing.Point(637, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(100, 28);
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
            this.mniDDPlaySync,
            this.mniDDStartSync});
            this.mnuPlay.Name = "mnuPlay";
            this.mnuPlay.ShowImageMargin = false;
            this.mnuPlay.Size = new System.Drawing.Size(113, 70);
            // 
            // mniDDPlay
            // 
            this.mniDDPlay.Name = "mniDDPlay";
            this.mniDDPlay.Size = new System.Drawing.Size(112, 22);
            this.mniDDPlay.Text = "&Play";
            this.mniDDPlay.Click += new System.EventHandler(this.OnDDPlay);
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
            this.mniEditorFontSizeParent});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // mniAlwaysOnTop
            // 
            this.mniAlwaysOnTop.CheckOnClick = true;
            this.mniAlwaysOnTop.Name = "mniAlwaysOnTop";
            this.mniAlwaysOnTop.Size = new System.Drawing.Size(155, 22);
            this.mniAlwaysOnTop.Text = "&Always on Top";
            this.mniAlwaysOnTop.Click += new System.EventHandler(this.OnToggleAOT);
            // 
            // opacityToolStripMenuItem
            // 
            this.opacityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniOpacity});
            this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            this.opacityToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
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
            this.mniEditorFontSizeParent.Size = new System.Drawing.Size(155, 22);
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
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mniDelete.Size = new System.Drawing.Size(242, 22);
            this.mniDelete.Text = "Delete";
            this.mniDelete.Click += new System.EventHandler(this.OnDeleteFile);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = global::LOTROMusicManager.Properties.Settings.Default.WindowSize;
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statPane);
            this.Controls.Add(tableLayoutPanel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::LOTROMusicManager.Properties.Settings.Default, "WindowLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::LOTROMusicManager.Properties.Settings.Default.WindowLocation;
            this.MainMenuStrip = menuStrip1;
            this.Name = "FormMain";
            this.Text = "LOTRO Music Manager";
            this.Load += new System.EventHandler(this.OnLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            tableLayoutPanel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            splitContainer1.ResumeLayout(false);
            this.mnuListContext.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            this.mnuPlay.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtABC;
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
    }
}

