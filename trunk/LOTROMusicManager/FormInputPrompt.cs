using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LotroMusicManager
{
    public partial class FormInputPrompt : Form
    {
        public String Value {get {return txt.Text;} private set {;}}

        public static String GetInput(String strTitle, String strPrompt, String strDefault)
        {
            FormInputPrompt fip = new FormInputPrompt(strTitle, strPrompt, strDefault);
            if (fip.ShowDialog() == DialogResult.OK) return fip.Value;
            return strDefault;
        }
        public FormInputPrompt(String strTitle, String strPrompt, String strDefault)
        {
            InitializeComponent();
            Text = strTitle;
            lbl.Text = strPrompt;
            txt.Text = strDefault;
        }

        private void OnLoad(object sender, EventArgs e)
        {   //====================================================================
            int nWidth = lbl.Right + lbl.Left;
            if (nWidth > Width) Width = nWidth;
            CenterToParent();
            return;
        }
    }
}
