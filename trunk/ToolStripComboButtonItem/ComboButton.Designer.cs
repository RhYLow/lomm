namespace ComboButtonControl
{
    partial class ComboButton
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn = new System.Windows.Forms.Button();
            this.cbo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn
            // 
            this.btn.AutoSize = true;
            this.btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn.Location = new System.Drawing.Point(121, 0);
            this.btn.Margin = new System.Windows.Forms.Padding(0);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(20, 23);
            this.btn.TabIndex = 0;
            this.btn.Text = " ";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.HandleButtonClick);
            // 
            // cbo
            // 
            this.cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo.DropDownWidth = 800;
            this.cbo.FormattingEnabled = true;
            this.cbo.Location = new System.Drawing.Point(0, 1);
            this.cbo.Margin = new System.Windows.Forms.Padding(0);
            this.cbo.Name = "cbo";
            this.cbo.Size = new System.Drawing.Size(121, 21);
            this.cbo.TabIndex = 1;
            this.cbo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.HandleDrawItem);
            this.cbo.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.HandleMeasureItem);
            this.cbo.SelectionChangeCommitted += new System.EventHandler(this.HandleSelectionChangeCommitted);
            this.cbo.SelectedIndexChanged += new System.EventHandler(this.HandleSelectedIndexChanged);
            this.cbo.DropDownClosed += new System.EventHandler(this.HandleDropDownClosed);
            this.cbo.TextUpdate += new System.EventHandler(this.HandleTextUpdate);
            this.cbo.DropDown += new System.EventHandler(this.HandleDropDown);
            this.cbo.Click += new System.EventHandler(this.HandleComboClick);
            // 
            // ComboButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbo);
            this.Controls.Add(this.btn);
            this.Name = "ComboButton";
            this.Size = new System.Drawing.Size(143, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ComboBox cbo;
    }
}
