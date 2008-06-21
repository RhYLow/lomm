using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LotroMusicManager
{
    public partial class FormListSelector : Form
    {
        public String[] CheckedItems {get; private set;}

        public FormListSelector(String[] astrIDs)
        {   //====================================================================
            InitializeComponent();
            CheckedItems = astrIDs;
            return;
        }

        private void OnLoad(object sender, EventArgs e)
        {   //====================================================================
            // All macros with their images so we can check/uncheck them
            imglst.Images.Clear();
            foreach (Macro mac in Properties.Settings.Default.Macros.Items)
            {
                ListViewItem lvi = lst.Items.Add(mac.Name);
                lvi.Name = mac.ID; // This gives us a key to look up
                
                if (mac.ImagePath != null && mac.ImagePath != String.Empty) 
                {
                    imglst.Images.Add(mac.ID, new Bitmap(mac.ImagePath));
                    lvi.ImageKey = mac.ID;
                }
            }

            // Okay, now that all the macros are in there, let's check the ones currently in the thingie
            if (CheckedItems != null) foreach (String id in CheckedItems)
            {
                ListViewItem[] alvi = lst.Items.Find(id, false);
                if (alvi != null && alvi.Length > 0)
                {
                    alvi[0].Checked = true;
                }
            }

            return;
        }

        private void OnOK(object sender, EventArgs e)
        {   //====================================================================
            List<String> strings = new List<string>();
            foreach (ListViewItem lvi in lst.Items)
            {
                if (lvi.Checked) strings.Add(lvi.Name);
            }
            CheckedItems = strings.ToArray();
            return;
        }
    }

    public class ListSelectorItem
    {   //====================================================================
        public String  Name  {get; set;}
        public Image   Image {get; set;}
    }

}
