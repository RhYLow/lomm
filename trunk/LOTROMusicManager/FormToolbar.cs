using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ComboButtonControl;

namespace LotroMusicManager
{
    public partial class FormToolbar : Form
    {
        public LotroToolbar Toolbar {get; private set;}
        const int HandleSize = 10;

        public LotroToolbar.BarDirection Direction 
        {get {return Toolbar.Direction;} 
         set {Toolbar.Direction = value; SetBarSize();}}
        
        public FormToolbar(LotroToolbar tb)
        {
            InitializeComponent();
            Toolbar = tb;
        }

    #region Form Methods
        private void OnLoad(object sender, EventArgs e)
        {   //====================================================================
            RefreshToolbarItems();
            if (Toolbar.Location != null) Location = Toolbar.Location;
            return;
        }

        private void OnActivated(object sender, EventArgs e)
        {   //====================================================================
            // Assume we were clicked
            //TODO: Fix bug: right-clicking when not active will click the button instead of showing menu
            ToolStripItem tsi = GetTSIForScreenPoint(Control.MousePosition);
            if (tsi != null) tsi.PerformClick();
            return;
        }
    #endregion

    #region Creating Toolbar Items
        public void RefreshToolbarItems()
        {   //====================================================================
            ts.Items.Clear();
            // Add the toolbar items
            foreach (LotroToolbarItem tbi in Toolbar.Items)
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
                            ToolStripComboBox tscb = new ToolStripComboBox();
                            ts.Items.Add(tscb);
                            tscb.DropDownStyle = ComboBoxStyle.DropDownList;
                            tscb.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
                            tscb.Tag = tbi;
                            tscb.ComboBox.DrawItem += new DrawItemEventHandler(OnDrawMacroChoice);
                            tscb.DropDown += new EventHandler(OnMacroListDropDown);
                            tscb.DropDownClosed += new EventHandler(OnMacroListDropDownClosed);
                            break;
                        }

                    case LotroToolbarItem.ItemType.SongList:
                        {
                            ComboButton cbobtn = new ComboButton();
                            ts.Items.Add(new ToolStripControlHost(cbobtn));
                            cbobtn.Button.Image = Properties.Resources.control_play_blue;
                            cbobtn.ComboDrawMode = DrawMode.OwnerDrawFixed;
                            cbobtn.BackColor = ts.BackColor;
                            cbobtn.ButtonImage = Properties.Resources.control_play_blue;
                            cbobtn.DrawItem += new EventHandler<DrawItemEventArgs>(OnDrawSongListItem);
                            cbobtn.ButtonClick += new EventHandler<EventArgs>(OnPlayFromFavoritesList);
                            cbobtn.DropDown += new EventHandler<EventArgs>(OnDropDownFavoritesList);                                                       
                            break;
                        }
                }
            }
            SetBarSize();
        }

    #endregion

    #region Toolbar State and Contents
        private ToolStripItem GetTSIForScreenPoint(Point pScreen)
        {   //====================================================================
            Point pClient = ts.PointToClient(pScreen);
            foreach (ToolStripItem tsiTest in ts.Items)
            {
                if (tsiTest.Bounds.Contains(pClient)) {return tsiTest;}
            }
            return null;
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

        private void SetBarSize()
        {   //====================================================================            
            if (Toolbar.Direction == LotroToolbar.BarDirection.Horizontal) 
            {
                ts.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                ts.Left = HandleSize;
                ts.Top  = 0;
                Width   = ts.PreferredSize.Width + HandleSize;
                Height  = ts.PreferredSize.Height;
            }
            else                                              
            {
                ts.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                ts.Left = 0;
                ts.Top  = HandleSize;
                Width   = ts.PreferredSize.Width;
                Height  = ts.PreferredSize.Height + HandleSize;
            }
            return;
        }

        private void OnFlip(object sender, EventArgs e)
        {   //====================================================================
            if (Direction == LotroToolbar.BarDirection.Horizontal) Direction = LotroToolbar.BarDirection.Vertical;
            else                                                   Direction = LotroToolbar.BarDirection.Horizontal;
            return;
        }
        
        void OnAddMacro(object sender, EventArgs e)
        {   //====================================================================
            if (!(sender is ToolStripDropDownItem)) return;
            ToolStripDropDownItem tsddi = (ToolStripDropDownItem)sender;
            if (!(tsddi.Tag is Macro)) return;
            Macro mac = (Macro)tsddi.Tag;
            Toolbar.Items.Add(new LotroToolbarItem(mac));
            RefreshToolbarItems();
            return;
        }

        private void OnRemoveItem(object sender, EventArgs e)
        {   //====================================================================
            if (!(sender is  ToolStripMenuItem)) return;
            ToolStripMenuItem tsmi = (ToolStripMenuItem) sender;
            if (!(tsmi.Tag is ToolStripItem)) return;
            ToolStripItem tsi = (ToolStripItem)tsmi.Tag;

            int n = ts.Items.IndexOf(tsi);
            Toolbar.Items.RemoveAt(n);
            ts.Items.Remove(tsi);
            
            RefreshToolbarItems();
            return;
        }
        
        private void OnEditMacroList(object sender, EventArgs e)
        {   //====================================================================
            ToolStripItem tsi = (ToolStripItem)sender;
            LotroToolbarItem ltbi = (LotroToolbarItem)tsi.Tag;
            FormListSelector frm = new FormListSelector(ltbi.Name, ltbi.Choices);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ltbi.Name    = frm.Name;
                ltbi.Choices = frm.CheckedItems;
            }
            return;
        }
    #endregion

    #region Execute LOTRO commands
        void OnPlayFromFavoritesList(object sender, EventArgs e)
        {   //====================================================================
            ComboButtonControl.ComboButton cb = sender as ComboButtonControl.ComboButton; if (cb == null) return;
            FavoriteSong fav = cb.SelectedItem as FavoriteSong; if (fav == null) return;
            RemoteController.SendText(String.Format(Properties.Resources.PlayFileCommand, fav.FileName, fav.Index));
            return;
        }

        void OnMacroButtonClick(object sender, EventArgs e)
        {   //====================================================================
            Macro mac = Macro.FromID((String)((ToolStripButton)sender).Tag);
            mac.Execute();
            return;
        }

        void OnMacroListDropDownClosed(object sender, EventArgs e)
        {   //====================================================================
            if (!(sender is ToolStripComboBox)) return;
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!(tscb.SelectedItem is MacroChoiceItem)) return;
            MacroChoiceItem mci = (MacroChoiceItem)tscb.SelectedItem;
            Macro.FromID(mci.ID).Execute();
            return;
        }
    #endregion 

    #region Display
        void OnDrawSongListItem(object sender, DrawItemEventArgs e)
            {   //====================================================================
                if (e.Index == -1) return;
                ComboButton  cb  = sender            as ComboButton;  if (cb == null)  return;
                FavoriteSong fav = cb.Items[e.Index] as FavoriteSong; if (fav == null) return;

                String strTitle     = fav.SongName + " ";
                String strDetails   = fav.FileName + ": " + fav.Index;

                Font   fontDetails  = new Font(cb.Font, FontStyle.Italic);
                
                int nTitleWidth   = TextRenderer.MeasureText(strTitle, cb.Font).Width;
                int nDetailsWidth = TextRenderer.MeasureText(strDetails, fontDetails).Width;
                    nTitleWidth   = Math.Min(nTitleWidth, e.Bounds.Width);
                    nDetailsWidth = Math.Min(nDetailsWidth, e.Bounds.Width - nTitleWidth);
                RectangleF rectfTitle   = new RectangleF(e.Bounds.X, e.Bounds.Y, nTitleWidth, e.Bounds.Height);
                RectangleF rectfDetails = new RectangleF(e.Bounds.X + nTitleWidth, e.Bounds.Y, nDetailsWidth, e.Bounds.Height);

                // Now we do the "simple" drawing.. as if anything wrapping the GDI is ever simple
                Brush  brTitle      = new SolidBrush(cb.ForeColor);
                Brush  brDetails    = new SolidBrush(Color.FromKnownColor(KnownColor.DarkGray));
                Brush  brBackground = new SolidBrush((e.State & DrawItemState.Selected) == DrawItemState.Selected ? Color.FromKnownColor(KnownColor.Highlight) : cb.BackColor);
                e.Graphics.FillRectangle(brBackground, e.Bounds);

                e.Graphics.DrawString(strTitle,   cb.Font,     brTitle,   rectfTitle);
                e.Graphics.DrawString(strDetails, fontDetails, brDetails, rectfDetails);

                if (null != brTitle)      brTitle.Dispose();
                if (null != brDetails)    brDetails.Dispose();
                if (null != fontDetails)  fontDetails.Dispose();
                if (null != brBackground) brBackground.Dispose();

                return;            
            }

        void OnDrawMacroChoice(object sender, DrawItemEventArgs e)
            {   //====================================================================
                if (!(sender is ComboBox)) return; ComboBox cbo = (ComboBox)sender;
                // System.Diagnostics.Debug.WriteLine("Index: " + e.Index + " Macro: " + mac.Name + " --- " + e.State);

                if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit)
                {
                    // In the edit area
                    Rectangle rectText = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 1, e.Bounds.Height - 1);
                    Brush brushBg = new SolidBrush(Color.FromKnownColor(KnownColor.White));
                    e.Graphics.FillRectangle(brushBg, rectText);

                    LotroToolbarItem ltbi = (LotroToolbarItem)GetTSIForScreenPoint(cbo.Parent.PointToScreen(new Point(cbo.Bounds.X, cbo.Bounds.Y))).Tag;
                    if (ltbi != null)
                    {
                        Font  fontText  = null;
                        Brush brushText = null;
                        try
                        {
                            fontText  = new Font(e.Font, FontStyle.Italic);
                            brushText = new SolidBrush(Color.Blue);
                            e.Graphics.DrawString(ltbi.Name, fontText, brushText, rectText);
                        }
                        catch {}
                        finally 
                        {
                            if (fontText  != null) fontText.Dispose();
                            if (brushText != null) brushText.Dispose();
                            if (brushBg   != null) brushBg.Dispose();
                        }
                    }
                }
                else
                if (e.Index != -1)  // We have an item to draw
                {
                    if (!(cbo.Items[e.Index] is MacroChoiceItem)) return; 
                    MacroChoiceItem mci = (MacroChoiceItem)cbo.Items[e.Index];
                    Macro mac = Macro.FromID(mci.ID);
                    // In the dropdown menu
                    // Draw the icon if we have one
                    if (mac.ImagePath != null && mac.ImagePath != String.Empty)
                    {
                        Image img = new Bitmap(mac.ImagePath);
                        Rectangle rectImage = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, 16, 16);
                        e.Graphics.DrawImage(img, rectImage);
                        img.Dispose();
                    }
                    // And draw the text
                    Rectangle rectText = new Rectangle(e.Bounds.X + 19, e.Bounds.Y + 1, e.Bounds.Width - 19, e.Bounds.Height - 1);
                    Brush brush = null;
                    try
                    {
                        brush = new SolidBrush((e.State & DrawItemState.Selected) == DrawItemState.Selected ? Color.FromKnownColor(KnownColor.Highlight) : cbo.BackColor);
                        e.Graphics.FillRectangle(brush, rectText);
                        e.Graphics.DrawString(mac.Name, e.Font, new SolidBrush(Color.Black), rectText);
                    }
                    catch {}
                    finally {brush.Dispose();}
                }

                // Do the focus stuff if needed
                e.DrawFocusRectangle();

                return;            
            }
    #endregion

    #region Just-in-time data
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
            // Fill in the Add list with standard items....
            mniAdd.DropDownItems.Clear();
            
            int nAddSeparator = mniAdd.DropDownItems.Add(new ToolStripMenuItem("Separator"));           
            mniAdd.DropDownItems[nAddSeparator].Click += 
                delegate(Object o, EventArgs e1) {Toolbar.Items.Add(new LotroToolbarItem(LotroToolbarItem.ItemType.Separator)); RefreshToolbarItems();};
            
            int nAddMacroList = mniAdd.DropDownItems.Add(new ToolStripMenuItem("Macro List"));          
            mniAdd.DropDownItems[nAddMacroList].Image = Properties.Resources.textfield_add;
            mniAdd.DropDownItems[nAddMacroList].Click += 
                delegate(Object o, EventArgs e2) {Toolbar.Items.Add(new LotroToolbarItem(LotroToolbarItem.ItemType.MacroList)); RefreshToolbarItems();};
            
            int nAddQuickPlay = mniAdd.DropDownItems.Add(new ToolStripMenuItem("Favorite ABC songs"));  
            mniAdd.DropDownItems[nAddQuickPlay].Click +=
                delegate(Object o, EventArgs e3) {Toolbar.Items.Add(new LotroToolbarItem(LotroToolbarItem.ItemType.SongList)); RefreshToolbarItems();};

            int nAddDefeaultItem = mniAdd.DropDownItems.Add(new ToolStripMenuItem("Prebuilt Item"));
            mniAdd.DropDownItems[nAddDefeaultItem].Image = Properties.Resources.wand;
            
            mniAdd.DropDownItems.Add(new ToolStripSeparator());

            //--------------------------------------------------------------------
            // ...and with all defined macros
            foreach (Macro mac in Properties.Settings.Default.Macros.Items)
            {
                ToolStripItem tsi = mniAdd.DropDownItems.Add(mac.Name);
                ToolStripMenuItem tsmi = (ToolStripMenuItem)tsi;
                tsmi.Tag = mac;
                try {tsmi.Image = new Bitmap(mac.ImagePath);} catch {;}
                tsmi.Click += new EventHandler(OnAddMacro);
            }
            
            ToolStripItem tsiClicked = GetTSIForScreenPoint(cms.Bounds.Location);
            mniEditMacroList.Visible = false;
            mniRemoveItem.Enabled    = false;
            if (tsiClicked is ToolStripButton)
            {
                mniRemoveItem.Enabled = true;
                mniRemoveItem.Tag     = tsiClicked;
            }
            else
            if (tsiClicked is ToolStripComboBox)
            {
                mniRemoveItem.Enabled    = true;
                mniRemoveItem.Tag        = tsiClicked;
                mniEditMacroList.Visible = true;
                mniEditMacroList.Tag     = tsiClicked.Tag;
            }
            else
            if (tsiClicked is ToolStripControlHost)
            {
                mniRemoveItem.Enabled    = true;
                mniRemoveItem.Tag        = tsiClicked;
            }
            else
            if (tsiClicked is ToolStripSeparator)
            {
                mniRemoveItem.Enabled = true;
                mniRemoveItem.Tag     = tsiClicked;
            }
            return;
        }

        void OnMacroListDropDown(object sender, EventArgs e)
        {   //====================================================================
            // Add the choices to the list
            if (!(sender is ToolStripComboBox)) return;
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!(tscb.Tag is LotroToolbarItem)) return;
            LotroToolbarItem ltbi = (LotroToolbarItem)tscb.Tag;
            tscb.Items.Clear();
            if (ltbi.Choices != null) foreach (String s in ltbi.Choices)
            {
                if (Macro.FromID(s) != null) tscb.Items.Add(new MacroChoiceItem(s));
            }
            return; 
        }

        void OnDropDownFavoritesList(object sender, EventArgs e)
        {   //====================================================================
            // Get the list of favorites
            ComboButtonControl.ComboButton cb = sender as ComboButtonControl.ComboButton;
            if (cb == null) return;
            cb.Items.Clear();
            int nDropDownWidth = cb.Width;
            foreach (FavoriteSong song in Properties.Settings.Default.FavoriteSongs.Items)
            {
                cb.Items.Add(song);
            
                int nTextWidth = (TextRenderer.MeasureText(song.ToString(), cb.ComboBox.Font)).Width;
                if (nTextWidth > nDropDownWidth) nDropDownWidth = nTextWidth;
                //System.Diagnostics.Debug.WriteLine("Width: " + nTextWidth.ToString() + " - " + song.ToString());
            }
            cb.DropDownWidth = nDropDownWidth;
            //System.Diagnostics.Debug.WriteLine("DropDownWidth = " + cb.DropDownWidth.ToString());
            return;
        }
    #endregion

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
                Toolbar.Location = Location;
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

        private void OnAddDefaultItems(object sender, EventArgs e)
        {
        }

    }
}
