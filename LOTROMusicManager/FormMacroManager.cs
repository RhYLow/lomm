using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using LotroMusicManager.Properties;

namespace LotroMusicManager
{
    public partial class FormMacroManager : Form
    {
        public Boolean NeedToolbarsRefreshed {get; set;}

        public FormMacroManager()
        {
            NeedToolbarsRefreshed = false;
            InitializeComponent();

            CreateMenus(); 
            return;
        }

        private void OnLoad(object sender, EventArgs e)
        {   //====================================================================
            CenterToParent();
            RefreshMacros();
            return;
        }

        private void RefreshMacros()
        {   //====================================================================
            lsvMacros.Items.Clear();
            imgMacros.Images.Clear();
            lstActions.Items.Clear();
            foreach (Macro m in Settings.Default.Macros.Items) 
            {
                ListViewItem lvi = new ListViewItem(m.Name);
                lvi.Tag = m;
                if (m.ImagePath != null && m.ImagePath != String.Empty) 
                {
                    try
                    {
                        imgMacros.Images.Add(m.ID, new System.Drawing.Bitmap(m.ImagePath));
                        lvi.ImageKey = m.ID;
                    } catch {;} // A throw just means we should ignore that image
                }
                lsvMacros.Items.Add(lvi);
            }
            lsvMacros.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            btnAddAction.Enabled = false;
            btnDelAction.Enabled = false;
            btnDelMacro.Enabled  = false;
            RefreshActions();
        }

        private void OnSelectedMacroChanged(object sender, EventArgs e)
        {   //====================================================================
            btnAddAction.Enabled = (lsvMacros.SelectedItems.Count != 0);
            btnDelAction.Enabled = (lsvMacros.SelectedItems.Count != 0);
            btnDelMacro.Enabled  = (lsvMacros.SelectedItems.Count != 0);
            RefreshActions();
            return;
        }

        private Macro SelectedMacro()
        {   //====================================================================
            if (lsvMacros.SelectedItems.Count == 0) return null;
            return (Macro)(lsvMacros.SelectedItems[0]).Tag;
        }

        private void RefreshActions()
        {   //====================================================================
            lstActions.Items.Clear();
            if (lsvMacros.SelectedItems.Count == 0) return;

            foreach (MacroAction ma in SelectedMacro().Actions)
            {
                lstActions.Items.Add(ma);
            }
            return;
        }

        private void OnNewMacro(object sender, EventArgs e)
        {   //====================================================================
            MakeNewMacro();
            return;
        }

        private void MakeNewMacro()
        {   //====================================================================
            String strName = FormInputPrompt.GetInput("New Macro", "Name:", String.Empty);
            if (strName == String.Empty) return;

            Macro mac = new Macro(strName);
            Settings.Default.Macros.Add(mac);

            RefreshMacros();
            ListViewItem[] alvi = lsvMacros.Items.Find(mac.Name, false);
            if (alvi.Length != 0) alvi[0].Selected = true;
            return;
        }

        private void OnMoveUp(object sender, EventArgs e)
        {   //====================================================================
            if (lstActions.SelectedIndices.Count == 0) return;

            int[] ai = new int[lstActions.SelectedItems.Count];
            int iLoc = 0;
            foreach (int i in lstActions.SelectedIndices) {ai[iLoc] = i; iLoc += 1;}

            SelectedMacro().MoveUp(ai);
            RefreshActions();
            foreach (int i in ai) if (i > 0) lstActions.SelectedIndices.Add(i - 1); else lstActions.SelectedIndices.Add(0);
            return;
        }

        private void OnMoveDown(object sender, EventArgs e)
        {   //--------------------------------------------------------------------
            if (lstActions.SelectedIndices.Count == 0) return;

            int[] ai = new int[lstActions.SelectedItems.Count];
            int iLoc = 0;
            foreach (int i in lstActions.SelectedIndices) {ai[iLoc] = i; iLoc += 1;}

            SelectedMacro().MoveDown(ai);
            RefreshActions();
            foreach (int i in ai) if (i < lstActions.Items.Count - 1) lstActions.SelectedIndices.Add(i + 1); else lstActions.SelectedIndices.Add(lstActions.Items.Count - 1);
            return;
        }

        private void OnDeleteMacro(object sender, EventArgs e)
        {   //====================================================================
            if (lsvMacros.SelectedItems.Count == 0) return;
            Settings.Default.Macros.Remove(SelectedMacro());
            RefreshMacros();
            NeedToolbarsRefreshed = true;
            return;
        }

        private void OnDeleteAction(object sender, EventArgs e)
        {   //====================================================================
            if (lstActions.SelectedIndices.Count == 0) return;
            
            int[] ai = new int[lstActions.SelectedItems.Count];
            int iLoc = 0;
            foreach (int i in lstActions.SelectedIndices) {ai[iLoc] = i; iLoc += 1;}

            SelectedMacro().RemoveActions(ai);
            RefreshActions();
            return;
        }

        private void OnNewAction(object sender, EventArgs e)
        {   //====================================================================
            mnuActions.Show(btnAddAction.Parent, btnAddAction.Location);
            return;
        }

        private void OnActionSelected(object sender, EventArgs e)
        {   //====================================================================
            // Nothing to copy, just a type
            switch ((MacroAction.ActionType)((ToolStripItem)sender).Tag)
            {
                default:
                    // ????
                    break;
                case MacroAction.ActionType.KEY:
                    {
                    MacroAction ma = new MacroActionKey();
                    ConfigureAndAddAction(ma);
                    break;
                    }
                case MacroAction.ActionType.SAY:
                    {
                    MacroAction ma = new MacroActionSay();
                    ConfigureAndAddAction(ma);
                    break;
                    }
            }
            return;
        }

        private void ConfigureAndAddAction(MacroAction ma)
        {   //--------------------------------------------------------------------
            // This is super ugly....
            ma.Edit();
            SelectedMacro().AddAction(ma);
            RefreshActions();
            return;
        }

        private void OnPickCommand(object sender, EventArgs e)
        {   //====================================================================
            ToolStripItem tsi = (ToolStripItem)sender;
            if (tsi.Tag is LotroBindingCommand)
            {
                MacroAction ma = new MacroActionKeyBinding((LotroBindingCommand)tsi.Tag);
                ConfigureAndAddAction(ma);
            }
            else
            if (tsi.Tag is LotroSlashCommand)
            {
                MacroAction ma = new MacroActionSlashCommand((LotroSlashCommand)tsi.Tag);
                ConfigureAndAddAction(ma);
            }
            RefreshActions();
            return;
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

        private void OnDoubleClickAction(object sender, EventArgs e)
        {   //====================================================================
            if (!(lstActions.SelectedItem is MacroAction)) return;
            MacroAction ma = (MacroAction)(lstActions.SelectedItem);
            ma.Edit();
            RefreshActions();
            return;            
        }

        private void OnMacroListMenuOpening(object sender, CancelEventArgs e)
        {
            // Is the selected item the one we context-clicked on? If not, select it
            // Do we have a macro selected?
            // If not, disable most items
        }

        private void OnActionListMenuOpening(object sender, CancelEventArgs e)
        {
            // Is the selected item the one we context-clicked on? If not, select it
            // Do we have an action selected?
            // If not, disable most items
        }

        private void OnToolbarEditorMenuOpening(object sender, CancelEventArgs e)
        {
            // Are we over an item?
            // If not, disable most items            
        }

        private void OnEditMacroDetailsClick(object sender, EventArgs e)
        {   //====================================================================
            Macro mac = SelectedMacro(); if (mac == null) return;
            FormMacroDetails frm = new FormMacroDetails(mac);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                mac.Name        = frm.MacroName;
                mac.Description = frm.MacroDescription;
                mac.ImagePath   = frm.MacroImagePath;
                foreach (FormToolbar frmToolbar in Toolbars.All) frmToolbar.RefreshToolbarItems(); //TODO: only refresh needed bars
                RefreshMacros();
            }
            return;
        }

    }
    
}
