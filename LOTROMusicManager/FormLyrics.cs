using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LOTROMusicManager
{
    public partial class FormLyrics : Form
    {
        protected int _iSelected = -1;
        public FormLyrics()
        {//====================================================================
            InitializeComponent();
        }

        public void PlayFile(String[] strLines)
        {//====================================================================
            Visible = false;
            Show();
            lstLyrics.SuspendLayout();
            lstLyrics.Items.Clear();
            lstLyrics.Items.AddRange(strLines); 
            lstLyrics.ResumeLayout();

            foreach (String s in lstLyrics.Items)
            {
                ABCLine l = new ABCLine(s);
                List<String> ls = l.Pitches;
            }

            Visible = true;
        }

        private void OnDrawItem(object sender, DrawItemEventArgs e)
        {//====================================================================
            // Boilerplate
            e.DrawBackground();
            if (e.Index >= 0)
            {
                Brush brush = Brushes.Black;
                Font font = e.Font;
                if (ABC.IsLyrics(lstLyrics.Items[e.Index].ToString()))
                {
                    // Lyric line - no change                
                }
                else
                {
                    // Not a lyric line
                    brush = Brushes.DarkGray;
                    font = new Font(FontFamily.GenericMonospace, 12);
                }
                e.Graphics.DrawString(lstLyrics.Items[e.Index].ToString(), font, brush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
            return;
        }

        private void SayLine()
        {//====================================================================
            // Send the line to the client if it's a lyric
            if (ABC.IsLyrics(lstLyrics.SelectedItem.ToString()))
            {
                String str = "";
                switch (cboChannel.Text)
                {
                    default:
                    case "Say":         str = "/say ";    break;
                    case "Fellowship":  str = "/f ";      break;
                    case "Raid":        str = "/ra ";     break;
                    case "RP":          str = "/rp ";     break;
                    case "Region":      str = "/region "; break;
                }
                str += lstLyrics.SelectedItem.ToString().Substring(2);
                RemoteController.ExecuteString(str, RemoteController.Focus.REMOTE);

                MoveToNextLyricsLine();
            }
            return;
        }

        private void MoveToNextLyricsLine()
        {//--------------------------------------------------------------------
            // Move to the next lyrics line
            if (lstLyrics.SelectedIndex != lstLyrics.Items.Count) lstLyrics.SelectedIndex += 1;
        }

        private void OnLineDblClick(object sender, EventArgs e)
        {//====================================================================
            SayLine();
            MoveToNextLyricsLine();
            return;
        }

        private void OnSelectedChanged(object sender, EventArgs e)
        {//====================================================================
            if ((lstLyrics.SelectedIndex < lstLyrics.Items.Count - 1)
                && lstLyrics.SelectedIndex >= 0
                && !ABC.IsLyrics(lstLyrics.SelectedItem.ToString())) 
            {
                lstLyrics.SelectedIndex += lstLyrics.SelectedIndex > _iSelected ? +1 : -1;
                _iSelected = lstLyrics.SelectedIndex;
            }
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

        private void OnReciteClick(object sender, EventArgs e)
        {//====================================================================
            SayLine();
            MoveToNextLyricsLine();
            return;
        }
    }
}
