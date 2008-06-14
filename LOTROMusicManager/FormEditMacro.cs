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
        };

        private Form _frmParent;
        
        private Macro _macro = new Macro("");
        
        public FormEditMacro(Form frmParent)
        {
            _frmParent = frmParent;
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {   //====================================================================
            ArrayList alLineTypes = new ArrayList();
            foreach(MacroAction.ActionType at in Enum.GetValues(typeof(MacroAction.ActionType)))
            {
                alLineTypes.Add(new NamedMacroAction(at, Enum.GetName(typeof(MacroAction.ActionType), at)));
            }

            cmbActionType.DataSource = alLineTypes;
            cmbActionType.DisplayMember = "Name";

            CreateMenus(); // Read the categories and functions and build the menus from that

            UpdateListView();

            Location = new Point(_frmParent.Location.X + (_frmParent.Width - Width)/2, _frmParent.Location.Y + 50);
            return;
        }

        private void UpdateListView()
        {   //====================================================================
            //throw new NotImplementedException();
            return;
        }

        private void ShowTypeEditor(int nRow)
        {   //====================================================================
            // Get the location of the subitem in client coords
            ListViewItem lvi = lstEmoteEditor.Items[nRow];
            ListViewItem.ListViewSubItem lvsi = lvi.SubItems[(int)EditorColumns.Action];

            Point p = lstEmoteEditor.Location;
            p.X += lvsi.Bounds.X; p.Y += lvsi.Bounds.Y;

            mnuActions.Tag = nRow;
            mnuActions.Show(this, p);
            return;
        }

        private void OnActionSelected(object sender, EventArgs e)
        {   //====================================================================
            ToolStripItem tsi = (ToolStripItem)sender;
            switch ((MacroAction.ActionType)tsi.Tag)
            {
                case MacroAction.ActionType.UNKNOWN:
                    // Weird.
                    #if DEBUG
                        //TODO: Some type of ASSERT
                    #endif 
                    break;

                case MacroAction.ActionType.SAY:
                    AddSayAction();
                    break;

                case MacroAction.ActionType.KEY:
                    AddKeyAction();
                    break;

                case MacroAction.ActionType.COMMAND:
                    // Do nothing. We don't care about this one.
                    break;
            }
            return;
        }

        private void AddKeyAction()
        {   //====================================================================
            int n = _macro.AddAction(new MacroActionKey());
            ListViewItem lvi = lstEmoteEditor.Items.Add(_macro.Actions[n].Describe());
            ListViewItem.ListViewSubItem lvsi = lvi.SubItems[(int)EditorColumns.Text];
            _macro.Actions[n].Edit();
            return;
        }

        private void AddSayAction()
        {   //====================================================================
            int n = _macro.AddAction(new MacroActionSay()); 
            MacroAction ma = _macro.Actions[n];
            ma.Edit();
            lstEmoteEditor.Items.Add(new ListViewItem(new string[] {ma.DescribeType(), ma.Describe()}));
            return;
        }

        private void AddBindingCommandAction()
        {   //====================================================================
            int n = _macro.AddAction(new MacroActionKeyBinding());
            ListViewItem lvi = lstEmoteEditor.Items.Add(_macro.Actions[n].Describe());
            ListViewItem.ListViewSubItem lvsi = lvi.SubItems[(int)EditorColumns.Text];
            _macro.Actions[n].Edit();
            return;
        }

        private void AddSlashCommandAction()
        {   //====================================================================
            int n = _macro.AddAction(new MacroActionSlashCommand());
            ListViewItem lvi = lstEmoteEditor.Items.Add(_macro.Actions[n].Describe());
            ListViewItem.ListViewSubItem lvsi = lvi.SubItems[(int)EditorColumns.Text];
            _macro.Actions[n].Edit();
            return;
        }

        private void OnPickCommand(object sender, EventArgs e)
        {   //====================================================================
            ToolStripItem tsi = (ToolStripItem)sender;
            LotroCommand  lc  = (LotroCommand)(tsi.Tag);
            if (lc is LotroSlashCommand)
            {
                LotroSlashCommand lsc = (LotroSlashCommand)lc;
                int n = _macro.AddAction(new MacroActionSlashCommand(lsc));
                ListViewItem lvi = lstEmoteEditor.Items.Add(_macro.Actions[n].Describe());
                ListViewItem.ListViewSubItem lvsi = lvi.SubItems[(int)EditorColumns.Text];
                _macro.Actions[n].Edit();
            }
            else
            if (lc is LotroBindingCommand)
            {
                LotroBindingCommand lbc = (LotroBindingCommand)lc;
                int n = _macro.AddAction(new MacroActionKeyBinding(lbc));
                ListViewItem lvi = lstEmoteEditor.Items.Add(_macro.Actions[n].Describe());
                ListViewItem.ListViewSubItem lvsi = lvi.SubItems[(int)EditorColumns.Text];
                _macro.Actions[n].Edit();

            }
            return;
        }

        private void OnAddActionItem(object sender, EventArgs e)
        {   //====================================================================
            // Show the menu of everything we can add
            mnuActions.Show(btnAddItem.Owner, btnAddItem.Bounds.Location);
        }


        private void CreateMenus()
        {   //====================================================================
            mnuActions.Items.Clear();
            ToolStripDropDownItem tsddiCommands = null;
            foreach (MacroAction.ActionType cat in Enum.GetValues(typeof(MacroAction.ActionType)))
            {
                if (cat != MacroAction.ActionType.UNKNOWN)
                {
                    String strCat = Enum.GetName(typeof(MacroAction.ActionType), cat);
                    ToolStripItem tsi = mnuActions.Items.Add(StringExtensions.ToTitleCase(strCat), null, OnActionSelected);
                    tsi.Tag = cat;
                    if (cat == MacroAction.ActionType.COMMAND) tsddiCommands = (ToolStripDropDownItem)tsi;
                }
            }
            if (null == tsddiCommands) return;

            //--------------------------------------------------------------------
            String[] astrCats = Enum.GetNames(typeof(LotroCommands.Categories));
            foreach (LotroCommands.Categories cat in Enum.GetValues(typeof(LotroCommands.Categories)))
            {
                if (cat != LotroCommands.Categories.Unknown)
                {
                    String strCatName = Enum.GetName(typeof(LotroCommands.Categories), cat);
                    ToolStripItem tsiCat = tsddiCommands.DropDownItems.Add(strCatName);
                    ToolStripDropDownItem tsddi = (ToolStripDropDownItem)tsiCat;
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
    }

    // A data bag for the combo box
    internal class NamedMacroAction
    {
        public String                 Name {get; private set;}
        public MacroAction.ActionType Type {get; private set;}
        public NamedMacroAction(MacroAction.ActionType type, String name)
        {
            Type = type;
            Name = name;
            return;
        }
    }
}

