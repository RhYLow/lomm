using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComboButtonControl
{
    public partial class ComboButton : UserControl
    {
        public enum ComboButtonLayoutType {ComboBeforeButton, ButtonBeforeCombo};
        [Category("Layout")] public ComboButtonLayoutType ComboButtonOrder {get; set;}

        public override Color BackColor {get {return base.BackColor;} set {cbo.BackColor = btn.BackColor = base.BackColor = value;}}
        
        // Act like a combobox
        [Category("Data")]      public ComboBox.ObjectCollection Items         {get {return cbo.Items;}         set {cbo.Items.Clear(); foreach (Object o in value) cbo.Items.Add(o);}}
        [Category("Behavior")]  public int                       DropDownWidth {get {return cbo.DropDownWidth;} set {cbo.DropDownWidth = value;}}
        [Category("Behavior")]  public DrawMode                  ComboDrawMode {get {return cbo.DrawMode;}      set {cbo.DrawMode = value;}}
        [Browsable(false)]      public Object                    SelectedItem  {get {return cbo.SelectedItem;}  set {cbo.SelectedItem  = value;}}
        [Browsable(false)]      public int                       SelectedIndex {get {return cbo.SelectedIndex;} set {cbo.SelectedIndex = value;}}
        
        // And act like a button
        [Category("Appearance")] public Image  ButtonImage {get {return btn.Image;} set {btn.Image = value;}}
        [Category("Appearance")] public String ButtonText  {get {return btn.Text;}  set {btn.Text  = value;}}

        // Events we forward
        [Category("Action"),   Description("")] public event EventHandler<EventArgs>            ComboClick;
        [Category("Action"),   Description("")] public event EventHandler<EventArgs>            ButtonClick;
        [Category("Action"),   Description("")] public event EventHandler<EventArgs>            DropDown;
        [Category("Behavior"), Description("")] public event EventHandler<EventArgs>            DropDownClosed;
        [Category("Behavior"), Description("")] public event EventHandler<DrawItemEventArgs>    DrawItem;
        [Category("Behavior"), Description("")] public event EventHandler<MeasureItemEventArgs> MeasureItem;
        [Category("Behavior"), Description("")] public event EventHandler<EventArgs>            SelectedIndexChanged;
        [Category("Behavior"), Description("")] public event EventHandler<EventArgs>            SelectionChangeCommitted;
        [Category("Behavior"), Description("")] public event EventHandler<EventArgs>            TextUpdate;
        
        // Escape hatches to get full control
        public Button   Button   {get; private set;}
        public ComboBox ComboBox {get; private set;}
        
        public ComboButton()
        { 
            ComboButtonOrder = ComboButtonLayoutType.ComboBeforeButton;
            InitializeComponent();
            Button = new Button();
            ComboBox = new ComboBox();
            Controls.Add(Button);
            Controls.Add(ComboBox);
        }

        protected override void OnResize(EventArgs e)
        {   //====================================================================
            btn.Width = btn.PreferredSize.Width;
            //MinimumSize.Width = btn.Width + cbo.MinimumSize.Width;
            //if (Width < MinimumSize.Width) {return;}
            switch (ComboButtonOrder)
            {
                case ComboButtonLayoutType.ComboBeforeButton:
                    btn.Left = Width - btn.Width;
                    cbo.Left = 0;
                    cbo.Width = btn.Left - 1;
                    break;

                case ComboButtonLayoutType.ButtonBeforeCombo:
                    btn.Left = 0;
                    cbo.Left = btn.Width + 1;
                    cbo.Width = Width - cbo.Left;
                    break;
            }
            base.OnResize(e);
        }

        private void HandleDropDown(object sender, EventArgs e)
        {   //====================================================================
            EventHandler<EventArgs> handler = DropDown;
            if (handler != null) handler(this, e);
            return;
        }

        private void HandleDropDownClosed(object sender, EventArgs e)
        {   //====================================================================
            EventHandler<EventArgs> handler = DropDownClosed;
            if (handler != null) handler(this, e);
            return;
        }

        private void HandleDrawItem(object sender, DrawItemEventArgs e)
        {   //====================================================================
            EventHandler<DrawItemEventArgs> handler = DrawItem;
            if (handler != null) handler(this, e);
            return;
        }

        private void HandleMeasureItem(object sender, MeasureItemEventArgs e)
        {   //====================================================================
            EventHandler<MeasureItemEventArgs> handler = MeasureItem;
            if (handler != null) handler(this, e);
            return;
        }

        private void HandleSelectedIndexChanged(object sender, EventArgs e)
        {   //====================================================================
            EventHandler<EventArgs> handler = SelectedIndexChanged;
            if (handler != null) handler(this, e);
            return;
        }

        private void HandleSelectionChangeCommitted(object sender, EventArgs e)
        {   //====================================================================
            EventHandler<EventArgs> handler = SelectionChangeCommitted;
            if (handler != null) handler(this, e);
            return;
        }

        private void HandleTextUpdate(object sender, EventArgs e)
        {   //====================================================================
            EventHandler<EventArgs> handler = TextUpdate;
            if (handler != null) handler(this, e);
            return;
        }

        private void HandleComboClick(object sender, EventArgs e)
        {   //====================================================================
            EventHandler<EventArgs> handler = ComboClick;
            if (handler != null) handler(this, e);
            return;
        }

        private void HandleButtonClick(object sender, EventArgs e)
        {   //====================================================================
            EventHandler<EventArgs> handler = ButtonClick;
            if (handler != null) handler(this, e);
            return;
        }
    }
}
