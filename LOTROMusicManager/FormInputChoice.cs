using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LotroMusicManager
{
    public partial class FormInputChoice : Form
    {
        public String Value {get {return cmb.Text;} private set {;}}

        public static String GetInput(String strTitle, String strPrompt, String[] astr, String strDefault)
        {   //====================================================================
            FormInputChoice fic = new FormInputChoice(strTitle, strPrompt, astr, strDefault);
            if (fic.ShowDialog() == DialogResult.OK) return fic.Value;
            return strDefault;
        }

        public FormInputChoice(String strTitle, String strPrompt, String[] astr, String strDefault)
        {
            InitializeComponent();
            Text = strTitle;
            lbl.Text = strPrompt;
            foreach (String s in astr) cmb.Items.Add(s);
            cmb.Text = strDefault;
        }
    }
}
