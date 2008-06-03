using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace LotroMusicManager
{
    //====================================================================
    // Okay. Let's figure this out.
    //
    // Each line is an EmoteLine. Except, groups work differently.
    public partial class FormEditMacro : Form
    {
        private enum EditorColumns
        {
            Action = 0,
            Text   = 1,
            Weight = 2,
        };

        private Form _frmParent;

        public FormEditMacro(Form frmParent)
        {
            _frmParent = frmParent;
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {   //====================================================================
            ArrayList alLineTypes = new ArrayList();
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.Say,           "Say"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.Fellowship,    "Fellowship"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.Raid,          "Raid"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.Local,         "Regional"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.RP,            "RP"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.UserChannel1,  "User channel 1"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.UserChannel2,  "User channel 2"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.UserChannel3,  "User channel 3"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.LFF,           "lff"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.COMMAND,       "Slash Command"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.LOTROFUNCTION, "LOTRO command"));
            alLineTypes.Add(new NamedEmoteLine(EmoteLine.LineType.KEY,           "Press key"));

            cmbActionType.DataSource = alLineTypes;
            cmbActionType.DisplayMember = "Name";

            CreateCommandMenus(); // Read the categories and functions and build the menus from that

            Location = new Point(_frmParent.Location.X + (_frmParent.Width - Width)/2, _frmParent.Location.Y + 50);
            return;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {   //====================================================================
            return;
        }

        private void OnEmoteEditorKeyPress(object sender, KeyPressEventArgs e)
        {   //====================================================================
            return;
        }

        private void OnActionWeightLoseFocus(object sender, EventArgs e)
        {   //====================================================================
            return;
        }

        private void OnActionTypeLoseFocus(object sender, EventArgs e)
        {   //====================================================================
            int nRow = (int)cmbActionType.Tag;
            lstEmoteEditor.Items[nRow].Text = ((NamedEmoteLine)cmbActionType.SelectedValue).Name;
            lstEmoteEditor.Items[nRow].Tag  = new EmoteLine(((NamedEmoteLine)cmbActionType.SelectedValue).Type, "");
            cmbActionType.Visible = false;
            return;
        }

        private void OnActionTypeKeyPress(object sender, KeyPressEventArgs e)
        {   //====================================================================
            // If it's a tab or an enter, move to the next column
            //  Note that the next column is usually *not* Weight
            // If it's ESC, undo the change
            return;
        }

        private void OnActionWeightKeyPress(object sender, KeyPressEventArgs e)
        {   //====================================================================
            // If it's a tab or an enter, move to the next column
            // If it's ESC, undo the change
            return;
        }   

        private void MakeNewLine()
        {   //====================================================================
            ListViewItem lvi = lstEmoteEditor.Items.Add("(new item)");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            lvi.Selected = true;
            EditSelectedItem(lvi, 0);
            return;
        }

        private void OnEmoteEditorMouseUp(object sender, MouseEventArgs e)
        {   //====================================================================
            ListViewItem lvi = lstEmoteEditor.GetItemAt(e.X, e.Y);
            if (null == lvi) {MakeNewLine(); return;}
            ListViewItem.ListViewSubItem lvsi = lvi.GetSubItemAt(e.X, e.Y);
            if (null == lvsi) return;
            
            int nCol = -1;
            int nWidth = 0;
            foreach (ColumnHeader col in lstEmoteEditor.Columns)
            {
                nWidth += col.Width;
                if (nWidth > e.X)
                {
                    nCol = col.Index;
                    break;
                }
            }
            if (-1 == nCol) return;

            EditSelectedItem(lvi, nCol);

            return;
        }

        private void EditSelectedItem(ListViewItem lvi, int nCol)
        {   //====================================================================
            switch ((EditorColumns)nCol)
            {
                default:
                    break; // How did this happen?!

                case EditorColumns.Action:
                    ShowTypeEditor(lvi.Index);
                    break;

                case EditorColumns.Weight:
                    ShowWeightEditor(lvi.Index);
                    break;

                case EditorColumns.Text:
                    ShowDetailsEditor(lvi.Index);
                    break;
            }
            return;
        }

        private void ShowDetailsEditor(int nRow)
        {   //====================================================================
            if (null == (EmoteLine)lstEmoteEditor.Items[nRow].Tag) return;
            switch (((EmoteLine)lstEmoteEditor.Items[nRow].Tag).Channel)
            {
                default:
                    return; // Unknown line type. Might actually even be UNKNOWN

                case EmoteLine.LineType.Say:
                case EmoteLine.LineType.RP:
                case EmoteLine.LineType.Raid:
                case EmoteLine.LineType.Local:
                case EmoteLine.LineType.LFF:
                case EmoteLine.LineType.Fellowship:
                case EmoteLine.LineType.UserChannel1:
                case EmoteLine.LineType.UserChannel2:
                case EmoteLine.LineType.UserChannel3:
                case EmoteLine.LineType.COMMAND:
                    {
                    // Show the edit box
                    ListViewItem lvi = lstEmoteEditor.Items[nRow];
                    ListViewItem.ListViewSubItem lvsi = lvi.SubItems[(int)EditorColumns.Text];

                    Point p = lstEmoteEditor.Location;
                    p.X += lvsi.Bounds.X; p.Y += lvsi.Bounds.Y;

                    txtActionDetails.Location = p; 
                    txtActionDetails.Height   = lvsi.Bounds.Height;
                    txtActionDetails.Width    = lstEmoteEditor.Columns[(int)EditorColumns.Text].Width;
                    txtActionDetails.Text     = lvsi.Text;
                    txtActionDetails.Tag      = lvi.Index;
                    txtActionDetails.Visible  = true;
                    txtActionDetails.BringToFront();
                    txtActionDetails.Focus();
                    break;
                    }

                case EmoteLine.LineType.KEY:
                    // Show a dialog asking for a key
                    break;

                case EmoteLine.LineType.LOTROFUNCTION:
                    {
                    // Show the menu of functions
                    ListViewItem lvi = lstEmoteEditor.Items[nRow];
                    ListViewItem.ListViewSubItem lvsi = lvi.SubItems[(int)EditorColumns.Text];
                    Point p = lstEmoteEditor.Location;
                    p.X += lvsi.Bounds.X; p.Y += lvsi.Bounds.Y;
                    mnuLOTROCommands.Show(this, p) ;
                    break;
                    }
            }
            return;
        }

        private void ShowWeightEditor(int nRow)
        {   //====================================================================
            return;
        }

        private void ShowTypeEditor(int nRow)
        {   //====================================================================
            // Get the location of the subitem in client coords
            ListViewItem lvi = lstEmoteEditor.Items[nRow];
            ListViewItem.ListViewSubItem lvsi = lvi.SubItems[(int)EditorColumns.Action];

            Point p = lstEmoteEditor.Location;
            p.X += lvsi.Bounds.X; p.Y += lvsi.Bounds.Y;

            cmbActionType.Location = p;
            cmbActionType.Height   = lvsi.Bounds.Height;
            cmbActionType.Width    = lstEmoteEditor.Columns[(int)EditorColumns.Action].Width;
            cmbActionType.Tag      = lvi.Index;
            cmbActionType.SelectedIndex = -1;
            
            foreach (NamedEmoteLine nel in cmbActionType.Items)
            {
                if (lvi.Tag != null && nel.Type == ((EmoteLine)lvi.Tag).Channel)
                {
                    cmbActionType.SelectedItem = nel;
                    break;
                }
            }
            cmbActionType.Visible  = true;
            cmbActionType.Focus();
            cmbActionType.BringToFront();
            return;
        }

        private void OnEmoteEditorTextKeyPress(object sender, KeyPressEventArgs e)
        {   //====================================================================
            // Handle tab, return, and escape
            return;
        }

        private void OnEmoteEditorTextLoseFocus(object sender, EventArgs e)
        {   //====================================================================
            int nRow = (int)txtActionDetails.Tag; 
            lstEmoteEditor.Items[nRow].SubItems[(int)EditorColumns.Text].Text = txtActionDetails.Text;
            if (null != lstEmoteEditor.Items[nRow].Tag as EmoteLine)
            {
                ((EmoteLine)(lstEmoteEditor.Items[nRow].Tag)).Text = txtActionDetails.Text;
            }
            txtActionDetails.Visible = false;
           return;
        }

        private void CreateCommandMenus()
        {   //====================================================================
            mnuLOTROCommands.Items.Clear();
            String[] astrCats = Enum.GetNames(typeof(LotroCommands.Categories));
            foreach (LotroCommands.Categories cat in Enum.GetValues(typeof(LotroCommands.Categories)))
            {
                if (cat != LotroCommands.Categories.Unknown)
                {
                    String strCatName = Enum.GetName(typeof(LotroCommands.Categories), cat);
                    ToolStripItem tsi = mnuLOTROCommands.Items.Add(strCatName);
                    ToolStripDropDownItem tsddi = tsi as ToolStripDropDownItem;
                    foreach (LotroCommand lc in LotroCommands.Commands)
                    {
                        if (lc.Name != "" && lc.Category == cat)
                        {
                            ToolStripItem tsi2 = tsddi.DropDownItems.Add(lc.Name, null, OnPickCommand);
                            tsi2.ToolTipText   = lc.Description;
                            tsi2.Tag = lc;
                        }
                    } // Loop over functions
                } // Skip Unknown category. It's a black hole for junk.
            } // Loop over categories
            return;
        }

        private void OnPickCommand(object sender, EventArgs e)
        {   //====================================================================
            lstEmoteEditor.SelectedItems[0].SubItems[(int)EditorColumns.Text].Text = ((LotroCommand)((ToolStripItem)sender).Tag).Description;
            return;
        }
    }

    // A data bag for the combo box
    internal class NamedEmoteLine
    {
        public String             Name {get; private set;}
        public EmoteLine.LineType Type {get; private set;}
        public NamedEmoteLine(EmoteLine.LineType type, String name)
        {
            Type = type;
            Name = name;
            return;
        }
    }
}

