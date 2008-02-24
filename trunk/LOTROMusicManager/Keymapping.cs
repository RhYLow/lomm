using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LOTROMusicManager
{
    class Keys
    {
        public string  Mapped    {get; set;}
        public int     Modifiers {get; set;}
        public Keys() {Mapped = null; Modifiers = 0;}
        public Keys(string s, int mods) {Mapped = s; Modifiers = mods;}
    }

    class Keymapping
    {
        public Keys  WearOutfit1    {get; set;} // SelectOutfit1  
        public Keys  WearOutfit2    {get; set;} // SelectOutfit2 
        public Keys  WearBaseOutfit {get; set;} // SelectOutfitInventory 
        
        public Keys  EndABCPlay     {get; set;} // MusicEndSong
        public Keys  NoteKey(ABC.Pitch pitch) {return new Keys();} //TODO
        
        private Keymapping() {return;} // Private c'tor. This class must be accessed through a static accessor

        private static Keymapping _keys;
        public static Keymapping Keys()
        {
            if (null == _keys)
            {
                FileInfo fi = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\The Lord of the Rings Online\lotro.keymap");
                StreamReader sr = new StreamReader(fi.FullName);

                Keymapping keys = new Keymapping();
                while (!sr.EndOfStream)
                {
                    String s = sr.ReadLine();
                    if (s.Contains("SelectOutfit1"))         keys.WearOutfit1    = KeyFromLine(s);
                    if (s.Contains("SelectOutfit2"))         keys.WearOutfit2    = KeyFromLine(s);
                    if (s.Contains("SelectOutfitInventory")) keys.WearBaseOutfit = KeyFromLine(s);

                    if (s.Contains("MusicEndSong")) keys.EndABCPlay = KeyFromLine(s);
                }

                _keys = keys;
            }

            return _keys;
        }
        
        private static Keys KeyFromLine(string s)
        {
            return new Keys(s, 0);
        }
    }
}
