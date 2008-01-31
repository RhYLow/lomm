using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LOTROMusicManager.Properties;

namespace LOTROMusicManager
{
    public partial class FormABCRef : Form
    {
        public FormABCRef()
        {
            InitializeComponent();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {//====================================================================
            // Don't actually exit. Just hide.
            if (Visible)
            {
                e.Cancel = true;
                Visible = false;
            }
            return;
        }

        private void OnLoad(object sender, EventArgs e)
        {//--------------------------------------------------------------------
            // Open the resource we need
            rtfABCRef.Rtf = Resources.ABCRef;
            return;
        }
    }
}