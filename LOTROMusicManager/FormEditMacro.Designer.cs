namespace LotroMusicManager
{
    partial class FormEditMacro
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
            System.Windows.Forms.Button btnOK;
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "act1",
            "act details",
            ""}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditMacro));
            this.tableEditEmote = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mnuLOTROCommands2 = new System.Windows.Forms.MenuStrip();
            this.lstEmoteEditor = new System.Windows.Forms.ListView();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colText = new System.Windows.Forms.ColumnHeader();
            this.toolsEmoteEditor = new System.Windows.Forms.ToolStrip();
            this.lblMacroName = new System.Windows.Forms.ToolStripLabel();
            this.txtMacroName = new System.Windows.Forms.ToolStripTextBox();
            this.btnMoveUp = new System.Windows.Forms.ToolStripButton();
            this.btnMoveDown = new System.Windows.Forms.ToolStripButton();
            this.btnAddItem = new System.Windows.Forms.ToolStripButton();
            this.btnEditItem = new System.Windows.Forms.ToolStripButton();
            this.btnDelItem = new System.Windows.Forms.ToolStripButton();
            this.txtActionDetails = new System.Windows.Forms.TextBox();
            this.cmbActionType = new System.Windows.Forms.ComboBox();
            this.mnuActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            btnOK = new System.Windows.Forms.Button();
            this.tableEditEmote.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolsEmoteEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(410, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(75, 1);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // tableEditEmote
            // 
            this.tableEditEmote.ColumnCount = 1;
            this.tableEditEmote.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableEditEmote.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableEditEmote.Controls.Add(this.lstEmoteEditor, 0, 1);
            this.tableEditEmote.Controls.Add(this.toolsEmoteEditor, 0, 0);
            this.tableEditEmote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableEditEmote.Location = new System.Drawing.Point(0, 0);
            this.tableEditEmote.Name = "tableEditEmote";
            this.tableEditEmote.RowCount = 3;
            this.tableEditEmote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableEditEmote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableEditEmote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableEditEmote.Size = new System.Drawing.Size(494, 426);
            this.tableEditEmote.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.Controls.Add(btnOK, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mnuLOTROCommands2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 392);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 31);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(326, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 1);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // mnuLOTROCommands2
            // 
            this.mnuLOTROCommands2.Location = new System.Drawing.Point(0, 0);
            this.mnuLOTROCommands2.Name = "mnuLOTROCommands2";
            this.mnuLOTROCommands2.Size = new System.Drawing.Size(404, 24);
            this.mnuLOTROCommands2.TabIndex = 2;
            this.mnuLOTROCommands2.Text = "menuStrip1";
            // 
            // lstEmoteEditor
            // 
            this.lstEmoteEditor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colType,
            this.colText});
            this.lstEmoteEditor.FullRowSelect = true;
            this.lstEmoteEditor.GridLines = true;
            this.lstEmoteEditor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstEmoteEditor.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstEmoteEditor.Location = new System.Drawing.Point(3, 28);
            this.lstEmoteEditor.MultiSelect = false;
            this.lstEmoteEditor.Name = "lstEmoteEditor";
            this.lstEmoteEditor.ShowItemToolTips = true;
            this.lstEmoteEditor.Size = new System.Drawing.Size(198, 227);
            this.lstEmoteEditor.TabIndex = 2;
            this.lstEmoteEditor.UseCompatibleStateImageBehavior = false;
            this.lstEmoteEditor.View = System.Windows.Forms.View.Details;
            // 
            // colType
            // 
            this.colType.Text = "Action";
            this.colType.Width = 101;
            // 
            // colText
            // 
            this.colText.Text = "Details";
            this.colText.Width = 222;
            // 
            // toolsEmoteEditor
            // 
            this.toolsEmoteEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMacroName,
            this.txtMacroName,
            this.btnMoveUp,
            this.btnMoveDown,
            this.btnAddItem,
            this.btnEditItem,
            this.btnDelItem});
            this.toolsEmoteEditor.Location = new System.Drawing.Point(0, 0);
            this.toolsEmoteEditor.Name = "toolsEmoteEditor";
            this.toolsEmoteEditor.Size = new System.Drawing.Size(494, 25);
            this.toolsEmoteEditor.TabIndex = 3;
            this.toolsEmoteEditor.Text = "toolStrip1";
            // 
            // lblMacroName
            // 
            this.lblMacroName.Name = "lblMacroName";
            this.lblMacroName.Size = new System.Drawing.Size(79, 22);
            this.lblMacroName.Text = "Emote Name:";
            // 
            // txtMacroName
            // 
            this.txtMacroName.Name = "txtMacroName";
            this.txtMacroName.Size = new System.Drawing.Size(100, 25);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(23, 22);
            this.btnMoveUp.Text = "Move Up";
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(23, 22);
            this.btnMoveDown.Text = "Move Down";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(23, 22);
            this.btnAddItem.Text = "New Action";
            this.btnAddItem.Click += new System.EventHandler(this.OnAddActionItem);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditItem.Image = ((System.Drawing.Image)(resources.GetObject("btnEditItem.Image")));
            this.btnEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(23, 22);
            this.btnEditItem.Text = "Edit Action";
            // 
            // btnDelItem
            // 
            this.btnDelItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDelItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDelItem.Image")));
            this.btnDelItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelItem.Name = "btnDelItem";
            this.btnDelItem.Size = new System.Drawing.Size(23, 22);
            this.btnDelItem.Text = "Delete Action";
            // 
            // txtActionDetails
            // 
            this.txtActionDetails.Location = new System.Drawing.Point(190, 425);
            this.txtActionDetails.Name = "txtActionDetails";
            this.txtActionDetails.Size = new System.Drawing.Size(24, 20);
            this.txtActionDetails.TabIndex = 5;
            this.txtActionDetails.Visible = false;
            // 
            // cmbActionType
            // 
            this.cmbActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionType.FormattingEnabled = true;
            this.cmbActionType.Location = new System.Drawing.Point(0, 0);
            this.cmbActionType.MaxDropDownItems = 12;
            this.cmbActionType.Name = "cmbActionType";
            this.cmbActionType.Size = new System.Drawing.Size(121, 21);
            this.cmbActionType.TabIndex = 2;
            this.cmbActionType.Visible = false;
            // 
            // mnuActions
            // 
            this.mnuActions.Name = "mnuActions";
            this.mnuActions.Size = new System.Drawing.Size(61, 4);
            // 
            // FormEditMacro
            // 
            this.AcceptButton = btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(494, 426);
            this.ControlBox = false;
            this.Controls.Add(this.txtActionDetails);
            this.Controls.Add(this.cmbActionType);
            this.Controls.Add(this.tableEditEmote);
            this.MainMenuStrip = this.mnuLOTROCommands2;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditMacro";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit Emote";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.tableEditEmote.ResumeLayout(false);
            this.tableEditEmote.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolsEmoteEditor.ResumeLayout(false);
            this.toolsEmoteEditor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableEditEmote;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lstEmoteEditor;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colText;
        private System.Windows.Forms.ToolStrip toolsEmoteEditor;
        private System.Windows.Forms.ToolStripLabel lblMacroName;
        private System.Windows.Forms.ToolStripTextBox txtMacroName;
        private System.Windows.Forms.TextBox txtActionDetails;
        private System.Windows.Forms.MenuStrip mnuLOTROCommands2;
        private System.Windows.Forms.ComboBox cmbActionType;
        private System.Windows.Forms.ContextMenuStrip mnuActions;
        private System.Windows.Forms.ToolStripButton btnMoveUp;
        private System.Windows.Forms.ToolStripButton btnMoveDown;
        private System.Windows.Forms.ToolStripButton btnDelItem;
        private System.Windows.Forms.ToolStripButton btnEditItem;
        private System.Windows.Forms.ToolStripButton btnAddItem;
    }
}