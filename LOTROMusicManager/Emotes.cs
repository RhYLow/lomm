using System;
using System.Collections.Generic;
using System.Text;

namespace LOTROMusicManager
{
    // Emotes.
    //
    // Should be simple, and pretty much is, but I screwed it up several times
    // before finally diagramming it to figure out who needs a collection and
    // where the random element should live.
    //
    // This lovely diagram is a product of the great CodePlotter from 
    // AbstractSpoon. I also use the AbstractSpood ToDo list.
    //
    //  .-----------.  .-------------.
    //  |EmoteGroup >-->Emote        |
    //  | .Name     |  | .Name       |
    //  | .Groups   |  | .EmoteBlocks|
    //  | .Emotes   |  |(.Icon)      |
    //  |(.Icon)    |  |             |
    //  ·-----------·  | .Execute()  |
    //                 ·v------------·
    //                  |
    //    .-------------v-.
    //    |EmoteBlock     |
    //    | .Lines        |
    //    | .Chance       |
    //    |               |
    //    | .Execute()    |
    //    ·v--------------·
    //     |
    //  .--v-----------.
    //  |Line          |
    //  | .Channel     |
    //  | .Text        |
    //  |              |
    //  | .Execute()   |
    //  ·--------------·
    //
    [Serializable]
    public class BuckyBits
    {   //====================================================================
        public Boolean  Shift   {get; set;}
        public Boolean  Control {get; set;}
        public Boolean  Alt     {get; set;}
        
        public BuckyBits() {Shift = false; Control = false; Alt = false; return;}
    }
    
    [Serializable]
    public class EmoteLine
    {   //====================================================================
        public enum LineType {UNKNOWN, 
                              KEY, 
                              COMMAND, 
                              Say, 
                              Fellowship, 
                              Raid, 
                              Local, 
                              RP, 
                              Custom1, 
                              Custom2, 
                              Custom3, 
                              LFF}
               
        public LineType  Channel {get; set;}
        public String    Text    {get; set;}
        public BuckyBits Bits    {get; set;}

        public EmoteLine()
        {   //--------------------------------------------------------------------
            Channel = LineType.Say;
            Text    = String.Empty;
            Bits    = new BuckyBits();
        }

        public EmoteLine(LineType type, String strText)
        {   //--------------------------------------------------------------------
            Channel = type;
            Text    = strText;
            Bits    = new BuckyBits();
        }

        private void ExecuteStrings(String strPrefix, String strText)
        {   //--------------------------------------------------------------------
            RemoteController.SendText(strPrefix + strText);
        }

        public void Execute()
        {   //--------------------------------------------------------------------
            switch (Channel)
            {
                default:
                case LineType.UNKNOWN: 
                    break; //TODO: How did this happen?

                case LineType.COMMAND: 
                    ExecuteStrings("/", Text); //TODO: Get this from the current keymapping
                    break;                

                case LineType.KEY:
                    foreach (char ch in Text) RemoteController.SendChars(Text.ToCharArray(), Bits);
                    break;

                case LineType.Say:          ExecuteStrings("/say ",      Text);    break;
                case LineType.RP:           ExecuteStrings("/rpc ",      Text);    break;
                case LineType.Raid:         ExecuteStrings("/ra ",       Text);    break;
                case LineType.Local:        ExecuteStrings("/regional ", Text);    break;
                case LineType.Fellowship:   ExecuteStrings("/f ",        Text);    break;
                case LineType.Custom1:      ExecuteStrings("/1 ",        Text);    break; // That is slash-1 (one)
                case LineType.Custom2:      ExecuteStrings("/2 ",        Text);    break;
                case LineType.Custom3:      ExecuteStrings("/3 ",        Text);    break;
                case LineType.LFF:          ExecuteStrings("/l ",        Text);    break; // That is a slash-L, but LOTRO is case-sensitive about it
            }
            return;
        }
    }

    [Serializable]
    public class EmoteBlock
    {   //====================================================================
        // An "Emote Block" is a group of actions for an emote. Each action is usually
        // a line of text to /say, hence the idea that it's a "block" of text.
        // One action (or more, potentially) in the block may be a hotkey
        public List<EmoteLine> Lines  {get; set;}
        public int             Chance {get; set;}

        public EmoteBlock()
        {
            Chance = 1;
            Lines = new List<EmoteLine>();
        }

        public EmoteBlock(EmoteLine.LineType type, String[] aStrings)
        {
            Chance = 1;
            Lines = new List<EmoteLine>();
            foreach (String s in aStrings)
            {
                Lines.Add(new EmoteLine(type, s));
            }
        }
        
        public void Execute()
        {
            foreach (EmoteLine el in Lines) el.Execute();
            return;
        }
    }

    [Serializable]
    public class Emote
    {   //====================================================================
        private static Random _rand = new Random();
        
        public String Name {get; set;}
        public List<EmoteBlock> EmoteBlocks {get; set;}

        public Emote()
        {
            Name = String.Empty;
            EmoteBlocks = new List<EmoteBlock>();
        }

        public Emote(String strName, String[] aStrings)
        {
            Name = strName;
            EmoteBlocks = new List<EmoteBlock>();
            EmoteBlocks.Add(new EmoteBlock(EmoteLine.LineType.Say, aStrings));
            return;
        }

        public void Execute()
        {
            if (0 == EmoteBlocks.Count) return;

            // Pick one from the list
            int nTotal = 0;
            foreach (EmoteBlock eb in EmoteBlocks) nTotal += eb.Chance;
            
            // Okay...
            // Let's say we have 5 entries with weights 
            //  {1, 3, 2, 4, 4}
            // So they break the roll space into:
            //  {1, 4, 6, 10, 14}
            // e.g, if we roll a 7, we want the next-to-last
            int nPickedNumber  = _rand.Next(1, nTotal + 1); // For some stupid reason, the max is exclusive and the min is inclusive
            int nChosenIndex   = 0;
            int nRunningTally  = 0;
            
            for (int i = 0; i < EmoteBlocks.Count; i += 1)
            {
                nRunningTally     += EmoteBlocks[i].Chance;
                if (nPickedNumber <= nRunningTally) {nChosenIndex = i; break;}
            }
            
            EmoteBlocks[nChosenIndex].Execute();
            return;
        }
    }

    [Serializable]
    public class EmoteGroup
    {   //====================================================================
        public String           Name    {get; set;}
        public List<EmoteGroup> Groups  {get; set;}
        public List<Emote>      Emotes  {get; set;}

        public EmoteGroup()
        {
            Name = String.Empty;
            Groups = new List<EmoteGroup>();
            Emotes = new List<Emote>();
        }
    }
}
