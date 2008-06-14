using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

//====================================================================
// These classes organize "macros", which are collections of "actions"
// An action can be pressing a key, sending text to a channel, or 
// executing a Lotro "command" (as per LotroCommands.cs)
namespace LotroMusicManager
{
    [Serializable]
    abstract public class MacroAction
    {
        public enum ActionType {UNKNOWN, 
                                KEY,
                                COMMAND,
                                SAY};
        //--------------------------------------------------------------------
        public ActionType Type      {get; protected set;}
        public String     ErrorText {get; protected set;}
        
        public abstract bool  Execute();
        public virtual  bool  Edit(){return false;}
        public virtual  String Describe()     {return Enum.GetName(typeof(ActionType), Type);}
        public virtual  String DescribeType() {return Enum.GetName(typeof(ActionType), Type);}
        public override string ToString()     {return Describe();}

    }

    [Serializable]
    public class MacroActionSay : MacroAction
    {//====================================================================
        private static Random _rand = new Random();
        public Channel OutputChannel;

    #region Channel handling
        public enum Channel
        {
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
            TribeOfficers
        };
        public class ChannelCommand
        {   //--------------------------------------------------------------------
            // Nested data bag to make the Channels array
            public Channel Channel { get; private set; }
            public String Command { get; private set; }
            public String Name { get; private set; }
            public ChannelCommand(Channel channel, String command, String name)
            {
                Channel = channel;
                Command = command;
                Name = name;
                return;
            }
        }
        public static ChannelCommand[] Channels =     
        {
        #region Channels
		    new ChannelCommand(Channel.Fellowship,    "f",      "Fellowship"),
            new ChannelCommand(Channel.Say,           "say",    "Say"),
            new ChannelCommand(Channel.Raid,          "ra",     "Raid"),
            new ChannelCommand(Channel.Local,         "region", "Regional"),
            new ChannelCommand(Channel.RP,            "rpc",    "Role Playing"),
            new ChannelCommand(Channel.UserChannel1,  "1",      "User channel 1"),
            new ChannelCommand(Channel.UserChannel2,  "2",      "User channel 2"),
            new ChannelCommand(Channel.UserChannel3,  "3",      "User channel 3"),
            new ChannelCommand(Channel.LFF,           "lff",    "Looking For Fellowship"),
            new ChannelCommand(Channel.Kinship,       "k",      "Kinship"),
            new ChannelCommand(Channel.KinOfficers,   "ko",     "Kinship Officers"),
            new ChannelCommand(Channel.Tribe,         "t",      "Tribe"),
            new ChannelCommand(Channel.TribeOfficers, "to",     "Tribe Officers")
	    #endregion        
        };   
    #endregion

    #region Weighted odds handling
        public class WeightedText
        {   //--------------------------------------------------------------------
            // Data bag to handle weighted odds of showing a line
            public int Weight { get; set; }
            public String Text { get; set; }
            public WeightedText(int weight, String text) { Weight = weight; Text = text; return; }
            public WeightedText(String text) { Weight = 1; Text = text; return; }
            public WeightedText() { Weight = 1; Text = String.Empty; }
        }
        public List<WeightedText> Lines { get; private set; }
    #endregion    
    
        public MacroActionSay()
        {   //====================================================================
            Type = ActionType.SAY;
            Lines    = new List<WeightedText>();
            OutputChannel = Channel.Say;
            return;
        }
        public MacroActionSay(Channel channel)
        {   //--------------------------------------------------------------------
            Type = ActionType.SAY;
            Lines    = new List<WeightedText>();
            OutputChannel = channel;
            return;
        }
        public MacroActionSay(Channel channel, String strText)
        {   //--------------------------------------------------------------------
            Type = ActionType.SAY;
            Lines    = new List<WeightedText>();
            OutputChannel = channel;
            Lines.Add(new WeightedText(strText));
            return;
        }

        public override string Describe()
        {   //====================================================================
            String strRet = "Say";
            String strChannel = Enum.GetName(typeof(Channel), OutputChannel);
            switch (Lines.Count)
            {
                default:
                    // More than one line
                    strRet = "To " + strChannel + ": (one thing from a list of " + Lines.Count + ")";
                    break;

                case 1:
                    strRet = "To " + strChannel + ": " + Lines[0].Text;
                     break;

                case 0:
                    strRet = "Say nothing to channel " + strChannel;
                    break;
            }
            return strRet;
        }
        public override string DescribeType()
        {   //--------------------------------------------------------------------
            return Enum.GetName(typeof(Channel), OutputChannel);
        }

        public int Add(WeightedText wt)
        {   //--------------------------------------------------------------------
            Lines.Add(wt);
            return Lines.Count;
        }

        public override bool Edit()
        {   //====================================================================
            FormActionEditSay frm = new FormActionEditSay(this);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Lines = frm.Lines;
                OutputChannel = frm.Channel;
            }
            return true;
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
                if (cc.Channel == OutputChannel) {strCommand = cc.Command; break;}
            }
            //RemoteController.ExecuteFunction("START_COMMAND");
            RemoteController.SendText("/" + strCommand + " " + str); 
            return true;
        }
    }

    [Serializable]
    public class MacroActionKey : MacroAction
    {   //====================================================================
        public SDK.VK Key       {get; private set;}
        public bool   Shift     {get; private set;}
        public bool   Control   {get; private set;}
        public bool   Alt       {get; private set;}
        public bool   Windows   {get; private set;}
        
        public MacroActionKey()
        {
            Key = SDK.VK.unknown_vk;
            return;
        }
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
        public override string Describe()
        {   //====================================================================
            String strRet = "Press ";
            Boolean bBucky = false;
                if (Shift)              {strRet += "SHIFT";   bBucky = true;}
                if (Control && bBucky)  {strRet += "+";}
                if (Control)            {strRet += "CONTROL"; bBucky = true;}
                if (Alt && bBucky)      {strRet += "+";}
                if (Alt)                {strRet += "ALT";     bBucky = true;}
                if (bBucky)             {strRet += " ";}
            
            String strKey = Enum.GetName(typeof(SDK.VK), Key);
            if (strKey.StartsWith("KEY_")) strKey = strKey.Substring(4);
            
            strRet += strKey;
            return strRet;
        }
        public override bool Edit()
        {   //====================================================================
            FormActionEditKey faek = new FormActionEditKey(this);
            if (DialogResult.OK == faek.ShowDialog())
            {
                Key     = faek.Key;
                Shift   = faek.Shift;
                Control = faek.Control;
                Alt     = faek.Alt;
                return true;
            }
            return false;
        }
        public override bool Execute()
        {   //====================================================================
            if (SDK.VK.unknown_vk == Key) return false;

            BuckyBits bits = new BuckyBits();
                bits.Shift = Shift;
                bits.Control = Control;
                bits.Alt = Alt;
                bits.Windows = Windows;

            RemoteController.SendKey(Key, bits);
            return true;
        }
    }

    [Serializable]
    public class MacroActionKeyBinding : MacroAction
    {   //====================================================================
        public LotroBindingCommand Command {get; private set;}
        
        public MacroActionKeyBinding()
        {
            return;
        }
        public MacroActionKeyBinding(LotroBindingCommand lbc)
        {   //--------------------------------------------------------------------
            Command = lbc;
        }
        public override string Describe()
        {   //====================================================================
            return Command.Description;
        }
        public override bool Execute()
        {   //--------------------------------------------------------------------
            if (null == Command || String.Empty == Command.Name || "" == String.Empty) return false;
            RemoteController.ExecuteFunction(Command.Name);
            return true;
        }
    }

    [Serializable]
    public class MacroActionSlashCommand : MacroAction
    {   //====================================================================
        public LotroSlashCommand Command     {get; private set;}
        public String            Arguments   {get; private set;}

        public MacroActionSlashCommand()
        {
            return;
        }
        public MacroActionSlashCommand(LotroSlashCommand lsc)
        {
            Command = lsc;
            return;
        }
        public MacroActionSlashCommand(LotroSlashCommand lsc, String args)
        {
            Command   = lsc;
            Arguments = args;
            return;
        }
        public override string Describe()
        {   //====================================================================
            String strRet = String.Empty;
            switch (Command.Type)
            {
                case LotroSlashCommand.SlashCommandType.UNKNOWN:
                default:
                    //Wha?
                    strRet = "<broken action>";
                    break;

                case LotroSlashCommand.SlashCommandType.NoArg:
                    strRet = Command.Description;
                    break;

                case LotroSlashCommand.SlashCommandType.StringArg:
                case LotroSlashCommand.SlashCommandType.ArgChoice:
                    strRet = Command.Description + ": " + Arguments;
                    break;
            }
            return strRet;            
        }
        public override bool Edit()
        {   //====================================================================
            switch (Command.Type)
            {
                default:
                case LotroSlashCommand.SlashCommandType.UNKNOWN:
                case LotroSlashCommand.SlashCommandType.NoArg:
                    // Nothing to show
                    break;

                case LotroSlashCommand.SlashCommandType.StringArg:
                    Arguments = FormInputPrompt.GetInput("Edit Slash Command Parameters", "Enter arguments for command " + Command.Command, Arguments);
                    break;

                case LotroSlashCommand.SlashCommandType.ArgChoice:
                    Arguments = FormInputChoice.GetInput("Choose Slash Command Parameters", "Select option for command " + Command.Command, Command.AllowedArgs, Arguments);
                    break;
            }
            return true;
        }
        public override bool Execute()
        {   //--------------------------------------------------------------------
            switch (Command.Type)
            {
                case LotroSlashCommand.SlashCommandType.UNKNOWN:
                    // This is an error
                    return false;

                case LotroSlashCommand.SlashCommandType.NoArg:
                    RemoteController.SendText("/" + Command.Command);
                    break;

                case LotroSlashCommand.SlashCommandType.StringArg:
                case LotroSlashCommand.SlashCommandType.ArgChoice:
                    RemoteController.SendText("/" + Command.Command + " " + Arguments);
                    break;
            }
            return true;
        }
    }

    [Serializable]
    public class Macro
    {   //====================================================================
        public String Name      {get; set;}
        public String ErrorText {get; set;}

        public List<MacroAction>              _actions {get; set;}
        public ReadOnlyCollection<MacroAction> Actions 
        {        get {return _actions.AsReadOnly();} 
         private set {return;}}

        public void ClearActions()                {_actions.Clear();}
        public int  AddAction(MacroAction action) {_actions.Add(action); return _actions.Count - 1;}
        
        public int  RemoveAction(int nIndex)      {_actions.RemoveAt(nIndex); return _actions.Count;}        
        public int  RemoveActions(int[] aIndex)   
        {
            // Remove from bottom to top
            Array.Sort(aIndex); Array.Reverse(aIndex); 
            foreach (int i in aIndex) RemoveAction(i); 
            return _actions.Count;
        }

        public void MoveUp(int nIndex)
        {   //====================================================================
            if (0 == nIndex) return;

            MacroAction maSwap = _actions[nIndex];
            _actions[nIndex] = _actions[nIndex - 1];
            _actions[nIndex - 1] = maSwap;
            return;
        }
        public void MoveUp(int[] aIndex)
        {
            // Move higher ones first (so we don't just swap positions)
            Array.Sort(aIndex); 
            foreach (int i in aIndex) MoveUp(i);
            return;
        }
        public void MoveDown(int nIndex)
        {   //--------------------------------------------------------------------
            if (_actions.Count - 1 == nIndex) return;

            MacroAction maSwap = _actions[nIndex];
            _actions[nIndex] = _actions[nIndex + 1];
            _actions[nIndex + 1] = maSwap;
            return;
        }
        public void MoveDown(int[] aIndex)
        {
            // Move lower ones first, so we don't just swap positions
            Array.Sort(aIndex); Array.Reverse(aIndex);
            foreach (int i in aIndex) MoveDown(i);
            return;
        }

        public override string ToString() {return Name;}

        public Macro()
        {   //====================================================================
            Name = "";
            _actions = new List<MacroAction>();
            return;
        }
        public Macro(String name)
        {   //====================================================================
            Name = name;
            _actions = new List<MacroAction>();
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
