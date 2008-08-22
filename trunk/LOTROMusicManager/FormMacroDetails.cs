using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LotroMusicManager
{
    public partial class FormMacroDetails : Form
    {
        public  String MacroName        {get {return txtName.Text;}         private set {;}}
        public  String MacroDescription {get {return txtDescription.Text;}  private set {;}}
        public  String MacroImagePath   {get {return _strImagePath;}        private set {;}}
        
        private String _strImagePath = String.Empty;

        public FormMacroDetails(Macro mac)
        {   //====================================================================
            InitializeComponent();
            txtName.Text = mac.Name;
            txtDescription.Text = mac.Description;
            
            if (mac.ImagePath != null && mac.ImagePath != String.Empty) 
            {
                pic.Image = new Bitmap(mac.ImagePath);
                _strImagePath = mac.ImagePath;
            }
        }

        private void onChangeImageClick(object sender, EventArgs e)
        {   //====================================================================
            if (_strImagePath != String.Empty) 
            {
                FileInfo fi = new FileInfo(_strImagePath);
                ofd.InitialDirectory = fi.Directory.FullName;
                ofd.FileName = fi.Name;
            }
            else
            {
                ofd.InitialDirectory = Environment.CurrentDirectory;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic.Image = new Bitmap(ofd.FileName);
                _strImagePath = ofd.FileName;
            }
            return;
        }

        private void OnLoad(object sender, EventArgs e)
        {   //====================================================================
            CenterToParent();
            return;
        }
    }
}
