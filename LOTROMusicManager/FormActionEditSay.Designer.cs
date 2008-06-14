namespace LotroMusicManager
{
    partial class FormActionEditSay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboChannels = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mnuListLines = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuiAddLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiDelLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiLineUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiLineDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grdLines = new System.Windows.Forms.DataGridView();
            this.LineWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuListLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).BeginInit();
            this.SuspendLayout();
            // 
            // cboChannels
            // 
            this.cboChannels.FormattingEnabled = true;
            this.cboChannels.Location = new System.Drawing.Point(71, 9);
            this.cboChannels.Name = "cboChannels";
            this.cboChannels.Size = new System.Drawing.Size(121, 21);
            this.cboChannels.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Channel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Text:";
            // 
            // mnuListLines
            // 
            this.mnuListLines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuiAddLine,
            this.mnuiDelLine,
            this.mnuiLineUp,
            this.mnuiLineDown,
            this.toolStripSeparator1,
            this.mnuiCut,
            this.mnuiCopy,
            this.mnuiPaste});
            this.mnuListLines.Name = "mnuListLines";
            this.mnuListLines.Size = new System.Drawing.Size(242, 164);
            // 
            // mnuiAddLine
            // 
            this.mnuiAddLine.Name = "mnuiAddLine";
            this.mnuiAddLine.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mnuiAddLine.Size = new System.Drawing.Size(241, 22);
            this.mnuiAddLine.Text = "Add Line";
            // 
            // mnuiDelLine
            // 
            this.mnuiDelLine.Name = "mnuiDelLine";
            this.mnuiDelLine.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuiDelLine.Size = new System.Drawing.Size(241, 22);
            this.mnuiDelLine.Text = "Delete Line";
            // 
            // mnuiLineUp
            // 
            this.mnuiLineUp.Name = "mnuiLineUp";
            this.mnuiLineUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.mnuiLineUp.Size = new System.Drawing.Size(241, 22);
            this.mnuiLineUp.Text = "Move Line(s) Up";
            // 
            // mnuiLineDown
            // 
            this.mnuiLineDown.Name = "mnuiLineDown";
            this.mnuiLineDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.mnuiLineDown.Size = new System.Drawing.Size(241, 22);
            this.mnuiLineDown.Text = "Move Line(s) Down";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // mnuiCut
            // 
            this.mnuiCut.Name = "mnuiCut";
            this.mnuiCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuiCut.Size = new System.Drawing.Size(241, 22);
            this.mnuiCut.Text = "Cut";
            // 
            // mnuiCopy
            // 
            this.mnuiCopy.Name = "mnuiCopy";
            this.mnuiCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuiCopy.Size = new System.Drawing.Size(241, 22);
            this.mnuiCopy.Text = "Copy";
            // 
            // mnuiPaste
            // 
            this.mnuiPaste.Name = "mnuiPaste";
            this.mnuiPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuiPaste.Size = new System.Drawing.Size(241, 22);
            this.mnuiPaste.Text = "Paste";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(297, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(378, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OnOK);
            // 
            // grdLines
            // 
            this.grdLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLines.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineWeight,
            this.LineText});
            this.grdLines.Location = new System.Drawing.Point(71, 49);
            this.grdLines.Name = "grdLines";
            this.grdLines.Size = new System.Drawing.Size(382, 78);
            this.grdLines.TabIndex = 13;
            this.grdLines.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.OnCellValidating);
            // 
            // LineWeight
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "1";
            this.LineWeight.DefaultCellStyle = dataGridViewCellStyle3;
            this.LineWeight.HeaderText = "Weight";
            this.LineWeight.MaxInputLength = 3;
            this.LineWeight.Name = "LineWeight";
            this.LineWeight.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LineWeight.ToolTipText = "The \"weight\" of the line. How often that line is chosen to say.";
            this.LineWeight.Width = 50;
            // 
            // LineText
            // 
            this.LineText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LineText.HeaderText = "Text";
            this.LineText.Name = "LineText";
            this.LineText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LineText.ToolTipText = "The text to say when this line is chosen.";
            // 
            // FormActionEditSay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 173);
            this.Controls.Add(this.grdLines);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboChannels);
            this.Name = "FormActionEditSay";
            this.Text = "Edit \"Say\" Action";
            this.Load += new System.EventHandler(this.OnLoad);
            this.mnuListLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboChannels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ContextMenuStrip mnuListLines;
        private System.Windows.Forms.ToolStripMenuItem mnuiAddLine;
        private System.Windows.Forms.ToolStripMenuItem mnuiDelLine;
        private System.Windows.Forms.ToolStripMenuItem mnuiLineUp;
        private System.Windows.Forms.ToolStripMenuItem mnuiLineDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuiCut;
        private System.Windows.Forms.ToolStripMenuItem mnuiCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuiPaste;
        private System.Windows.Forms.DataGridView grdLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineText;
    }
}