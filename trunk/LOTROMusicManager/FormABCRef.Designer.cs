namespace LotroMusicManager
{
    partial class FormABCRef
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormABCRef));
            this.rtfABCRef = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtfABCRef
            // 
            this.rtfABCRef.AutoWordSelection = true;
            this.rtfABCRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfABCRef.EnableAutoDragDrop = true;
            this.rtfABCRef.Location = new System.Drawing.Point(0, 0);
            this.rtfABCRef.Name = "rtfABCRef";
            this.rtfABCRef.ReadOnly = true;
            this.rtfABCRef.Size = new System.Drawing.Size(658, 270);
            this.rtfABCRef.TabIndex = 0;
            this.rtfABCRef.Text = "";
            // 
            // FormABCRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 270);
            this.Controls.Add(this.rtfABCRef);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormABCRef";
            this.Text = "LOTRO ABC Quick Reference";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OnLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfABCRef;

    }
}