namespace LOTROMusicManager
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgGeneral = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.trackOpacity = new System.Windows.Forms.TrackBar();
            this.chkKeepLOTROFocused = new System.Windows.Forms.CheckBox();
            this.tpgEmotes = new System.Windows.Forms.TabPage();
            this.chkAOT = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tpgGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpgGeneral);
            this.tabControl1.Controls.Add(this.tpgEmotes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(429, 395);
            this.tabControl1.TabIndex = 0;
            // 
            // tpgGeneral
            // 
            this.tpgGeneral.Controls.Add(this.chkAOT);
            this.tpgGeneral.Controls.Add(this.label1);
            this.tpgGeneral.Controls.Add(this.trackOpacity);
            this.tpgGeneral.Controls.Add(this.chkKeepLOTROFocused);
            this.tpgGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpgGeneral.Name = "tpgGeneral";
            this.tpgGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpgGeneral.Size = new System.Drawing.Size(421, 369);
            this.tpgGeneral.TabIndex = 0;
            this.tpgGeneral.Text = "General";
            this.tpgGeneral.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Opacity";
            // 
            // trackOpacity
            // 
            this.trackOpacity.BackColor = System.Drawing.SystemColors.Window;
            this.trackOpacity.LargeChange = 10;
            this.trackOpacity.Location = new System.Drawing.Point(58, 65);
            this.trackOpacity.Maximum = 100;
            this.trackOpacity.Minimum = 30;
            this.trackOpacity.Name = "trackOpacity";
            this.trackOpacity.Size = new System.Drawing.Size(336, 45);
            this.trackOpacity.SmallChange = 5;
            this.trackOpacity.TabIndex = 1;
            this.trackOpacity.TickFrequency = 10;
            this.trackOpacity.Value = 100;
            this.trackOpacity.ValueChanged += new System.EventHandler(this.OnOpacityValueChanged);
            // 
            // chkKeepLOTROFocused
            // 
            this.chkKeepLOTROFocused.AutoSize = true;
            this.chkKeepLOTROFocused.Checked = true;
            this.chkKeepLOTROFocused.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepLOTROFocused.Location = new System.Drawing.Point(8, 42);
            this.chkKeepLOTROFocused.Name = "chkKeepLOTROFocused";
            this.chkKeepLOTROFocused.Size = new System.Drawing.Size(375, 17);
            this.chkKeepLOTROFocused.TabIndex = 0;
            this.chkKeepLOTROFocused.Text = "Keep LOTRO sounds playing when using other programs (such as LOMM)";
            this.chkKeepLOTROFocused.UseVisualStyleBackColor = true;
            // 
            // tpgEmotes
            // 
            this.tpgEmotes.Location = new System.Drawing.Point(4, 22);
            this.tpgEmotes.Name = "tpgEmotes";
            this.tpgEmotes.Padding = new System.Windows.Forms.Padding(3);
            this.tpgEmotes.Size = new System.Drawing.Size(421, 369);
            this.tpgEmotes.TabIndex = 1;
            this.tpgEmotes.Text = "Emotes";
            this.tpgEmotes.UseVisualStyleBackColor = true;
            // 
            // chkAOT
            // 
            this.chkAOT.AutoSize = true;
            this.chkAOT.Location = new System.Drawing.Point(8, 19);
            this.chkAOT.Name = "chkAOT";
            this.chkAOT.Size = new System.Drawing.Size(275, 17);
            this.chkAOT.TabIndex = 3;
            this.chkAOT.Text = "Keep LOMM on top of other apps (including LOTRO)";
            this.chkAOT.UseVisualStyleBackColor = true;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 395);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormOptions";
            this.Text = "LOMM Options";
            this.Load += new System.EventHandler(this.OnLoad);
            this.tabControl1.ResumeLayout(false);
            this.tpgGeneral.ResumeLayout(false);
            this.tpgGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgGeneral;
        private System.Windows.Forms.TabPage tpgEmotes;
        private System.Windows.Forms.CheckBox chkKeepLOTROFocused;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackOpacity;
        private System.Windows.Forms.CheckBox chkAOT;


    }
}