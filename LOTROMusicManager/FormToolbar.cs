using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LotroMusicManager
{
    public partial class FormToolbar : Form
    {
        private LotroToolbar _tb {get; set;}
        const int HandleSize = 10;

        public LotroToolbar.BarDirection Direction 
        {get {return _tb.Direction;} 
         set {_tb.Direction = value; SetBarSize();}}
        
        public FormToolbar(LotroToolbar tb)
        {
            InitializeComponent();
            _tb = tb;
        }

        private void OnContextMenuOpening(object sender, CancelEventArgs e)
        {   //====================================================================
            if (!(sender is ContextMenuStrip)) return;
            ContextMenuStrip cms = (ContextMenuStrip)sender;

            //--------------------------------------------------------------------
            // Fill in the View list with the toolbars
            mniView.DropDownItems.Clear();
            foreach (LotroToolbar tb in Properties.Settings.Default.Toolbars.Items)
            {
                ToolStripItem tsi = mniView.DropDownItems.Add(tb.Name);                
                ToolStripMenuItem tsmi = (ToolStripMenuItem)tsi;
                tsmi.Checked = tb.Visible;
                tsmi.CheckOnClick = true;
                tsmi.Tag = tb;
                tsmi.CheckedChanged += new EventHandler(OnToggleToolbarVisible);
            }

            //--------------------------------------------------------------------
            // Fill in the Add list with macros
            mniAdd.DropDownItems.Clear();
            foreach (Macro mac in Properties.Settings.Default.Macros.Items)
            {
                ToolStripItem tsi = mniAdd.DropDownItems.Add(mac.Name);
                ToolStripMenuItem tsmi = (ToolStripMenuItem)tsi;
                tsmi.Tag = mac;
                try {tsmi.Image = new Bitmap(mac.ImagePath);} catch {;}
                tsmi.Click += new EventHandler(OnAddMacro);
            }
            
            ToolStripItem tsiClicked = tsiClicked = GetTSIForScreenPoint(cms.Bounds.Location);
            if (tsiClicked is ToolStripButton)
            {
                mniRemoveItem.Enabled = true;
                mniRemoveItem.Tag = tsiClicked;
            }
            else
            if (tsiClicked is ToolStripComboBox)
            {
                mniRemoveItem.Enabled = true;
                mniRemoveItem.Tag = tsiClicked;
            }
            else
            if (tsiClicked is ToolStripSeparator)
            {
                mniRemoveItem.Enabled = true;
                mniRemoveItem.Tag = tsiClicked;
            }
        }

        private ToolStripItem GetTSIForScreenPoint(Point p)
        {   //====================================================================
            foreach (ToolStripItem tsiTest in ts.Items)
            {
                if (tsiTest.Bounds.Contains(ts.PointToClient(p))) {return tsiTest;}
            }
            return null;
        }

        void OnAddMacro(object sender, EventArgs e)
        {   //====================================================================
            if (!(sender is ToolStripDropDownItem)) return;
            ToolStripDropDownItem tsddi = (ToolStripDropDownItem)sender;
            if (!(tsddi.Tag is Macro)) return;
            Macro mac = (Macro)tsddi.Tag;
            _tb.Items.Add(new LotroToolbarItem(mac));
            RefreshToolbarItems();
            return;
        }

        void OnToggleToolbarVisible(object sender, EventArgs e)
        {//====================================================================
            if (!(sender is ToolStripMenuItem)) return;
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            if (!(tsmi.Tag is LotroToolbar)) return;
            LotroToolbar tb = (LotroToolbar)tsmi.Tag;
            tb.Visible = tsmi.Checked;
            //TODO: Refresh the toolbar universe
            return;
        }

        private void OnLoad(object sender, EventArgs e)
        {   //====================================================================
            RefreshToolbarItems();
            if (_tb.Location != null) Location = _tb.Location;
            return;
        }

        private void RefreshToolbarItems()
        {   //====================================================================
            ts.Items.Clear();
            // Add the toolbar items
            foreach (LotroToolbarItem tbi in _tb.Items)
            {
                switch (tbi.Type)
                {
                    default:
                    case LotroToolbarItem.ItemType.UNKNOWN:
                        // ???
                        break;

                    case LotroToolbarItem.ItemType.Macro:
                        {
                            Macro mac = Macro.FromID(tbi.ID);
                            if (null == mac) break;
                            ToolStripButton tsb = new ToolStripButton(mac.Name); 
                            tsb.Tag = mac.ID;
                            tsb.ToolTipText = mac.Name;
                            if (mac.ImagePath != null) try {tsb.Image = new Bitmap(mac.ImagePath); tsb.Text = String.Empty;} catch {;}
                            tsb.Click += new EventHandler(OnMacroButtonClick);
                            ts.Items.Add(tsb);
                            break;
                        }

                    case LotroToolbarItem.ItemType.Separator:
                        {
                            ts.Items.Add(new ToolStripSeparator());
                            break;
                        }

                    case LotroToolbarItem.ItemType.MacroList:
                        {
                            break;
                        }

                    case LotroToolbarItem.ItemType.SongList:
                        {
                            ts.Items.Add(new ToolStripSeparator());
                            ToolStripComboBox tscb = new ToolStripComboBox();
                            tscb.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                            FillComboWithFavoriteFiles(tscb);
                            ts.Items.Add(tscb);

                            ToolStripButton tsb = new ToolStripButton("Play");
                            tsb.Tag = tscb;
                            tsb.Click += new EventHandler(OnPlayFromFavoritesList);
                            ts.Items.Add(tsb);
                            ts.Items.Add(new ToolStripSeparator());
                            break;
                        }
                }
            }
            SetBarSize();
        }

        private void SetBarSize()
        {   //====================================================================            
            if (_tb.Direction == LotroToolbar.BarDirection.Horizontal) 
            {
                ts.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                ts.Left = HandleSize;
                ts.Top  = 0;
                Width  = ts.PreferredSize.Width + HandleSize;
                Height = ts.PreferredSize.Height;
            }
            else                                              
            {
                ts.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                ts.Left = 0;
                ts.Top  = HandleSize;
                Width = ts.PreferredSize.Width;
                Height = ts.PreferredSize.Height + HandleSize;
            }
            return;
        }

        void OnPlayFromFavoritesList(object sender, EventArgs e)
        {   //====================================================================
            ToolStripComboBox tsc = (ToolStripComboBox)((ToolStripButton)sender).Tag;
            //TODO: Play the selected song
            return;
        }

        private void FillComboWithFavoriteFiles(ToolStripComboBox tscb)
        {
            throw new NotImplementedException();
        }

        void OnMacroButtonClick(object sender, EventArgs e)
        {   //====================================================================
            Macro mac = Macro.FromID((String)((ToolStripButton)sender).Tag);
            mac.Execute();
            return;
        }

        private void OnFlip(object sender, EventArgs e)
        {   //====================================================================
            if (Direction == LotroToolbar.BarDirection.Horizontal) Direction = LotroToolbar.BarDirection.Vertical;
            else                                                   Direction = LotroToolbar.BarDirection.Horizontal;
            return;
        }

    
    #region Full Window Dragging
       private Point _ptOffsetWithinForm = new Point();
       private bool  _bDragging = false;
       private void OnMouseDown(object sender, MouseEventArgs e)
        {//==========================================================
            if (MouseButtons.Left == e.Button)
            { 
                // Action button. Start a window drag.
                _ptOffsetWithinForm = new Point(e.X, e.Y);
                _bDragging = true;
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {//==========================================================
            if (_bDragging)
            {
                // End any drag. Mouse is no longer down.
                _ptOffsetWithinForm = new Point(0, 0);
                _bDragging = false;
                
                // Save the new location for posterity
                _tb.Location = Location;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {//==========================================================
            // Are we dragging?
            if (_bDragging)
            {
                // Get the mouse position, get the screen version
                // and offset by the amount within the form to know
                // where to put the upper-left corner of the form
                Point ptMouseForm = new Point(e.X, e.Y);
                Point ptMouseScreen = PointToScreen(ptMouseForm);
                Location = new Point(ptMouseScreen.X - _ptOffsetWithinForm.X,
                                     ptMouseScreen.Y - _ptOffsetWithinForm.Y);
            } // Dragging
        }
    #endregion

        private void OnRemoveItem(object sender, EventArgs e)
        {   //====================================================================
            if (!(sender is  ToolStripMenuItem)) return;
            ToolStripMenuItem tsmi = (ToolStripMenuItem) sender;
            if (!(tsmi.Tag is ToolStripItem)) return;
            ToolStripItem tsi = (ToolStripItem)tsmi.Tag;

            int n = ts.Items.IndexOf(tsi);
            _tb.Items.RemoveAt(n);
            ts.Items.Remove(tsi);
            
            RefreshToolbarItems();
            return;
        }

        private void OnActivated(object sender, EventArgs e)
        {   //====================================================================
            // Assume we were clicked
            ToolStripItem tsi = GetTSIForScreenPoint(Control.MousePosition);
            if (tsi != null) tsi.PerformClick();
            return;
        }

        private void OnAddMacroSelector(object sender, EventArgs e)
        {
        }

        private void OnAddDefaultItems(object sender, EventArgs e)
        {
        }

        private void OnAddSeparator(object sender, EventArgs e)
        {   //====================================================================
            _tb.Items.Add(new LotroToolbarItem(LotroToolbarItem.ItemType.Separator));
            RefreshToolbarItems();
        }
    }
}
