using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using LOTROMusicManager.Properties;

namespace LOTROMusicManager
{
    class ABC
    {
        public enum Octave {UNKNOWN, LOW, MED, HIGH}
        public class Pitch
        {
            public string Note   {get; private set;}
            public Octave Octave {get; private set;}
            public Pitch(string s, Octave o)
            {
                Octave = o;
                Note = null;
                if (PITCH_REGEX.IsMatch(s)) Note = s;
            }
            public static implicit operator string (Pitch rhs) {return rhs.Note == null ? String.Empty : rhs.Note;}
        }

        private static Regex HEADER_REGEX = new Regex("^[ \t]*([^ \t]:|%)",     RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        private static Regex PITCH_REGEX  = new Regex("[_=^]*[zZa-gA-G][,']*" , RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        
        public static bool IsHeader(String s) {return s.Length == 0 || HEADER_REGEX.IsMatch(s);}
        
        public static bool IsTitle      (String s){return s.StartsWith(Resources.ABCTagTitle,       StringComparison.CurrentCultureIgnoreCase);}
        public static bool IsNotes      (String s){return s.StartsWith(Resources.ABCTagNote,        StringComparison.CurrentCultureIgnoreCase);}
        public static bool IsKey        (String s){return s.StartsWith(Resources.ABCTagKey,         StringComparison.CurrentCultureIgnoreCase);}
        public static bool IsUnit       (String s){return s.StartsWith(Resources.ABCTagUnit,        StringComparison.CurrentCultureIgnoreCase);}
        public static bool IsTempo      (String s){return s.StartsWith(Resources.ABCTagTempo,       StringComparison.CurrentCultureIgnoreCase);}
        public static bool IsMeter      (String s){return s.StartsWith(Resources.ABCTagMeter,       StringComparison.CurrentCultureIgnoreCase);}
        public static bool IsAuthor     (String s){return s.StartsWith(Resources.ABCTagAuthor,      StringComparison.CurrentCultureIgnoreCase);}
        public static bool IsOrigin     (String s){return s.StartsWith(Resources.ABCTagOrigin,      StringComparison.CurrentCultureIgnoreCase);}
        public static bool IsHistory    (String s){return s.StartsWith(Resources.ABCTagHistory,     StringComparison.CurrentCultureIgnoreCase);}
        public static bool IsTranscriber(String s){return s.StartsWith(Resources.ABCTagTranscriber, StringComparison.CurrentCultureIgnoreCase);}
        public static bool IsLyrics     (String s){return s.StartsWith(Resources.ABCTagLyrics,      StringComparison.CurrentCultureIgnoreCase);}

        public static List<String> ParseLineAsPitches(String s)
        {//====================================================================
            List<String> astr = new List<string>();
            if (!IsHeader(s)) 
            {
                MatchCollection mc = PITCH_REGEX.Matches(s);
                foreach (Match m in mc)
                {   
                    astr.Add(m.Value);
                }
            }
            return astr;
        }

        //====================================================================
        public enum PITCH_ERROR { NOERROR, TOO_HIGH, TOO_LOW };
        public class PitchError : IComparable
        {
            public String Pitch      {get; private set;}
            public int    LocStart   {get; private set;}
            public int    Length     {get; private set;}
            public PITCH_ERROR Error {get; private set;}
            
            public PitchError() {Pitch = String.Empty; LocStart = -1; Length = -1; Error = PITCH_ERROR.NOERROR; return;}
            public PitchError(String sPitch, int nStart, PITCH_ERROR err)
            {
                Pitch    = sPitch;
                LocStart = nStart;
                Length   = Pitch.Length;
                Error    = err;
                return;
            }

        #region IComparable Members
            public int CompareTo(object obj)
            {
                return ((PitchError)obj).LocStart - LocStart;
            }
        #endregion
        }

        public static PitchError[] FindInvalidPitches(String s)
        {//====================================================================
            // Okay... a pitch is invalid IF:
            //  Capital letter and more than one comma: B,,
            //  Lower case letter and more than three commas: b,,,
            //  Lower case letter other than c and an apostrophe: d'
            //  Lower case c and more than one apostrophe: c''
            //  Upper case letter other than C and more than one apostrophes: B''
            //  Upper case C and more than two apostrophes: C''''
            //  Special cases:
            //      _C,
            //      _c,,
            //      ^c'
            //      ^C''
            //
            // Degenerate cases:
            //      ___B,
            //      ^^b'
            // etc.
            //
            // So, is this the regex pair?
            //  (?'low'_+C,)|(?'low'[A-G],{2,})|(?'low'_+c,,)|(?'low'[a-g],{3,})
            //  (?'high'[abd-g]'+)|(?'high'\^+c')|(?'high'[ABD-G]'{2,})|(?'high'C'{3,})|(?'high'\^+C'')
            Regex regexLow  = new Regex(@"(?'low'_+C,+)|(?'low'[A-G],{2,})|(?'low'_+c,{2,})|(?'low'[a-g],{3,})");
            Regex regexHigh = new Regex(@"(?'high'[abd-g]'+)|(?'high'\^+c'+)|(?'high'[ABD-G]'{2,})|(?'high'C'{3,})|(?'high'\^+C'{2,})");

            MatchCollection mcLow  = regexLow.Matches(s);
            MatchCollection mcHigh = regexHigh.Matches(s);

            PitchError[] ape = new PitchError[mcHigh.Count + mcLow.Count];
            int i = 0;
            foreach (Match m in mcHigh)
            {
                ape[i] = new PitchError(m.Value, m.Index, PITCH_ERROR.TOO_HIGH);
                i += 1;
            }
            foreach (Match m in mcLow)
            {
                ape[i] = new PitchError(m.Value, m.Index, PITCH_ERROR.TOO_LOW);
                i += 1;
            }
            Array.Sort(ape);
            return ape;
        }
    }
    
    class ABCLine
    {
        public String Text {get; set;}
        
        public ABCLine() {Text = "";}
        public ABCLine(String s) {Text = s;}

        public bool IsHeader     {get {return ABC.IsHeader     (Text);} private set {return;}}
        public bool IsTitle      {get {return ABC.IsTitle      (Text);} private set {return;}}
        public bool IsNotes      {get {return ABC.IsNotes      (Text);} private set {return;}}
        public bool IsKey        {get {return ABC.IsKey        (Text);} private set {return;}}
        public bool IsUnit       {get {return ABC.IsUnit       (Text);} private set {return;}}
        public bool IsTempo      {get {return ABC.IsTempo      (Text);} private set {return;}}
        public bool IsMeter      {get {return ABC.IsMeter      (Text);} private set {return;}}
        public bool IsAuthor     {get {return ABC.IsAuthor     (Text);} private set {return;}}
        public bool IsOrigin     {get {return ABC.IsOrigin     (Text);} private set {return;}}
        public bool IsHistory    {get {return ABC.IsHistory    (Text);} private set {return;}}
        public bool IsTranscriber{get {return ABC.IsTranscriber(Text);} private set {return;}}
        public bool IsLyrics     {get {return ABC.IsLyrics     (Text);} private set {return;}}

        public List<String> Pitches {get {return ABC.ParseLineAsPitches(Text);} private set {return;}}
    }
}
