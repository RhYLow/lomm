using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LotroMusicManager
{
    public partial class FormActionEditSay : Form
    {
        private MacroActionSay _mas;
        public List<MacroActionSay.WeightedText> Lines = new List<MacroActionSay.WeightedText>();
        public MacroActionSay.Channel Channel {get {return (MacroActionSay.Channel)(cboChannels.SelectedItem);} set {cboChannels.SelectedItem = value;}}

        public FormActionEditSay(MacroActionSay mas)
        {
            _mas = mas;
            Lines = _mas.Lines;
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {   //====================================================================
            CenterToParent();
            foreach (MacroActionSay.Channel ch in Enum.GetValues(typeof(MacroActionSay.Channel)))
            {
                cboChannels.Items.Add(ch);
            }
            cboChannels.SelectedItem = _mas.OutputChannel;

            foreach (MacroActionSay.WeightedText wt in _mas.Lines)
            {
                grdLines.Rows.Add(new object[] {wt.Weight.ToString(), wt.Text});
            }
        }

        private void OnOK(object sender, EventArgs e)
        {   //====================================================================
            Lines.Clear();
            foreach (DataGridViewRow row in grdLines.Rows)
            {   
                // Skip error rows
                if (row.ErrorText.Length > 1) continue;
                if (row.IsNewRow) continue;

                int nWeight = Int32.Parse(row.Cells[0].FormattedValue.ToString());
                String strText = row.Cells[1].FormattedValue.ToString();
                Lines.Add(new MacroActionSay.WeightedText(nWeight, strText));
            }
            return;
        }

        private void OnCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {   //====================================================================
            grdLines.Rows[e.RowIndex].ErrorText = "";
            if (e.ColumnIndex == 0)
            {
                try
                {
                    int i = Int32.Parse(e.FormattedValue.ToString());
                    if (i < 1)
                    {
                        e.Cancel = true;
                        grdLines.Rows[e.RowIndex].ErrorText = "The \"Weight\" value must be greater than zero";
                    }
                }
                catch
                {
                    e.Cancel = true;
                    grdLines.Rows[e.RowIndex].ErrorText = "The \"Weight\" value must be an integer (1, 2, ...)";
                }
            }
            return;
        }
    }
}
