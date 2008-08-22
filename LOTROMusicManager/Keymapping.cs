using System;
using System.Collections.Generic;
using System.IO;

namespace LotroMusicManager
{
    [Serializable()]
    public class BuckyBits
    {   //====================================================================
        public Boolean Shift   {get; set;}
        public Boolean Control {get; set;}
        public Boolean Alt     {get; set;}
        public Boolean Windows {get; set;}
        
        public BuckyBits() {Shift = false; Control = false; Alt = false; Windows = false; return;}
    }

    [Serializable()]
    public class MappedLotroCommand : LotroCommand
    {
        private static Object _lock = new Object();
        private static FileSystemWatcher _fsw = null;

        public short                    MappedScanCode {get; set;}
        public BuckyBits                Bits           {get; set;}

        public MappedLotroCommand(LotroCommands.Categories cat, String strName, String strDesc)
        {
            Bits         = new BuckyBits();
            Category     = cat;
            Name         = strName;
            Description  = strDesc;
            return;
        }
        public MappedLotroCommand(LotroBindingCommand kc)
        {
            Bits         = new BuckyBits();
            Category     = kc.Category;
            Name         = kc.Name;
            Description  = kc.Description;
            return;
        }

    
        static private Dictionary<String, MappedLotroCommand> _functions;
        static public  Dictionary<String, MappedLotroCommand> Functions
        {
            private set {return;}
            get
            {
                Dictionary<String, MappedLotroCommand> dicRet = new Dictionary<string,MappedLotroCommand>();
                lock(_lock)
                {
                    if (null == _functions) ResetFunctionList();
                    if (null == _fsw)       CreateWatcher();
                    dicRet = _functions;
                }
                return dicRet;
            }
        }

        private static void ResetFunctionList()
        {   //====================================================================
            lock(_lock)
            {
                _functions = new Dictionary<string, MappedLotroCommand>();
                foreach (LotroCommand kc in LotroCommands.Commands)
                {
                    
                    if (kc is LotroBindingCommand && !_functions.ContainsKey(((LotroBindingCommand)kc).MapfileName)) 
                    {
                        _functions.Add(((LotroBindingCommand)kc).MapfileName, new MappedLotroCommand((LotroBindingCommand)kc));
                    }
                }
            }
            return;
        }
      
        private static void CreateWatcher()
        {   //====================================================================
            // Turn off notifications so we don't have unbound recursion
            if (_fsw != null) _fsw.Changed -= OnChanged;
            _fsw = new FileSystemWatcher();
            
            ReadMapfile();

            // Start up notifications
            _fsw.Path   = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\The Lord of the Rings Online";
            _fsw.Filter = "lotro.keymap";
            _fsw.NotifyFilter = NotifyFilters.LastWrite;
            _fsw.Changed += new FileSystemEventHandler(OnChanged);
            return;
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {   //====================================================================
            // Called on a fresh thread when the keymap changes. Need to reinit.
            ReadMapfile();
            return;
        }

        private static void ReadMapfile()
        {   //====================================================================
            lock(_lock)
            {
                FileInfo fi = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\The Lord of the Rings Online\lotro.keymap");
                StreamReader sr = new StreamReader(fi.FullName);
                ResetFunctionList();
                while (!sr.EndOfStream)
                {
                    String s = sr.ReadLine().Trim();

                    // A line we care about will be in this form:
                    //    SelectOutfit1 [ User [ 0 DIK_NUMPAD1 ] 0x00000002 ]
                    // There are loads of options in the mapping file that
                    // we're just going to ignore. If they're found, we won't 
                    // bother to support the mapping. Specifically, anything
                    // except the keyboard is ignored.
                    //
                    // Alternate form that has to work:
                    //    MusicEndSong [ Old [ 0 DIK_GRAVE ] ]
                    //
                    //
                    // Items split across several lines aren't supported:
                    //    MovementForwardCameraMovementToggleMouseSteer
                    //    [
                    //      Old [ 1 DIMOFS_BUTTON1 ]
                    //      0x00000040
                    //    ]
                    String[] astrs = s.Split(new char[] {'[', ']'});
                    String strFunctionName  = astrs[0].Trim();
                    if (0 < strFunctionName.Length && astrs.Length > 3)
                    {
                        String strKeyName = astrs[2].Trim();
                               strKeyName = strKeyName.Substring(strKeyName.IndexOf(' ') + 1);
                        String strBits    = astrs[3].Trim(); if (strBits.StartsWith("0x")) strBits = strBits.Substring(2);
                        Int32  nBits      = strBits.Length > 0 ? Int32.Parse(strBits.Split(new char[] {' ', '\t'})[0]) : 0;

                        if (Functions.ContainsKey(strFunctionName) && DIMap.Functions.ContainsKey(strKeyName))
                        {
                            Functions[strFunctionName].MappedScanCode = (short)DIMap.Functions[strKeyName].ScanCode;
                            Functions[strFunctionName].Bits.Shift     = ((nBits & 0x01) != 0) ? true : false;
                            Functions[strFunctionName].Bits.Control   = ((nBits & 0x02) != 0) ? true : false;
                            Functions[strFunctionName].Bits.Alt       = ((nBits & 0x04) != 0) ? true : false;
                            Functions[strFunctionName].Bits.Windows   = ((nBits & 0x08) != 0) ? true : false;
                        } // Have the function in our list of interesting ones
                    } // Found a reasonable line
                } // Loop reading file
            } // Lock
            return;
        }
    }

    public class DIMap
    {   //====================================================================
        // Use DIMap.Functions[FunctionName] to get a DIMap for a given function
        // For example: DIMap.Functions["SelectOutfit1"].DisplayName
        public String       Name        {get; private set;}
        public String       DisplayName {get; private set;}
        public int          ScanCode    {get; private set;}

        private static Dictionary<String, DIMap> _functions = null;
        public  static Dictionary<String, DIMap> Functions
        {
            get
            {
                if (null == _functions)
                {
                    _functions = new Dictionary<string, DIMap>();
                    foreach (DIMap dim in KeysArray)
                    {
                        _functions.Add(dim.Name, dim);
                    }
                }
                return _functions;
            }
            private set { return; }
        }

        public DIMap(String strName, String strDisplayName, int nScanCode)
        {
            Name        = strName;
            DisplayName = strDisplayName;
            ScanCode    = nScanCode;
            return;
        }

        #region DIK map
        private static DIMap[] KeysArray =
            {
                new DIMap("DIK_ESCAPE",          "ESC",           0x01),
                new DIMap("DIK_1",               "1",             0x02),
                new DIMap("DIK_2",               "2",             0x03),
                new DIMap("DIK_3",               "3",             0x04),
                new DIMap("DIK_4",               "4",             0x05),
                new DIMap("DIK_5",               "5",             0x06),
                new DIMap("DIK_6",               "6",             0x07),
                new DIMap("DIK_7",               "7",             0x08),
                new DIMap("DIK_8",               "8",             0x09),
                new DIMap("DIK_9",               "9",             0x0A),
                new DIMap("DIK_0",               "0",             0x0B),
                new DIMap("DIK_MINUS",           "-",             0x0C    /* - on main keyboard */),
                new DIMap("DIK_EQUALS",          "=",             0x0D),
                new DIMap("DIK_BACK",            "Backspace",     0x0E    /* backspace */),
                new DIMap("DIK_TAB",             "Tab",           0x0F),
                new DIMap("DIK_Q",               "Q",             0x10),
                new DIMap("DIK_W",               "W",             0x11),
                new DIMap("DIK_E",               "E",             0x12),
                new DIMap("DIK_R",               "R",             0x13),
                new DIMap("DIK_T",               "T",             0x14),
                new DIMap("DIK_Y",               "Y",             0x15),
                new DIMap("DIK_U",               "U",             0x16),
                new DIMap("DIK_I",               "I",             0x17),
                new DIMap("DIK_O",               "O",             0x18),
                new DIMap("DIK_P",               "P",             0x19),
                new DIMap("DIK_LBRACKET",        "[",             0x1A),
                new DIMap("DIK_RBRACKET",        "]",             0x1B),
                new DIMap("DIK_RETURN",          "Return/Enter",  0x1C    /* Enter on main keyboard */),
                new DIMap("DIK_A",               "A",             0x1E),
                new DIMap("DIK_S",               "S",             0x1F),
                new DIMap("DIK_D",               "D",             0x20),
                new DIMap("DIK_F",               "F",             0x21),
                new DIMap("DIK_G",               "G",             0x22),
                new DIMap("DIK_H",               "H",             0x23),
                new DIMap("DIK_J",               "J",             0x24),
                new DIMap("DIK_K",               "K",             0x25),
                new DIMap("DIK_L",               "L",             0x26),
                new DIMap("DIK_SEMICOLON",       ";",             0x27),
                new DIMap("DIK_APOSTROPHE",      "'",             0x28),
                new DIMap("DIK_GRAVE",           "`",             0x29    /* accent grave */),
                new DIMap("DIK_BACKSLASH",       "\\",            0x2B),
                new DIMap("DIK_Z",               "Z",             0x2C),
                new DIMap("DIK_X",               "X",             0x2D),
                new DIMap("DIK_C",               "C",             0x2E),
                new DIMap("DIK_V",               "V",             0x2F),
                new DIMap("DIK_B",               "B",             0x30),
                new DIMap("DIK_N",               "N",             0x31),
                new DIMap("DIK_M",               "M",             0x32),
                new DIMap("DIK_COMMA",           ",",             0x33),
                new DIMap("DIK_PERIOD",          ".",             0x34    /* . on main keyboard */),
                new DIMap("DIK_SLASH",           "/",             0x35    /* / on main keyboard */),
                new DIMap("DIK_MULTIPLY",        "Numeric keypad *",      0x37    /* * on numeric keypad */),
                new DIMap("DIK_SPACE",           "space",         0x39),
                new DIMap("DIK_CAPITAL",         "Capslock",      0x3A),
                new DIMap("DIK_F1",              "F1",            0x3B),
                new DIMap("DIK_F2",              "F2",            0x3C),
                new DIMap("DIK_F3",              "F3",            0x3D),
                new DIMap("DIK_F4",              "F4",            0x3E),
                new DIMap("DIK_F5",              "F5",            0x3F),
                new DIMap("DIK_F6",              "F6",            0x40),
                new DIMap("DIK_F7",              "F7",            0x41),
                new DIMap("DIK_F8",              "F8",            0x42),
                new DIMap("DIK_F9",              "F9",            0x43),
                new DIMap("DIK_F10",             "F10",           0x44),
                new DIMap("DIK_NUMLOCK",         "Numlock",       0x45),
                new DIMap("DIK_SCROLL",          "Scroll lock",       0x46    /* Scroll Lock */),
                new DIMap("DIK_NUMPAD7",         "Numeric keypad 7",  0x47),
                new DIMap("DIK_NUMPAD8",         "Numeric keypad 8",  0x48),
                new DIMap("DIK_NUMPAD9",         "Numeric keypad 9",  0x49),
                new DIMap("DIK_SUBTRACT",        "Numeric keypad -",  0x4A    /* - on numeric keypad */),
                new DIMap("DIK_NUMPAD4",         "Numeric keypad 4",  0x4B),
                new DIMap("DIK_NUMPAD5",         "Numeric keypad 5",  0x4C),
                new DIMap("DIK_NUMPAD6",         "Numeric keypad 6",  0x4D),
                new DIMap("DIK_ADD",             "Numeric keypad +",  0x4E    /* + on numeric keypad */),
                new DIMap("DIK_NUMPAD1",         "Numeric keypad 1",  0x4F),
                new DIMap("DIK_NUMPAD2",         "Numeric keypad 2",  0x50),
                new DIMap("DIK_NUMPAD3",         "Numeric keypad 3",  0x51),
                new DIMap("DIK_NUMPAD0",         "Numeric keypad 0",  0x52),
                new DIMap("DIK_DECIMAL",         "Numeric keypad .",  0x53    /* . on numeric keypad */),
                new DIMap("DIK_F11",             "F11",                                   0x57),
                new DIMap("DIK_F12",             "F12",                                   0x58),
                new DIMap("DIK_F13",             "F13",                                   0x64    /*                     (NEC PC98) */),
                new DIMap("DIK_F14",             "F14",                                   0x65    /*                     (NEC PC98) */),
                new DIMap("DIK_F15",             "F15",                                   0x66    /*                     (NEC PC98) */),
                new DIMap("DIK_NUMPADEQUALS",    "NUMPADEQUALS",                          0x8D    /* = on numeric keypad (NEC PC98) */),
                new DIMap("DIK_PREVTRACK",       "Previous Track (multimedia keyboard)",  0x90    /* Previous Track (DIK_CIRCUMFLEX on Japanese keyboard) */),
                new DIMap("DIK_AT",              "AT",                                    0x91    /*                     (NEC PC98) */),
                new DIMap("DIK_COLON",           "COLON",                                 0x92    /*                     (NEC PC98) */),
                new DIMap("DIK_UNDERLINE",       "UNDERLINE",                             0x93    /*                     (NEC PC98) */),
                new DIMap("DIK_KANJI",           "KANJI",                                 0x94    /* (Japanese keyboard)            */),
                new DIMap("DIK_STOP",            "STOP",                                  0x95    /*                     (NEC PC98) */),
                new DIMap("DIK_AX",              "AX",                                    0x96    /*                     (Japan AX) */),
                new DIMap("DIK_UNLABELED",       "UNLABELED",                             0x97    /*                        (J3100) */),
                new DIMap("DIK_NEXTTRACK",       "Next Track (multimedia keyboard)",      0x99    /* Next Track */),
                new DIMap("DIK_NUMPADENTER",     "Numeric keypad Enter",                  0x9C    /* Enter on numeric keypad */),
                new DIMap("DIK_MUTE",            "Mute (multimedia keyboard)",            0xA0    /* Mute */),
                new DIMap("DIK_CALCULATOR",      "Calculator (enhanced keyboard)",        0xA1    /* Calculator */),
                new DIMap("DIK_PLAYPAUSE",       "Play/Pause (multimedia keyboard)",      0xA2    /* Play / Pause */),
                new DIMap("DIK_MEDIASTOP",       "Stop (multimedia keyboard)",            0xA4    /* Media Stop */),
                new DIMap("DIK_VOLUMEDOWN",      "Volume down (multimedia keyboard)",     0xAE    /* Volume - */),
                new DIMap("DIK_VOLUMEUP",        "Volume up (multimedia keyboard)",       0xB0    /* Volume + */),
                new DIMap("DIK_WEBHOME",         "Launch web browser (enhanced keyboard)",0xB2    /* Web home */),
                new DIMap("DIK_NUMPADCOMMA",     "Numeric keypad comma",                  0xB3    /* , on numeric keypad (NEC PC98) */),
                new DIMap("DIK_DIVIDE",          "Numeric keypad /",                      0xB5    /* / on numeric keypad */),
                new DIMap("DIK_SYSRQ",           "SysReq",                                0xB7),
                new DIMap("DIK_PAUSE",           "Pause/Break",                           0xC5    /* Pause */),
                new DIMap("DIK_HOME",            "Arrow keypad Home",                     0xC7    /* Home on arrow keypad */),
                new DIMap("DIK_UP",              "Arrow keypad Up",                       0xC8    /* UpArrow on arrow keypad */),
                new DIMap("DIK_PRIOR",           "Arrow keypad PgUp",                     0xC9    /* PgUp on arrow keypad */),
                new DIMap("DIK_LEFT",            "Arrow keypad Left",                     0xCB    /* LeftArrow on arrow keypad */),
                new DIMap("DIK_RIGHT",           "Arrow keypad Right",                    0xCD    /* RightArrow on arrow keypad */),
                new DIMap("DIK_END",             "Arrow keypad End",                      0xCF    /* End on arrow keypad */),
                new DIMap("DIK_DOWN",            "Arrow keypad Down",                     0xD0    /* DownArrow on arrow keypad */),
                new DIMap("DIK_NEXT",            "Arrow keypad PgDown",                   0xD1    /* PgDn on arrow keypad */),
                new DIMap("DIK_INSERT",          "Arrow keypad insert",                   0xD2    /* Insert on arrow keypad */),
                new DIMap("DIK_DELETE",          "Arrow keypad Delete",                   0xD3    /* Delete on arrow keypad */),
                new DIMap("DIK_WEBSEARCH",       "Web Seearch (enhanced keyboard)",       0xE5    /* Web Search */),
                new DIMap("DIK_WEBFAVORITES",    "Web Favorites (enhanced keyboard)",     0xE6    /* Web Favorites */),
                new DIMap("DIK_WEBREFRESH",      "Web Refresh (enhanced keyboard)",       0xE7    /* Web Refresh */),
                new DIMap("DIK_WEBSTOP",         "Web Stop (enhanced keyboard)",          0xE8    /* Web Stop */),
                new DIMap("DIK_WEBFORWARD",      "Web Forward (enhanced keyboard)",       0xE9    /* Web Forward */),
                new DIMap("DIK_WEBBACK",         "Web Back (enhanced keyboard)",          0xEA    /* Web Back */),
                new DIMap("DIK_MYCOMPUTER",      "My Computer (enhanced keyboard)",       0xEB    /* My Computer */),
                new DIMap("DIK_MAIL",            "Launch Mail (enhanced keyboard)",       0xEC    /* Mail */),
                new DIMap("DIK_MEDIASELECT",     "Media Select (enhanced keyboard)",      0xED    /* Media Select */),

                // These are aliases for keys defined above
                new DIMap("DIK_BACKSPACE",       "Backspace",           0x0E            /* backspace */),
                new DIMap("DIK_NUMPADSTAR",      "Numeric keypad *",    0x37        /* * on numeric keypad */),
                new DIMap("DIK_CAPSLOCK",        "CapsLock",            0x3A         /* CapsLock */),
                new DIMap("DIK_NUMPADMINUS",     "Numeric keypad -",    0x4A        /* - on numeric keypad */),
                new DIMap("DIK_NUMPADPLUS",      "Numeric keypad +",    0x4E             /* + on numeric keypad */),
                new DIMap("DIK_NUMPADPERIOD",    "Numeric keypad .",    0x53         /* . on numeric keypad */),
                new DIMap("DIK_NUMPADSLASH",     "Numeric keypad /",    0xB5          /* / on numeric keypad */),
                new DIMap("DIK_UPARROW",         "Arrow keypad Up",     0xC8              /* UpArrow on arrow keypad */),
                new DIMap("DIK_PGUP",            "Arrow keypad PgUp",   0xC9           /* PgUp on arrow keypad */),
                new DIMap("DIK_LEFTARROW",       "Arrow keypad Left",   0xCB            /* LeftArrow on arrow keypad */),
                new DIMap("DIK_RIGHTARROW",      "Arrow keypad Right",  0xCD           /* RightArrow on arrow keypad */),
                new DIMap("DIK_DOWNARROW",       "Arrow keypad Down",   0xD0            /* DownArrow on arrow keypad */),
                new DIMap("DIK_PGDN",            "Arrow keypad PgDown", 0xD1            /* PgDn on arrow keypad */),
                //new DIMap(DIK_LCONTROL,        "Left control",      0x1D),
                //new DIMap(DIK_LSHIFT,          "Left shift",        0x2A),
                //new DIMap(DIK_RSHIFT,          "Right shift",        0x36),
                //new DIMap(DIK_LMENU,           "Left Atl",         0x38    /* left Alt */),
                //new DIMap(DIK_OEM_102,         "OEM_102",       0x56    /* <> or \| on RT 102-key keyboard (Non-U.S.) */),
                //new DIMap(DIK_KANA,            "KANA",          0x70    /* (Japanese keyboard)            */),
                //new DIMap(DIK_ABNT_C1,         "ABNT_C1",       0x73    /* /? on Brazilian keyboard */),
                //new DIMap(DIK_CONVERT,         "CONVERT",       0x79    /* (Japanese keyboard)            */),
                //new DIMap(DIK_NOCONVERT,       "NOCONVERT",     0x7B    /* (Japanese keyboard)            */),
                //new DIMap(DIK_YEN,             "YEN",           0x7D    /* (Japanese keyboard)            */),
                //new DIMap(DIK_ABNT_C2,         "ABNT_C2",       0x7E    /* Numpad . on Brazilian keyboard */),
                //new DIMap(DIK_RCONTROL,        "RCONTROL",      0x9D),
                //new DIMap(DIK_RMENU,           "RMENU",         0xB8    /* right Alt */),
                //new DIMap(DIK_LALT,            "LALT",          DIK_LMENU           /* left Alt */),
                //new DIMap(DIK_RALT,            "RALT",          DIK_RMENU           /* right Alt */),
                //new DIMap(DIK_LWIN,            "LWIN",          0xDB    /* Left Windows key */),
                //new DIMap(DIK_RWIN,            "RWIN",          0xDC    /* Right Windows key */),
                //new DIMap(DIK_APPS,            "APPS",          0xDD    /* AppMenu key */),
                //new DIMap(DIK_POWER,           "POWER",         0xDE    /* System Power */),
                //new DIMap(DIK_SLEEP,           "SLEEP",         0xDF    /* System Sleep */),
                //new DIMap(DIK_WAKE,            "WAKE",          0xE3    /* System Wake */),
            };
        #endregion
    }
}              
