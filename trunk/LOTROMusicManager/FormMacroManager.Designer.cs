namespace LotroMusicManager
{
    partial class FormMacroManager
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelMacro = new System.Windows.Forms.Button();
            this.btnNewMacro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvMacros = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.mnuMacroList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniEditMacroDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.imgMacros = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDelAction = new System.Windows.Forms.Button();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.lstActions = new System.Windows.Forms.ListBox();
            this.mnuActionList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.mnuActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.mnuMacroList.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.mnuActionList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(574, 526);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(568, 492);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lsvMacros, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(235, 492);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelMacro);
            this.panel2.Controls.Add(this.btnNewMacro);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 462);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 27);
            this.panel2.TabIndex = 0;
            // 
            // btnDelMacro
            // 
            this.btnDelMacro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelMacro.Image = global::LotroMusicManager.Properties.Resources.script_delete;
            this.btnDelMacro.Location = new System.Drawing.Point(38, 4);
            this.btnDelMacro.Name = "btnDelMacro";
            this.btnDelMacro.Size = new System.Drawing.Size(95, 23);
            this.btnDelMacro.TabIndex = 1;
            this.btnDelMacro.Text = "Delete Macro";
            this.btnDelMacro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelMacro.UseVisualStyleBackColor = true;
            this.btnDelMacro.Click += new System.EventHandler(this.OnDeleteMacro);
            // 
            // btnNewMacro
            // 
            this.btnNewMacro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewMacro.Image = global::LotroMusicManager.Properties.Resources.script_add;
            this.btnNewMacro.Location = new System.Drawing.Point(139, 4);
            this.btnNewMacro.Name = "btnNewMacro";
            this.btnNewMacro.Size = new System.Drawing.Size(87, 23);
            this.btnNewMacro.TabIndex = 0;
            this.btnNewMacro.Text = "New Macro";
            this.btnNewMacro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewMacro.UseVisualStyleBackColor = true;
            this.btnNewMacro.Click += new System.EventHandler(this.OnNewMacro);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Macros";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lsvMacros
            // 
            this.lsvMacros.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.lsvMacros.ContextMenuStrip = this.mnuMacroList;
            this.lsvMacros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvMacros.FullRowSelect = true;
            this.lsvMacros.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvMacros.Location = new System.Drawing.Point(3, 30);
            this.lsvMacros.MultiSelect = false;
            this.lsvMacros.Name = "lsvMacros";
            this.lsvMacros.ShowGroups = false;
            this.lsvMacros.Size = new System.Drawing.Size(229, 426);
            this.lsvMacros.SmallImageList = this.imgMacros;
            this.lsvMacros.TabIndex = 2;
            this.lsvMacros.UseCompatibleStateImageBehavior = false;
            this.lsvMacros.View = System.Windows.Forms.View.Details;
            this.lsvMacros.SelectedIndexChanged += new System.EventHandler(this.OnSelectedMacroChanged);
            // 
            // mnuMacroList
            // 
            this.mnuMacroList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMacroToolStripMenuItem,
            this.deleteMacroToolStripMenuItem,
            this.toolStripSeparator2,
            this.mniEditMacroDetails});
            this.mnuMacroList.Name = "mnuMacroList";
            this.mnuMacroList.Size = new System.Drawing.Size(179, 76);
            this.mnuMacroList.Opening += new System.ComponentModel.CancelEventHandler(this.OnMacroListMenuOpening);
            // 
            // newMacroToolStripMenuItem
            // 
            this.newMacroToolStripMenuItem.Image = global::LotroMusicManager.Properties.Resources.script_add;
            this.newMacroToolStripMenuItem.Name = "newMacroToolStripMenuItem";
            this.newMacroToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.newMacroToolStripMenuItem.Text = "New Macro";
            // 
            // deleteMacroToolStripMenuItem
            // 
            this.deleteMacroToolStripMenuItem.Image = global::LotroMusicManager.Properties.Resources.script_delete;
            this.deleteMacroToolStripMenuItem.Name = "deleteMacroToolStripMenuItem";
            this.deleteMacroToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.deleteMacroToolStripMenuItem.Text = "Delete Macro";
            this.deleteMacroToolStripMenuItem.Click += new System.EventHandler(this.OnDeleteMacro);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // mniEditMacroDetails
            // 
            this.mniEditMacroDetails.Image = global::LotroMusicManager.Properties.Resources.script_edit;
            this.mniEditMacroDetails.Name = "mniEditMacroDetails";
            this.mniEditMacroDetails.Size = new System.Drawing.Size(178, 22);
            this.mniEditMacroDetails.Text = "Edit Macro Details...";
            this.mniEditMacroDetails.Click += new System.EventHandler(this.OnEditMacroDetailsClick);
            // 
            // imgMacros
            // 
            this.imgMacros.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imgMacros.ImageSize = new System.Drawing.Size(16, 16);
            this.imgMacros.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lstActions, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(329, 492);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Actions in macro";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDelAction);
            this.panel3.Controls.Add(this.btnAddAction);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 464);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 25);
            this.panel3.TabIndex = 2;
            // 
            // btnDelAction
            // 
            this.btnDelAction.Image = global::LotroMusicManager.Properties.Resources.cog_delete;
            this.btnDelAction.Location = new System.Drawing.Point(122, 2);
            this.btnDelAction.Name = "btnDelAction";
            this.btnDelAction.Size = new System.Drawing.Size(99, 23);
            this.btnDelAction.TabIndex = 1;
            this.btnDelAction.Text = "Delete Action";
            this.btnDelAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelAction.UseVisualStyleBackColor = true;
            this.btnDelAction.Click += new System.EventHandler(this.OnDeleteAction);
            // 
            // btnAddAction
            // 
            this.btnAddAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAction.Image = global::LotroMusicManager.Properties.Resources.cog_add;
            this.btnAddAction.Location = new System.Drawing.Point(227, 3);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(90, 23);
            this.btnAddAction.TabIndex = 0;
            this.btnAddAction.Text = "Add Action";
            this.btnAddAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAction.UseVisualStyleBackColor = true;
            this.btnAddAction.Click += new System.EventHandler(this.OnNewAction);
            // 
            // lstActions
            // 
            this.lstActions.ContextMenuStrip = this.mnuActionList;
            this.lstActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstActions.FormattingEnabled = true;
            this.lstActions.HorizontalScrollbar = true;
            this.lstActions.Location = new System.Drawing.Point(3, 30);
            this.lstActions.Name = "lstActions";
            this.lstActions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstActions.Size = new System.Drawing.Size(323, 420);
            this.lstActions.TabIndex = 3;
            this.lstActions.DoubleClick += new System.EventHandler(this.OnDoubleClickAction);
            // 
            // mnuActionList
            // 
            this.mnuActionList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addActionToolStripMenuItem,
            this.editActionToolStripMenuItem,
            this.deleteActionToolStripMenuItem,
            this.toolStripSeparator1,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.mnuActionList.Name = "mnuActionList";
            this.mnuActionList.Size = new System.Drawing.Size(204, 120);
            this.mnuActionList.Opening += new System.ComponentModel.CancelEventHandler(this.OnActionListMenuOpening);
            // 
            // addActionToolStripMenuItem
            // 
            this.addActionToolStripMenuItem.Image = global::LotroMusicManager.Properties.Resources.cog_add;
            this.addActionToolStripMenuItem.Name = "addActionToolStripMenuItem";
            this.addActionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.addActionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.addActionToolStripMenuItem.Text = "Add Action";
            this.addActionToolStripMenuItem.Click += new System.EventHandler(this.OnNewAction);
            // 
            // editActionToolStripMenuItem
            // 
            this.editActionToolStripMenuItem.Image = global::LotroMusicManager.Properties.Resources.cog_edit;
            this.editActionToolStripMenuItem.Name = "editActionToolStripMenuItem";
            this.editActionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.editActionToolStripMenuItem.Text = "Edit Action";
            this.editActionToolStripMenuItem.Click += new System.EventHandler(this.OnDoubleClickAction);
            // 
            // deleteActionToolStripMenuItem
            // 
            this.deleteActionToolStripMenuItem.Image = global::LotroMusicManager.Properties.Resources.cog_delete;
            this.deleteActionToolStripMenuItem.Name = "deleteActionToolStripMenuItem";
            this.deleteActionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteActionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.deleteActionToolStripMenuItem.Text = "Delete Action";
            this.deleteActionToolStripMenuItem.Click += new System.EventHandler(this.OnDeleteAction);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Image = global::LotroMusicManager.Properties.Resources.arrow_up;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.OnMoveUp);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Image = global::LotroMusicManager.Properties.Resources.arrow_down;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.OnMoveDown);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(496, 501);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // mnuActions
            // 
            this.mnuActions.Name = "mnuActions";
            this.mnuActions.Size = new System.Drawing.Size(61, 4);
            // 
            // ofd
            // 
            this.ofd.Filter = "Images|*.png;*.gif;*.bmp;*.ico";
            // 
            // FormMacroManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 526);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMacroManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Macro Manager";
            this.Load += new System.EventHandler(this.OnLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.mnuMacroList.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.mnuActionList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelMacro;
        private System.Windows.Forms.Button btnNewMacro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDelAction;
        private System.Windows.Forms.Button btnAddAction;
        private System.Windows.Forms.ListBox lstActions;
        private System.Windows.Forms.ContextMenuStrip mnuMacroList;
        private System.Windows.Forms.ToolStripMenuItem newMacroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMacroToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnuActionList;
        private System.Windows.Forms.ToolStripMenuItem addActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnuActions;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvMacros;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ImageList imgMacros;
        private System.Windows.Forms.ToolStripMenuItem mniEditMacroDetails;

    }
}