using System.Drawing;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LotroMusicManager
{
    [Serializable()]
    public class LotroToolbarItem
    {
        public enum ItemType {UNKNOWN, Macro, Separator, MacroList, SongList}
        public String   ID       {get; set;}
        public ItemType Type     {get; set;}
        public String[] Choices  {get; set;}

        public LotroToolbarItem()                                {Type = ItemType.UNKNOWN; ID = String.Empty; Choices = null;}
        public LotroToolbarItem(Macro mac)                       {Type = ItemType.Macro;   ID = mac.ID;       Choices = null;}
        public LotroToolbarItem(ItemType type)                   {Type = type;             ID = String.Empty; Choices = null;}
        public LotroToolbarItem(ItemType type, String[] choices) {Type = type;             ID = String.Empty; Choices = choices;}
    }
    
    [Serializable()]
    public class LotroToolbar
    {
        public enum BarDirection {Horizontal, Vertical};
        public String       Name      {get; set;}
        public Point        Location  {get; set;}
        public BarDirection Direction {get; set;}
        public Boolean      Visible   {get; set;}
        [XmlArray()] public List<LotroToolbarItem> Items {get; set;}

        public LotroToolbar() {Name = String.Empty; Items = new List<LotroToolbarItem>(); Direction = BarDirection.Horizontal;}
    }

    [Serializable()]
    public class LotroToolbarList
    {
        [XmlArray()] public List<LotroToolbar> Items {get; set;}
        public LotroToolbarList() {Items = new List<LotroToolbar>();}
    }
}
