using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace LotroMusicManager
{
    abstract public class MacroAction
    {
        public enum ActionType {UNKNOWN, 
                                KEY,
                                LOTROFUNCTION,
                                COMMAND, 
                                Say, 
                                Fellowship, 
                                Raid, 
                                Local, 
                                RP, 
                                UserChannel1, 
                                UserChannel2, 
                                UserChannel3, 
                                LFF,
                                Kinship,
                                KinOfficers,
                                Tribe,
                                TribeOfficers}
        public enum Channel    {Say, 
                                Fellowship, 
                                Raid, 
                                Local, 
                                RP, 
                                UserChannel1, 
                                UserChannel2, 
                                UserChannel3, 
                                LFF,
                                Kinship,
                                KinOfficers,
                                Tribe,
                                TribeOfficers};
        public class ChannelCommand 
        {
            public Channel Channel {get; private set;}
            public String  Command {get; private set;}
            public  ChannelCommand(Channel channel, String command)
            {
                Channel = channel;
                Command = command;
                return;
            }
        }
        public static ChannelCommand[] Channels =     
        {
            new ChannelCommand(Channel.Fellowship,    "f"),
            new ChannelCommand(Channel.Say,           "say"),
            new ChannelCommand(Channel.Raid,          "ra"),
            new ChannelCommand(Channel.Local,         "regional"),
            new ChannelCommand(Channel.RP,            "rpc"),
            new ChannelCommand(Channel.UserChannel1,  "1"),
            new ChannelCommand(Channel.UserChannel2,  "2"),
            new ChannelCommand(Channel.UserChannel3,  "3"),
            new ChannelCommand(Channel.LFF,           "l"),
            new ChannelCommand(Channel.Kinship,       "k"),
            new ChannelCommand(Channel.KinOfficers,   "ko"),
            new ChannelCommand(Channel.Tribe,         "t"),
            new ChannelCommand(Channel.TribeOfficers, "to")
        };


        //--------------------------------------------------------------------
        public ActionType Type      {get; private set;}
        public String     ErrorText {get; private set;}
        
        public abstract bool  Execute();
        public virtual  bool  MakeEditor(ListViewItem.ListViewSubItem lvsi){return false;}//TODO
        public virtual  String Describe() {return Enum.GetName(typeof(ActionType), Type);}

    }

    public class MacroActionSay : MacroAction
    {//====================================================================
        private static Random _rand = new Random();
        private Channel _channel;

        public class WeightedText 
        {
            public int      Weight  {get; set;} 
            public String   Text    {get; set;} 
            public WeightedText(int weight, String text) {Weight = weight; Text = text; return;}
            public WeightedText(String text)             {Weight = 1;      Text = text; return;}
            public WeightedText()                        {Weight = 1;      Text = String.Empty;}
        }
        public List<WeightedText> Lines {get; private set;}
        
        public MacroActionSay(Channel channel)
        {   //--------------------------------------------------------------------
            Lines = new List<WeightedText>();
            _channel = channel;
            return;
        }
        public MacroActionSay(Channel channel, String strText)
        {   //--------------------------------------------------------------------
            Lines = new List<WeightedText>();
            _channel = channel;
            Lines.Add(new WeightedText(strText));
            return;
        }

        public int Add(WeightedText wt)
        {   //--------------------------------------------------------------------
            Lines.Add(wt);
            return Lines.Count;
        }

        public override bool Execute()
        {   //--------------------------------------------------------------------
            if (null == Lines || Lines.Count == 0) return false;

            String str = Lines[0].Text;;
            
            if (Lines.Count > 1)
            {
                int nTotal = 0;
                foreach (WeightedText wt in Lines) nTotal += wt.Weight;
                
                // Okay...
                // Let's say we have 5 entries with weights 
                //  {1, 3, 2, 4, 4}
                // So they break the roll space into:
                //  {1, 4, 6, 10, 14}
                // e.g, if we roll a 7, we want the next-to-last
                int nPickedNumber  = _rand.Next(1, nTotal + 1); // For some stupid reason, the max is exclusive and the min is inclusive
                int nRunningTally  = 0;
                
                for (int i = 0; i < Lines.Count; i += 1)
                {
                    nRunningTally     += Lines[i].Weight;
                    if (nPickedNumber <= nRunningTally) {str = Lines[i].Text; break;}
                }
            }

            String strCommand = "say";
            foreach (ChannelCommand cc in Channels) 
            {
                if (cc.Channel == _channel) {strCommand = cc.Command; break;}
            }
            //RemoteController.ExecuteFunction("START_COMMAND");
            RemoteController.SendText("/" + strCommand + " " + str); 
            return true;
        }
    }

    public class MacroActionKey : MacroAction
    {   //====================================================================
        public SDK.VK Key       {get; private set;}
        public bool   Shift     {get; private set;}
        public bool   Control   {get; private set;}
        public bool   Alt       {get; private set;}
        public bool   Windows   {get; private set;}
        
        public MacroActionKey(SDK.VK vk)
        {   //--------------------------------------------------------------------
            Key = vk;
            Shift = Control = Alt = Windows = false;
        }

        public MacroActionKey(SDK.VK vk, BuckyBits bits)
        {   //--------------------------------------------------------------------
            Key     = vk;
            Shift   = bits.Shift;
            Alt     = bits.Alt;
            Control = bits.Control;
            Windows = bits.Windows;
        }

        public override bool Execute()
        {   //--------------------------------------------------------------------
            BuckyBits bits = new BuckyBits();
                bits.Shift = Shift;
                bits.Control = Control;
                bits.Alt = Alt;
                bits.Windows = Windows;

            RemoteController.SendKey(Key, bits);
            return true;
        }
    }

    public class MacroActionBinding : MacroAction
    {   //====================================================================
        public LotroFunction Function {get; private set;}
        
        public MacroActionBinding(LotroFunction lf)
        {   //--------------------------------------------------------------------
            Function = lf;
        }

        public override bool Execute()
        {   //--------------------------------------------------------------------
            RemoteController.ExecuteFunction(Function.FunctionName);
            return true;
        }

    }

    //public class MacroActionSlashCommand : MacroAction
    //{   //====================================================================
    //    public override bool Execute()
    //    {   //--------------------------------------------------------------------
    //        return true;
    //    }
    //}

    public class Macro
    {   //====================================================================
        public String Name      {get; private set;}
        public String ErrorText {get; private set;}

        private List<MacroAction>              _actions = new List<MacroAction>();
        public ReadOnlyCollection<MacroAction> Actions 
        {        get {return _actions.AsReadOnly();} 
         private set {return;}}

        public void ClearActions()                {_actions.Clear();}
        public int  AddAction(MacroAction action) {_actions.Add(action); return _actions.Count;}

        public Macro(String name)
        {   //====================================================================
            Name = name;
            return;
        }

        public bool Execute()
        {   //--------------------------------------------------------------------
            ErrorText = String.Empty;
            foreach (MacroAction action in _actions)
            {
                if (!action.Execute()) 
                {
                    ErrorText = action.ErrorText;
                    return false;
                }
            }
            return true;
        }
    }
}
