using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LotroMusicManager
{
    public partial class FormMacroManager : Form
    {
        private List<Macro> _macros = new List<Macro>();
        public FormMacroManager()
        {
            InitializeComponent();

            CreateMenus();

            Macro mac1 = new Macro("Minstrel Healing");
                mac1.AddAction(new MacroActionKeyBinding(new LotroBindingCommand("QUICKSLOT_10")));
                mac1.AddAction(new MacroActionSay(MacroActionSay.Channel.Fellowship, "Healing ;target for ~650 in 2 seconds"));
                mac1.AddAction(new MacroActionSay(MacroActionSay.Channel.Say, "/me reminds ;target of the strength of our purpose."));
                mac1.AddAction(new MacroActionKeyBinding(new LotroBindingCommand("SELECTION_LAST")));
            Macro mac2 = new Macro("Captain Pulling");
                mac2.AddAction(new MacroActionSlashCommand(new LotroSlashCommand("Pet Mode"), "guard")); 
                mac2.AddAction(new MacroActionSlashCommand(new LotroSlashCommand("Pet Mode"), "assist off"));
                mac2.AddAction(new MacroActionKeyBinding(new LotroBindingCommand("ToggleTargetMark3")));
                mac2.AddAction(new MacroActionSay( MacroActionSay.Channel.Fellowship, "Pulling the arrow...."));
            Macro mac3 = new Macro("Loremaster CC");
                mac3.AddAction(new MacroActionSay(MacroActionSay.Channel.Fellowship, "Mezzing ;target. You spank it, you tank it. Champions, this means you."));
                mac3.AddAction(new MacroActionKeyBinding(new LotroBindingCommand("QUICKSLOT_14")));

            _macros.Add(mac1);
            _macros.Add(mac2);
            _macros.Add(mac3);
        }

        private void OnLoad(object sender, EventArgs e)
        {   //====================================================================
            RefreshMacros();
            return;
        }

        private void RefreshMacros()
        {   //====================================================================
            //TODO: get this from saved properties
            lstMacros.Items.Clear();
            lstActions.Items.Clear();
            foreach (Macro m in _macros) lstMacros.Items.Add(m);
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
            _macros.Add(mac);

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
            _macros.Remove((Macro)lstMacros.SelectedItem);
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
    }
    
}
