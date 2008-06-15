namespace LotroMusicManager
{
    partial class FormOptions
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
            this.tabsOptions = new System.Windows.Forms.TabControl();
            this.tpgGeneral = new System.Windows.Forms.TabPage();
            this.chkHighlightABC = new System.Windows.Forms.CheckBox();
            this.chkAOT = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackOpacity = new System.Windows.Forms.TrackBar();
            this.chkKeepLOTROFocused = new System.Windows.Forms.CheckBox();
            this.tpgCharacters = new System.Windows.Forms.TabPage();
            this.btnDelCharacter = new System.Windows.Forms.Button();
            this.btnAddCharacter = new System.Windows.Forms.Button();
            this.lstCharacters = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkPerCharacterSettings = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imglEmotes = new System.Windows.Forms.ImageList(this.components);
            this.tabsOptions.SuspendLayout();
            this.tpgGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).BeginInit();
            this.tpgCharacters.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsOptions
            // 
            this.tabsOptions.Controls.Add(this.tpgGeneral);
            this.tabsOptions.Controls.Add(this.tpgCharacters);
            this.tabsOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsOptions.Location = new System.Drawing.Point(3, 3);
            this.tabsOptions.Name = "tabsOptions";
            this.tabsOptions.SelectedIndex = 0;
            this.tabsOptions.Size = new System.Drawing.Size(505, 358);
            this.tabsOptions.TabIndex = 0;
            // 
            // tpgGeneral
            // 
            this.tpgGeneral.Controls.Add(this.chkHighlightABC);
            this.tpgGeneral.Controls.Add(this.chkAOT);
            this.tpgGeneral.Controls.Add(this.label1);
            this.tpgGeneral.Controls.Add(this.trackOpacity);
            this.tpgGeneral.Controls.Add(this.chkKeepLOTROFocused);
            this.tpgGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpgGeneral.Name = "tpgGeneral";
            this.tpgGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpgGeneral.Size = new System.Drawing.Size(497, 332);
            this.tpgGeneral.TabIndex = 0;
            this.tpgGeneral.Text = "General";
            this.tpgGeneral.UseVisualStyleBackColor = true;
            // 
            // chkHighlightABC
            // 
            this.chkHighlightABC.AutoSize = true;
            this.chkHighlightABC.Checked = global::LotroMusicManager.Properties.Settings.Default.HighlightABC;
            this.chkHighlightABC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighlightABC.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::LotroMusicManager.Properties.Settings.Default, "HighlightABC", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkHighlightABC.Location = new System.Drawing.Point(8, 67);
            this.chkHighlightABC.Name = "chkHighlightABC";
            this.chkHighlightABC.Size = new System.Drawing.Size(136, 17);
            this.chkHighlightABC.TabIndex = 2;
            this.chkHighlightABC.Text = "Highlighting in ABC text";
            this.chkHighlightABC.UseVisualStyleBackColor = true;
            // 
            // chkAOT
            // 
            this.chkAOT.AutoSize = true;
            this.chkAOT.Location = new System.Drawing.Point(8, 19);
            this.chkAOT.Name = "chkAOT";
            this.chkAOT.Size = new System.Drawing.Size(275, 17);
            this.chkAOT.TabIndex = 0;
            this.chkAOT.Text = "Keep LOMM on top of other apps (including LOTRO)";
            this.chkAOT.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Opacity";
            // 
            // trackOpacity
            // 
            this.trackOpacity.BackColor = System.Drawing.SystemColors.Window;
            this.trackOpacity.LargeChange = 10;
            this.trackOpacity.Location = new System.Drawing.Point(58, 89);
            this.trackOpacity.Maximum = 100;
            this.trackOpacity.Minimum = 30;
            this.trackOpacity.Name = "trackOpacity";
            this.trackOpacity.Size = new System.Drawing.Size(336, 45);
            this.trackOpacity.SmallChange = 5;
            this.trackOpacity.TabIndex = 3;
            this.trackOpacity.TickFrequency = 10;
            this.trackOpacity.Value = 100;
            this.trackOpacity.ValueChanged += new System.EventHandler(this.OnOpacityValueChanged);
            // 
            // chkKeepLOTROFocused
            // 
            this.chkKeepLOTROFocused.AutoSize = true;
            this.chkKeepLOTROFocused.Checked = true;
            this.chkKeepLOTROFocused.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepLOTROFocused.Location = new System.Drawing.Point(8, 43);
            this.chkKeepLOTROFocused.Name = "chkKeepLOTROFocused";
            this.chkKeepLOTROFocused.Size = new System.Drawing.Size(375, 17);
            this.chkKeepLOTROFocused.TabIndex = 1;
            this.chkKeepLOTROFocused.Text = "Keep LOTRO sounds playing when using other programs (such as LOMM)";
            this.chkKeepLOTROFocused.UseVisualStyleBackColor = true;
            // 
            // tpgCharacters
            // 
            this.tpgCharacters.Controls.Add(this.btnDelCharacter);
            this.tpgCharacters.Controls.Add(this.btnAddCharacter);
            this.tpgCharacters.Controls.Add(this.lstCharacters);
            this.tpgCharacters.Controls.Add(this.textBox1);
            this.tpgCharacters.Controls.Add(this.comboBox1);
            this.tpgCharacters.Controls.Add(this.chkPerCharacterSettings);
            this.tpgCharacters.Location = new System.Drawing.Point(4, 22);
            this.tpgCharacters.Name = "tpgCharacters";
            this.tpgCharacters.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharacters.Size = new System.Drawing.Size(497, 332);
            this.tpgCharacters.TabIndex = 2;
            this.tpgCharacters.Text = "Characters";
            this.tpgCharacters.UseVisualStyleBackColor = true;
            // 
            // btnDelCharacter
            // 
            this.btnDelCharacter.Enabled = false;
            this.btnDelCharacter.Location = new System.Drawing.Point(29, 219);
            this.btnDelCharacter.Name = "btnDelCharacter";
            this.btnDelCharacter.Size = new System.Drawing.Size(105, 23);
            this.btnDelCharacter.TabIndex = 5;
            this.btnDelCharacter.Text = "Delete Character";
            this.btnDelCharacter.UseVisualStyleBackColor = true;
            // 
            // btnAddCharacter
            // 
            this.btnAddCharacter.Enabled = false;
            this.btnAddCharacter.Location = new System.Drawing.Point(185, 220);
            this.btnAddCharacter.Name = "btnAddCharacter";
            this.btnAddCharacter.Size = new System.Drawing.Size(101, 23);
            this.btnAddCharacter.TabIndex = 4;
            this.btnAddCharacter.Text = "New Character";
            this.btnAddCharacter.UseVisualStyleBackColor = true;
            // 
            // lstCharacters
            // 
            this.lstCharacters.FormattingEnabled = true;
            this.lstCharacters.Location = new System.Drawing.Point(29, 53);
            this.lstCharacters.Name = "lstCharacters";
            this.lstCharacters.Size = new System.Drawing.Size(258, 160);
            this.lstCharacters.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(29, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 13);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Startup on Character";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "(last used)"});
            this.comboBox1.Location = new System.Drawing.Point(166, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // chkPerCharacterSettings
            // 
            this.chkPerCharacterSettings.AutoSize = true;
            this.chkPerCharacterSettings.Enabled = false;
            this.chkPerCharacterSettings.Location = new System.Drawing.Point(9, 7);
            this.chkPerCharacterSettings.Name = "chkPerCharacterSettings";
            this.chkPerCharacterSettings.Size = new System.Drawing.Size(206, 17);
            this.chkPerCharacterSettings.TabIndex = 0;
            this.chkPerCharacterSettings.Text = "Keep Separate Settings Per Character";
            this.chkPerCharacterSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabsOptions, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(511, 400);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnOK, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 367);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(505, 30);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(427, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(327, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // imglEmotes
            // 
            this.imglEmotes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglEmotes.ImageSize = new System.Drawing.Size(16, 16);
            this.imglEmotes.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FormOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(511, 400);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LOMM Options";
            this.Load += new System.EventHandler(this.OnLoad);
            this.tabsOptions.ResumeLayout(false);
            this.tpgGeneral.ResumeLayout(false);
            this.tpgGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).EndInit();
            this.tpgCharacters.ResumeLayout(false);
            this.tpgCharacters.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsOptions;
        private System.Windows.Forms.TabPage tpgGeneral;
        private System.Windows.Forms.CheckBox chkKeepLOTROFocused;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackOpacity;
        private System.Windows.Forms.CheckBox chkAOT;
        private System.Windows.Forms.TabPage tpgCharacters;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox chkPerCharacterSettings;
        private System.Windows.Forms.Button btnDelCharacter;
        private System.Windows.Forms.Button btnAddCharacter;
        private System.Windows.Forms.ListBox lstCharacters;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ImageList imglEmotes;
        private System.Windows.Forms.CheckBox chkHighlightABC;


    }
}