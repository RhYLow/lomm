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
        private double   _dblInitialMainWindowOpacity = 100;
        private double   _dblInitialToolbarOpacity = 100;

        public FormOptions(FormMain frmMain)
        {
            _frmMain                     = frmMain;
            _dblInitialMainWindowOpacity = _frmMain.Opacity;
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {  //====================================================================
            chkKeepLOTROFocused.Checked = Settings.Default.KeepLOTROFocused;
            Location           = new Point(_frmMain.Location.X + (_frmMain.Width - Width)/2, _frmMain.Location.Y + 50);
            trackMainWindowOpacity.Value = (int)(_frmMain.Opacity * 100);
            trackToolbarOpacity.Value = (int)(Double.Parse(Settings.Default.ToolbarOpacity)*100);
            return;
        }

        private void OnMainWindowOpacityValueChange(object sender, EventArgs e)
        {   //====================================================================
            _frmMain.Opacity = ((double)trackMainWindowOpacity.Value)/100.0;
            return;
        }

        private void OnToolbarOpacityValueChange(object sender, EventArgs e)
        {
        }

        private void OnCancel(object sender, EventArgs e)
        {   //====================================================================
            _frmMain.Opacity = _dblInitialMainWindowOpacity;
            foreach (FormToolbar frm in Toolbars.All) frm.Opacity = _dblInitialToolbarOpacity;
            return;
        }

        private void OnOK(object sender, EventArgs e)
        {   //====================================================================
            Settings.Default.ToolbarOpacity = (((double)trackToolbarOpacity.Value)/100.0).ToString();
            return;
        }

    }
}
