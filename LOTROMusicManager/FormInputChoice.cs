using System;
using System.Windows.Forms;

namespace LotroMusicManager
{
    public partial class FormInputChoice : Form
    {
        public String Value         {get {return cmb.Text;}          private set {;}}
        public int    SelectedIndex {get {return cmb.SelectedIndex;} private set {;}}

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

        private void OnLoad(object sender, EventArgs e)
        {   //====================================================================
            int nWidth = lbl.Right + lbl.Left;
            if (nWidth > Width) Width = nWidth;
            CenterToParent();
            return;
        }
    }
}
