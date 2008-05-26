namespace LotroMusicManager
{
    partial class FormEditEmote
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
            this.tableEditEmote = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstEmoteEditor = new System.Windows.Forms.ListView();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colWeight = new System.Windows.Forms.ColumnHeader();
            this.colText = new System.Windows.Forms.ColumnHeader();
            this.toolsEmoteEditor = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.cmbActionType = new System.Windows.Forms.ComboBox();
            this.cmbActionWeight = new System.Windows.Forms.ComboBox();
            this.txtActionDetails = new System.Windows.Forms.TextBox();
            this.mnuLOTROCommands = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuLOTROCommands2 = new System.Windows.Forms.MenuStrip();
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
            // lstEmoteEditor
            // 
            this.lstEmoteEditor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colType,
            this.colText,
            this.colWeight});
            this.lstEmoteEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEmoteEditor.FullRowSelect = true;
            this.lstEmoteEditor.GridLines = true;
            this.lstEmoteEditor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstEmoteEditor.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lstEmoteEditor.Location = new System.Drawing.Point(3, 28);
            this.lstEmoteEditor.MultiSelect = false;
            this.lstEmoteEditor.Name = "lstEmoteEditor";
            this.lstEmoteEditor.ShowItemToolTips = true;
            this.lstEmoteEditor.Size = new System.Drawing.Size(488, 358);
            this.lstEmoteEditor.TabIndex = 2;
            this.lstEmoteEditor.UseCompatibleStateImageBehavior = false;
            this.lstEmoteEditor.View = System.Windows.Forms.View.Details;
            this.lstEmoteEditor.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            this.lstEmoteEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnEmoteEditorMouseUp);
            this.lstEmoteEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnEmoteEditorKeyPress);
            // 
            // colType
            // 
            this.colType.Text = "Action";
            this.colType.Width = 101;
            // 
            // colWeight
            // 
            this.colWeight.Text = "How Often";
            this.colWeight.Width = 73;
            // 
            // colText
            // 
            this.colText.Text = "Details";
            this.colText.Width = 222;
            // 
            // toolsEmoteEditor
            // 
            this.toolsEmoteEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.toolsEmoteEditor.Location = new System.Drawing.Point(0, 0);
            this.toolsEmoteEditor.Name = "toolsEmoteEditor";
            this.toolsEmoteEditor.Size = new System.Drawing.Size(494, 25);
            this.toolsEmoteEditor.TabIndex = 3;
            this.toolsEmoteEditor.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(79, 22);
            this.toolStripLabel1.Text = "Emote Name:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
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
            this.cmbActionType.Leave += new System.EventHandler(this.OnActionTypeLoseFocus);
            this.cmbActionType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnActionTypeKeyPress);
            // 
            // cmbActionWeight
            // 
            this.cmbActionWeight.FormattingEnabled = true;
            this.cmbActionWeight.Location = new System.Drawing.Point(0, 0);
            this.cmbActionWeight.Name = "cmbActionWeight";
            this.cmbActionWeight.Size = new System.Drawing.Size(121, 21);
            this.cmbActionWeight.TabIndex = 4;
            this.cmbActionWeight.Visible = false;
            this.cmbActionWeight.Leave += new System.EventHandler(this.OnActionWeightLoseFocus);
            this.cmbActionWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnActionWeightKeyPress);
            // 
            // txtActionDetails
            // 
            this.txtActionDetails.Location = new System.Drawing.Point(190, 425);
            this.txtActionDetails.Name = "txtActionDetails";
            this.txtActionDetails.Size = new System.Drawing.Size(24, 20);
            this.txtActionDetails.TabIndex = 5;
            this.txtActionDetails.Visible = false;
            this.txtActionDetails.Leave += new System.EventHandler(this.OnEmoteEditorTextLoseFocus);
            this.txtActionDetails.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnEmoteEditorTextKeyPress);
            // 
            // mnuLOTROCommands
            // 
            this.mnuLOTROCommands.Name = "mnuLOTROCommands";
            this.mnuLOTROCommands.Size = new System.Drawing.Size(61, 4);
            // 
            // mnuLOTROCommands2
            // 
            this.mnuLOTROCommands2.Location = new System.Drawing.Point(0, 0);
            this.mnuLOTROCommands2.Name = "mnuLOTROCommands2";
            this.mnuLOTROCommands2.Size = new System.Drawing.Size(404, 24);
            this.mnuLOTROCommands2.TabIndex = 2;
            this.mnuLOTROCommands2.Text = "menuStrip1";
            // 
            // FormEditEmote
            // 
            this.AcceptButton = btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(494, 426);
            this.ControlBox = false;
            this.Controls.Add(this.txtActionDetails);
            this.Controls.Add(this.cmbActionWeight);
            this.Controls.Add(this.cmbActionType);
            this.Controls.Add(this.tableEditEmote);
            this.MainMenuStrip = this.mnuLOTROCommands2;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditEmote";
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
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ComboBox cmbActionType;
        private System.Windows.Forms.ColumnHeader colWeight;
        private System.Windows.Forms.ComboBox cmbActionWeight;
        private System.Windows.Forms.TextBox txtActionDetails;
        private System.Windows.Forms.ContextMenuStrip mnuLOTROCommands;
        private System.Windows.Forms.MenuStrip mnuLOTROCommands2;
    }
}