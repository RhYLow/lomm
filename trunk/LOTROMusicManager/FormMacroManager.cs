using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LotroMusicManager.Properties;

namespace LotroMusicManager
{
    public partial class FormMacroManager : Form
    {
        public FormMacroManager()
        {
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
            //TODO: get this from saved properties
            lstMacros.Items.Clear();
            lstActions.Items.Clear();
            foreach (Macro m in Settings.Default.Macros.Items) lstMacros.Items.Add(m);
        }

        private void OnSelectedMacroChanged(object sender, EventArgs e)
        {   //====================================================================
            RefreshActions();
            return;
        }

        private void RefreshActions()
        {   //====================================================================
            lstActions.Items.Clear();
            if (lstMacros.SelectedItems.Count == 0) return;

            foreach (MacroAction ma in ((Macro)lstMacros.SelectedItems[0]).Actions)
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
            Settings.Default.Macros.Items.Add(mac);

            RefreshMacros();
            return;
        }

        private void OnMoveUp(object sender, EventArgs e)
        {   //====================================================================
            if (lstActions.SelectedIndices.Count == 0) return;

            int[] ai = new int[lstActions.SelectedItems.Count];
            int iLoc = 0;
            foreach (int i in lstActions.SelectedIndices) {ai[iLoc] = i; iLoc += 1;}

            ((Macro)lstMacros.SelectedItems[0]).MoveUp(ai);
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

            ((Macro)lstMacros.SelectedItems[0]).MoveDown(ai);
            RefreshActions();
            foreach (int i in ai) if (i < lstActions.Items.Count - 1) lstActions.SelectedIndices.Add(i + 1); else lstActions.SelectedIndices.Add(lstActions.Items.Count - 1);
            return;
        }

        private void OnDeleteMacro(object sender, EventArgs e)
        {   //====================================================================
            if (lstMacros.SelectedItems.Count == 0) return;
            Settings.Default.Macros.Items.Remove((Macro)lstMacros.SelectedItem);
            RefreshMacros();
            return;
        }

        private void OnDeleteAction(object sender, EventArgs e)
        {   //====================================================================
            if (lstActions.SelectedIndices.Count == 0) return;
            
            int[] ai = new int[lstActions.SelectedItems.Count];
            int iLoc = 0;
            foreach (int i in lstActions.SelectedIndices) {ai[iLoc] = i; iLoc += 1;}

            ((Macro)lstMacros.SelectedItem).RemoveActions(ai);
            RefreshActions();
            return;
        }

        private void OnRenameMacro(object sender, EventArgs e)
        {   //====================================================================
            if (lstMacros.SelectedItems.Count == 0) return;
            ((Macro)lstMacros.SelectedItem).Name = FormInputPrompt.GetInput("Rename Macro", "New name:", ((Macro)lstMacros.SelectedItem).Name);
            RefreshMacros();
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
            ((Macro)lstMacros.SelectedItem).AddAction(ma);
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

        private void OnAddMacroToToolbar(object sender, EventArgs e)
        {   //====================================================================
            if (lstMacros.SelectedIndex != -1)
            {
                ToolStripItem tsi = tsEditor.Items.Add(((Macro)lstMacros.SelectedItem).Name);
                tsi.Tag = (Macro)lstMacros.SelectedItem;
                tsi.Click += new EventHandler(OnToolbarClick);
            }
            return;
        }

        void OnToolbarClick(object sender, EventArgs e)
        {   //====================================================================
            ToolStripItem tsi = (ToolStripItem)sender;
            Macro mac = (Macro)tsi.Tag;
            mac.Execute();
            return;
        }

        private void OnAddToolbarSeparator(object sender, EventArgs e)
        {   //====================================================================
            ToolStripDropDownItem tsddi = (ToolStripDropDownItem)sender;

            Point pScreen = tsddi.Owner.Location;
            Point pClient = tsEditor.PointToClient(pScreen);
            ToolStripItem tsi = tsEditor.GetItemAt(pClient);
            
            ToolStripSeparator tss = new ToolStripSeparator();            
            if (tsi == null)
            {
                tsEditor.Items.Add(tss);
            }
            else
            {
                tsEditor.Items.Insert(tsEditor.Items.IndexOf(tsi) + 1, tss);
            }
            
            return;
        }

        private void OnRemoveToolbarItem(object sender, EventArgs e)
        {   //====================================================================
            ToolStripDropDownItem tsddi = (ToolStripDropDownItem)sender;

            Point pScreen = tsddi.Owner.Location;
            Point pClient = tsEditor.PointToClient(pScreen);
            ToolStripItem tsi = tsEditor.GetItemAt(pClient);
            if (tsi != null) tsEditor.Items.Remove(tsi);            
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

    }
    
}
