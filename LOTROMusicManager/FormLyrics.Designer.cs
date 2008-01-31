namespace LOTROMusicManager
{
    partial class FormLyrics
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
            System.Windows.Forms.ToolStripLabel toolStripLabel1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLyrics));
            this.lstLyrics = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.mnuReciteButton = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniToggleMusic = new System.Windows.Forms.ToolStripMenuItem();
            this.mniStopPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniStartPlayRecite = new System.Windows.Forms.ToolStripMenuItem();
            this.mniStartPlayNoRecite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cboChannel = new System.Windows.Forms.ToolStripComboBox();
            this.btnRecite = new InstantUpdate.Controls.SplitButton();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.mnuReciteButton.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(54, 22);
            toolStripLabel1.Text = "Channel:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(this.lstLyrics, 0, 0);
            tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new System.Drawing.Size(861, 369);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // lstLyrics
            // 
            this.lstLyrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLyrics.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstLyrics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLyrics.FormattingEnabled = true;
            this.lstLyrics.HorizontalScrollbar = true;
            this.lstLyrics.ItemHeight = 20;
            this.lstLyrics.Location = new System.Drawing.Point(3, 3);
            this.lstLyrics.Name = "lstLyrics";
            this.lstLyrics.Size = new System.Drawing.Size(855, 304);
            this.lstLyrics.TabIndex = 0;
            this.lstLyrics.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnDrawItem);
            this.lstLyrics.DoubleClick += new System.EventHandler(this.OnLineDblClick);
            this.lstLyrics.SelectedValueChanged += new System.EventHandler(this.OnSelectedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.Controls.Add(this.btnRecite, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 332);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(855, 34);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // mnuReciteButton
            // 
            this.mnuReciteButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniToggleMusic,
            this.mniStopPlay,
            this.toolStripSeparator1,
            this.mniStartPlayRecite,
            this.mniStartPlayNoRecite});
            this.mnuReciteButton.Name = "mnuReciteButton";
            this.mnuReciteButton.ShowImageMargin = false;
            this.mnuReciteButton.Size = new System.Drawing.Size(205, 98);
            // 
            // mniToggleMusic
            // 
            this.mniToggleMusic.Name = "mniToggleMusic";
            this.mniToggleMusic.Size = new System.Drawing.Size(204, 22);
            this.mniToggleMusic.Text = "Toggle Music Mode";
            // 
            // mniStopPlay
            // 
            this.mniStopPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mniStopPlay.Name = "mniStopPlay";
            this.mniStopPlay.Size = new System.Drawing.Size(204, 22);
            this.mniStopPlay.Text = "Stop Playing";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // mniStartPlayRecite
            // 
            this.mniStartPlayRecite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mniStartPlayRecite.Name = "mniStartPlayRecite";
            this.mniStartPlayRecite.Size = new System.Drawing.Size(204, 22);
            this.mniStartPlayRecite.Text = "Start Playing with first line";
            // 
            // mniStartPlayNoRecite
            // 
            this.mniStartPlayNoRecite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mniStartPlayNoRecite.Name = "mniStartPlayNoRecite";
            this.mniStartPlayNoRecite.Size = new System.Drawing.Size(204, 22);
            this.mniStartPlayNoRecite.Text = "Start playing without first line";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabel1,
            this.cboChannel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(861, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cboChannel
            // 
            this.cboChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChannel.Items.AddRange(new object[] {
            "Say",
            "Fellowship",
            "Raid",
            "RP",
            "Region"});
            this.cboChannel.Name = "cboChannel";
            this.cboChannel.Size = new System.Drawing.Size(121, 25);
            // 
            // btnRecite
            // 
            this.btnRecite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecite.AutoSize = true;
            this.btnRecite.ContextMenuStrip = this.mnuReciteButton;
            this.btnRecite.Location = new System.Drawing.Point(777, 8);
            this.btnRecite.Name = "btnRecite";
            this.btnRecite.Size = new System.Drawing.Size(75, 23);
            this.btnRecite.SplitMenu = this.mnuReciteButton;
            this.btnRecite.TabIndex = 0;
            this.btnRecite.Text = "Recite line";
            this.btnRecite.UseVisualStyleBackColor = true;
            this.btnRecite.Click += new System.EventHandler(this.OnReciteClick);
            // 
            // FormLyrics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 394);
            this.Controls.Add(tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLyrics";
            this.Text = "Lyrics";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.mnuReciteButton.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cboChannel;
        private System.Windows.Forms.ListBox lstLyrics;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private InstantUpdate.Controls.SplitButton btnRecite;
        private System.Windows.Forms.ContextMenuStrip mnuReciteButton;
        private System.Windows.Forms.ToolStripMenuItem mniToggleMusic;
        private System.Windows.Forms.ToolStripMenuItem mniStopPlay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mniStartPlayRecite;
        private System.Windows.Forms.ToolStripMenuItem mniStartPlayNoRecite;
    }
}