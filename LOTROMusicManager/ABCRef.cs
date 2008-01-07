using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LOTROMusicManager
{
    public partial class ABCRef : Form
    {
        public ABCRef()
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
            Stream s = this.GetType().Assembly.GetManifestResourceStream("LOTROMusicManager.Help.ABCRef.rtf");
            rtfABCRef.LoadFile(s, RichTextBoxStreamType.RichText);
            return;
        }
    }
}