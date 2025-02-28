﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MarkedEditBox
{

    public partial class RegexTaggedEdit : RichTextBox
    {
    #region Defaults
        private static int HOVER_DEFAULT = 1500;
    #endregion 
    
    #region Events
        [Category("Action"), Description("")]
        public event EventHandler<CaretMovedEventArgs> CaretMoved;
    #endregion

    #region Properties
        //====================================================================
        public RegexTag[] Tags {get; set;}
        public Boolean AutoTag {get; set;}
        public int HoverDelay  {get; set;}

        // Properties for code, but not for design-time
        [Browsable(false)] public int InsertionRow  {get {return GetRow();} set{SetRow(value);}}
        [Browsable(false)] public int InsertionCol  {get {return GetCol();} set{SetCol(value);}}

        // Flag to prevent infinite recursion during InRescan. InRescan can cause OnTextChanged to be fired and OnTextChanged can call InRescan.
        private Boolean _bInRescan = false;

    #endregion        

        public RegexTaggedEdit()
        {   //--------------------------------------------------------------------
            InitializeComponent();
            AutoTag = true;
            if (HoverDelay <= 0) HoverDelay = HOVER_DEFAULT;

            tt.SetToolTip(this, "LOMM");
            tt.Site = this as ISite;
            
            return;
        }

        private RegexTag GetLineTag(String strLine)
        {   //====================================================================
            foreach (RegexTag ret in Tags)
            {
                if (ret.ControlsWholeLine && ret.Enabled)
                {
                    if (ret.MatchesIn(strLine).Count > 0)
                    {
                        return ret;
                    }
                }
            } // Loop over tags looking to see if the whole line is done
            return null;
        }

        private void SelectBackBufferLine(int iLine)
        {   //====================================================================
            rtfBackBuffer.SelectionStart = GetFirstCharIndexFromLine(iLine);
            if (iLine == rtfBackBuffer.Lines.Length - 1)
            {
                rtfBackBuffer.SelectionLength = rtfBackBuffer.Text.Length - rtfBackBuffer.SelectionStart;
            }
            else
            {
                rtfBackBuffer.SelectionLength = rtfBackBuffer.GetFirstCharIndexFromLine(iLine + 1) - rtfBackBuffer.SelectionStart;
            }
            return;
        }

        private void SetLineToTag(int iLine, RegexTag ret)
        {   //====================================================================
            SelectBackBufferLine(iLine);
            rtfBackBuffer.SelectionFont = ret.Font;
            rtfBackBuffer.SelectionColor = ret.ForeColor;
            rtfBackBuffer.SelectionBackColor = ret.BackColor;
            return;
        }
        
        private void SetMatchToTag(int iLine, Match m, RegexTag ret)
        {   //====================================================================
            rtfBackBuffer.SelectionStart = GetFirstCharIndexFromLine(iLine) + m.Index;
            rtfBackBuffer.SelectionLength = m.Length;
            rtfBackBuffer.SelectionFont = ret.Font;
            rtfBackBuffer.SelectionColor = ret.ForeColor;
            rtfBackBuffer.SelectionBackColor = ret.BackColor;            
            return;
        }

        public void RescanTags()
        {   //====================================================================
            if (_bInRescan) return; // Preventing an infinite loop when we're called by OnChange and then change the text
            
            // Reset the text, re-run the regexes, and re-apply the regex settings
            int iSelStart = SelectionStart;
            int iSelLen   = SelectionLength;

            rtfBackBuffer.Rtf = Rtf;
            
            for (int i = 0; i < Lines.Length; i += 1)
            {
                RegexTag retLine = GetLineTag(Lines[i]);
                if (null != retLine)
                {
                    SetLineToTag(i, retLine);
                }
                else
                {
                    SelectBackBufferLine(i);
                    rtfBackBuffer.SelectionFont = Font;
                    rtfBackBuffer.SelectionBackColor = BackColor;
                    rtfBackBuffer.SelectionColor = ForeColor;
                    
                    // So, do any of the non-line tags match any parts?
                    foreach (RegexTag ret in Tags)
                    {
                        if (!ret.ControlsWholeLine && ret.Enabled)
                        {
                            foreach (Match m in ret.MatchesIn(Lines[i]))
                            {
                                SetMatchToTag(i, m, ret);
                            } // Loop over matches
                        } // Not a whole-line tag
                    } // Loop over tags
                } // Not a line controlled by a tag
            } // Loop over lines

            // Prevent exceptions from leaving this flag stranded
            _bInRescan = true;
            try
            {
                Rtf = rtfBackBuffer.Rtf;
                SelectionStart  = iSelStart;
                SelectionLength = iSelLen;
            }
            finally {_bInRescan = false;}

            return;
        }

        protected int GetFirstCharOnLine(int nLine)
        {   //====================================================================
            for (int i = 0; i < Text.Length; i += 1)
            {
                if (GetLineFromCharIndex(i) == nLine)
                {
                    return i;
                }
            }
            return -1;
        }

        public void SelectLine(int nLine)
        {   //====================================================================
            if (0 == Lines.Length) return;
            if (nLine >= Lines.Length || nLine < -1) throw new ArgumentOutOfRangeException("nRow", "nRow must be between -1 and the number of declared lines in the text box");
            if (nLine == -1)
            {
                SelectionStart = 0;
                SelectionLength = 0;
                return;
            }

            int nStartChar = GetFirstCharOnLine(nLine);
            int nSelLen = Lines[nLine].Length;

            Select(nStartChar + nSelLen, -nSelLen);
            return;
        }

        protected override void OnTextChanged(EventArgs e)
        {   //====================================================================
            if (AutoTag) RescanTags();
            base.OnTextChanged(e);
            return;
        }

        protected String GetTTText(String strLine, int iChar)
        {   //====================================================================
            // Look for controlled lines first
            RegexTag retLine = GetLineTag(strLine);
            if (retLine != null)
            {
                if (retLine.ToolTip) return retLine.Comment;
                return String.Empty;
            }

            // Now look through the rest
            foreach(RegexTag ret in Tags)
            {
                if (ret.ToolTip && !ret.ControlsWholeLine)
                {
                    foreach (Match m in ret.MatchesIn(strLine))
                    {
                        if (m.Index <= iChar && m.Index + m.Length >= iChar) return ret.Comment;
                    }
                }
            }

            return String.Empty;
        }

        private void OnToolTipPopup(object sender, PopupEventArgs e)
        {   //====================================================================
        //    if (_bInToolTipPopup) return;
        //    int iChar     = GetCharIndexFromPosition(PointToClient(System.Windows.Forms.Control.MousePosition));
        //    int iLine     = GetLineFromCharIndex(iChar);
        //    iChar -= GetFirstCharIndexFromLine(iLine);

        //    if (iChar >0 && iLine > 0)
        //    {
        //        String strLine = Lines[iLine];
        //        String strTT = GetTTText(Lines[iLine], iChar);
        //        _bInToolTipPopup = true;
        //            if (strTT.Length > 0) tt.SetToolTip(this, strTT);
        //        _bInToolTipPopup = false;
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
            return;
        }

        private void OnContextMenuOpening(object sender, CancelEventArgs e)
        {   //====================================================================
        //    // Insert any items for the text under the pointer
        //    mntContextInfo.Visible = false;
        //    int iChar     = GetCharIndexFromPosition(PointToClient(System.Windows.Forms.Control.MousePosition));
        //    int iLine     = GetLineFromCharIndex(iChar);
        //    iChar -= GetFirstCharIndexFromLine(iLine);

        //    if (iChar >0 && iLine > 0)
        //    {
        //        String strLine = Lines[iLine];
        //        String strTT = GetTTText(Lines[iLine], iChar);
        //        if (strTT.Length > 0) 
        //        {
        //            mntContextInfo.Text = strTT;
        //            mntContextInfo.Visible = true;
        //        }
        //    }
            return;
        }

        private void OnContextMenuClosed(object sender, ToolStripDropDownClosedEventArgs e)
        {   //--------------------------------------------------------------------
            // Remove any items we added when opening
            return;
        }

        protected virtual void OnCaretMoved(CaretMovedEventArgs e)
        {   //====================================================================
            EventHandler<CaretMovedEventArgs> handler = CaretMoved;
            if (handler != null)
            {
                handler(this, e);
            }
            return;
        }

        protected override void OnSelectionChanged(EventArgs e)
        {   //====================================================================
            OnCaretMoved(new CaretMovedEventArgs(InsertionRow, InsertionCol));
            return;
        }

        protected int GetCol()
        {   //====================================================================
            Point p = new Point();
            SDK.GetCaretPos(out p);
            if (ClientRectangle.Contains(p))
            {
                int c = GetCharIndexFromPosition(p);
                return c - GetFirstCharIndexFromLine(GetLineFromCharIndex(c));
            }
            return 0;
        }
        
        protected int GetRow()
        {   //--------------------------------------------------------------------
            Point p = new Point();
            SDK.GetCaretPos(out p);
            if (ClientRectangle.Contains(p))
            {
                int c = GetCharIndexFromPosition(p);
                return GetLineFromCharIndex(c);
            }
            return 0;
        }
        
        protected void SetRow(int n)
        {   //====================================================================
            if (n > Lines.Length) n = Lines.Length;
            if (n < 0) n = 0;
            SelectionStart = GetFirstCharIndexFromLine(n) + InsertionCol;
            SelectionLength = 0;
            return;
        }
        
        protected void SetCol(int n)
        {   //--------------------------------------------------------------------
            if (n < 0) n = 0;
            //TODO: Handle inserting spaces if the row is too short
            SelectionStart = GetFirstCharIndexFromLine(InsertionRow) + n;
            SelectionLength = 0;
            return;
        }

        protected override void OnMouseHover(EventArgs e)
        {   //====================================================================
            // Pretend the cursor has left the window and returned so hover will
            // re-activate
            OnMouseEnter(e);
            base.OnMouseHover(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {   //--------------------------------------------------------------------
            // Restart the hover timer
            base.OnMouseEnter(e);
            SDK.TRACKMOUSEEVENT tme =  new SDK.TRACKMOUSEEVENT();
            tme.hwndTrack = this.Handle;            
            tme.cbSize = (uint)Marshal.SizeOf(tme);
            tme.dwFlags = (int)SDK.TrackMouseFlags.TME_HOVER;
            tme.dwHoverTime = 1000 * 3; //TODO: Config this
            SDK.TrackMouseEvent(ref tme);            
        }
    }

    public class CaretMovedEventArgs : EventArgs
    {
        private int _row; 
        private int _col;
        public CaretMovedEventArgs(int row, int col) {_row = row; _col = col; return;}
        public int Row {get {return _row;} private set {return;}}
        public int Col {get {return _col;} private set {return;}}
    }

    [Serializable()]
    public class FontSerializer
    {//====================================================================
        public String    FamilyName = String.Empty;
        public float     EmSize     = 12F;
        public FontStyle Style      = FontStyle.Regular;
        
        public FontSerializer()
        {   //====================================================================
            FamilyName = SystemFonts.DefaultFont.FontFamily.Name;
            EmSize     = SystemFonts.DefaultFont.SizeInPoints;
            Style      = SystemFonts.DefaultFont.Style;
            return;
        }

        public FontSerializer(Font f)
        {   //--------------------------------------------------------------------
            //TODO: Handle non-points measurements
            FamilyName = f.FontFamily.Name;
            EmSize     = f.SizeInPoints;
            Style      = f.Style;
            return;
        }

        public static implicit operator Font(FontSerializer rhs) {return new Font(rhs.FamilyName, rhs.EmSize, rhs.Style);}
    }

    [Serializable()]
    public class RegexTagBag
    {
        [XmlArray()] public RegexTag[]  Tags {get; set;}
        public RegexTagBag() {Tags = new RegexTag[0];}
        public RegexTagBag(int n) {Tags = new RegexTag[n];}
        public RegexTagBag(RegexTag[] aTags) {Tags = aTags;}
        static public implicit operator RegexTag[](RegexTagBag rhs) {return rhs.Tags;}
    }

    [Serializable()]
    public class RegexTag
    {//====================================================================
        public  String   Name       {get; set;}
        public  Boolean  Enabled    {get; set;}

        [Description("The regex text to match for the tag"), Category("Match")]   
        public  String   Expression             {get {return _strExpression;} 
                                                 set {_strExpression = value; ResetRegex();}}
        
        [Description("Whether to ignore whitespace in the Expression."), Category("Match")]   
        public  Boolean  IgnorePatternWhitespace {get {return _bIgnorePatternWhitespace;} 
                                                  set {_bIgnorePatternWhitespace = value; ResetRegex();}}
        [Description(), Category("Match")]   
        public  Boolean  ExplicitCapture         {get {return _bExplicitCapture;}         
                                                  set {_bExplicitCapture = value; ResetRegex();}}
        [Description("If true, this tag applies formatting to the whole line and prevents other tags from matching within the line"), 
        Category("Match")]   
        public  Boolean  ControlsWholeLine {get; set;}


        [Category("Display")] public  String   Comment    {get; set;}
        [Category("Display")] public  Boolean  ToolTip    {get; set;}

        [Category("Display")] public  Color    BackColor  {get; set;}
        [Category("Display")] public  Color    ForeColor  {get; set;}
        
        private Font _font = null;
        [XmlIgnore(), Category("Display")]  public Font           Font  // Show in properties UI as Display but do not serialize
        {
            get {if (_font == null) _font = new Font(FontShadow.FamilyName, FontShadow.EmSize, FontShadow.Style); return _font;}
            set {_font = value; FontShadow = new FontSerializer(_font);}
        }
        [Browsable(false)]                  public FontSerializer FontShadow {get; set;} // Public to get serialized

        private String   _strExpression = "";
        private Regex    _regex = new System.Text.RegularExpressions.Regex("");
        private Boolean  _bIgnorePatternWhitespace = false;
        private Boolean  _bExplicitCapture = false;

        public RegexTag()
        {   //====================================================================
            ControlsWholeLine = false;
            BackColor         = SystemColors.Window;
            ForeColor         = SystemColors.WindowText;
            Font              = null;
            Comment           = "";
            ToolTip           = true;
            Enabled           = true;
            return;
        }

        private void ResetRegex()
        {   //--------------------------------------------------------------------
            // A helper to recreate the regex object when any of the elements changes
            _regex = new Regex(Expression, RegexOptions.Compiled 
                                           | (_bExplicitCapture         ? RegexOptions.ExplicitCapture         : 0)
                                           | (_bIgnorePatternWhitespace ? RegexOptions.IgnorePatternWhitespace : 0));
            return;
        }

        public MatchCollection MatchesIn(String s)
        {   //====================================================================
            return _regex.Matches(s);
        }
    
        [OnSerializing()]
        internal void OnSerializing(StreamingContext context)
        {   //====================================================================
            FontShadow = new FontSerializer(Font);
            return;
        }

        [OnDeserialized()]
        internal void OnDeserialized(StreamingContext context)
        {   //====================================================================
            Font = FontShadow;
            return;
        }
    }
}
