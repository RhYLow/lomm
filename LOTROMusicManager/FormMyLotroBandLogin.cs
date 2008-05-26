using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LotroMusicManager
{
    public partial class FormMyLotroBandLogin : Form
    {
        public String Email
        {
            get {return txtUsername.Text;}
            set {txtUsername.Text = value; return;}
        }

        public String Password
        {
            get {return txtPassword.Text;}
            set {txtPassword.Text = value; return;}
        }

        public Boolean RememberLoginInformation
        {
            get {return chkRemember.Checked;}
            set {chkRemember.Checked = value; return;}
        }

        public FormMyLotroBandLogin()
        {
            InitializeComponent();
        }
    }
}
