using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LotroMusicManager
{
    public partial class FormActionEditKey : Form
    {
        // Accessors. Yes, there is potential weirdness if this form is created and read but never shown.
        public SDK.VK  Key      {get {return ((VKBag)cmbKey.SelectedItem).VK;}  private set {;}}
        public Boolean Shift    {get {return chkShift.Checked;}                 private set {;}}
        public Boolean Control  {get {return chkControl.Checked;}               private set {;}}
        public Boolean Alt      {get {return chkAlt.Checked;}                   private set {;}}

        private MacroActionKey _mak;
        public FormActionEditKey(MacroActionKey mak)
        {
            _mak = mak;
            InitializeComponent();
            return;
        }

        private void OnLoad(object sender, EventArgs e)
        {   //====================================================================
            CenterToParent();
            foreach (SDK.VK vk in Enum.GetValues(typeof(SDK.VK)))   
            {
                if (vk == SDK.VK.unknown_vk) continue;

                int i = cmbKey.Items.Add(new VKBag(vk));
                if (vk == _mak.Key) cmbKey.SelectedIndex = i;
            }
            if (-1 == cmbKey.SelectedIndex) cmbKey.SelectedIndex = 0;
            
            chkAlt.Checked      = _mak.Alt;
            chkShift.Checked    = _mak.Shift;
            chkControl.Checked  = _mak.Control;

            return;
        }
    }

    public class VKBag
    {   //====================================================================
        public SDK.VK VK   {get; private set;}
        public VKBag(SDK.VK vk) {VK = vk; return;}
        public override string ToString() 
        {
            String str = Enum.GetName(typeof(SDK.VK), VK);
            if (str.StartsWith("KEY_")) str = str.Substring(4);
            return str;
        }
    }
}
