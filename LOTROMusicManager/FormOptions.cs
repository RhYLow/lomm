using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LOTROMusicManager.Properties;

namespace LOTROMusicManager
{
    public partial class FormOptions : Form
    {
        public Boolean KeepLOTROFocused {get {return chkKeepLOTROFocused.Checked;}}
        public Boolean AOT              {get {return chkAOT.Checked;}}
        
        private FormMain _frmMain;

        public FormOptions(FormMain frmMain)
        {
            _frmMain = frmMain;
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            chkKeepLOTROFocused.Checked = Settings.Default.KeepLOTROFocused;
            return;
        }

        private void OnOpacityValueChanged(object sender, EventArgs e)
        {
            _frmMain.Opacity = trackOpacity.Value;
            return;
        }
    }
}
