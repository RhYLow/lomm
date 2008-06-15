using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LotroMusicManager.Properties;

namespace LotroMusicManager
{
    public partial class FormOptions : Form
    {
        public Boolean KeepLOTROFocused {get {return chkKeepLOTROFocused.Checked;}}
        public Boolean AOT              {get {return chkAOT.Checked;}}
        
        private FormMain _frmMain;
        private double   _dblInitialOpacity;

        public FormOptions(FormMain frmMain)
        {
            _frmMain           = frmMain;
            _dblInitialOpacity = _frmMain.Opacity;
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {  //====================================================================
            chkKeepLOTROFocused.Checked = Settings.Default.KeepLOTROFocused;
            Location           = new Point(_frmMain.Location.X + (_frmMain.Width - Width)/2, _frmMain.Location.Y + 50);
            trackOpacity.Value = (int)(_frmMain.Opacity * 100);
            return;
        }

        private void OnOpacityValueChanged(object sender, EventArgs e)
        {   //====================================================================
            _frmMain.Opacity = ((double)trackOpacity.Value)/100.0;
            return;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            _frmMain.Opacity = _dblInitialOpacity;
        }
    }
}
