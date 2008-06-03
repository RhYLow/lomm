using System;

namespace LotroMusicManager
{
    public class LotroCommands
    {
        public enum Categories
        {
            Unknown = 0,
            Main,
            Selection,
            Music,
            Combat,
            //EditControls,
            //Scrolling,
            //CopyAndPaste,
            //Dialogs,
            QuickbarOne,
            QuickbarTwo,
            QuickbarThree,
            QuickbarFour,
            QuickbarFive,
            OnscreenPanels,
            Camera,
            Movement,
            Chat,
            Group,
            Pet,
            Alias
        }

    #region Commands
		public static LotroCommand[] Commands = 
        {
            new SlashCommand(LotroCommands.Categories.Main,
                             "AFK", 
                             "Marks you as Away From Keyboard", 
                             "afk", 
                             "optional afk text ('brb', 'bio', 'phone', etc.)"),
            new SlashCommand(LotroCommands.Categories.Main,
                             "Anonymous", 
                             "Sets you as anonymous or not (anonymous characters cannot be inspected and do not show up to 'who')", 
                             "anon", 
                             new String[] {"on", "off"}),
            new SlashCommand(LotroCommands.Categories.Main,
                             "Inspect", "Inspects the current target", "inspect"),
            new SlashCommand(LotroCommands.Categories.Main,
                             "Played", "Show how many hours you have spent playing this character", "played"),
            new SlashCommand(LotroCommands.Categories.Main,
                             "Roll", "Selects a random number and shows your fellowship", "random", "max number to roll (defaults to 100)"),
            new SlashCommand(LotroCommands.Categories.Main,
                             "RP Flag", "Turn your role-play flag on or off", "rp", new String[] {"on", "off"}),
            new SlashCommand(LotroCommands.Categories.Main,
                             "Servertime", "Show the time at the server", "servertime"),
            new SlashCommand(LotroCommands.Categories.Main,
                             "Adopt", "Adopt the target", "adopt"),
            new SlashCommand(LotroCommands.Categories.Main,
                             "Local time", "Show your computer's time", "localtime"),

            new SlashCommand(LotroCommands.Categories.Chat,
                             "Chatlog", 
                             "Enables or disables the chatlog", 
                             "chatlog", 
                             new String[] {"on", "off"}),
            new SlashCommand(LotroCommands.Categories.Chat,
                             "Capture Chat", 
                             "Captures chat that recently occurred to the chatlog", 
                             "chatlog capture"),
            new SlashCommand(LotroCommands.Categories.Chat,
                             "Join a channel", "Joins a channel. Custom channel names become User1-4", "joinchannel", "channel name"),
            new SlashCommand(LotroCommands.Categories.Chat,
                             "Leave a channel", "Leaves a channel, freeing that userchannel slot if one were being used", "leavechannel", "channel name"),
            new SlashCommand(LotroCommands.Categories.Chat,
                             "List channels", "List all subscribed channels", "listchannels"),

            new SlashCommand(LotroCommands.Categories.Combat,
                             "Damagetext List", "List current on-screen damagetext options", "damagetext list"),
            new SlashCommand(LotroCommands.Categories.Combat,
                             "Damagetext Range", "Set the range at which damagetext appears", "damagetext range", "range in meters"),
            new SlashCommand(LotroCommands.Categories.Combat,
                             "Damagetext Toggle", "Master toggle for damagetext on or off", "damagetext all", new String[] {"true", "false"}),
            new SlashCommand(LotroCommands.Categories.Combat,
                             "Damagetext Others", "Toggle damagetext for others on or off", "damagetext others", new String[] {"true", "false"}),
            new SlashCommand(LotroCommands.Categories.Combat,
                             "Autotarget", "Turn autotargetting (when no target is selected and an attack skill is activated) on or off", "autotarget", new String[] {"on", "off"}),
            new SlashCommand(LotroCommands.Categories.Combat,
                             "Spar", "Invite the target to duel", "duel"),
            
            new SlashCommand(LotroCommands.Categories.Movement,
                             "Automove", "Toggles automove on and off", "automove"),
            new SlashCommand(LotroCommands.Categories.Movement,
                             "Follow", "Begins auto-following the current target", "follow"),


            new SlashCommand(LotroCommands.Categories.Group,
                             "Invite to Fellowship", "Invite", "invite", "person to invite or ';target'"),
            new SlashCommand(LotroCommands.Categories.Group,
                             "LFP", "Mark yourself as looking for players", "lfp"),
            new SlashCommand(LotroCommands.Categories.Group,
                             "Readycheck", "Asks fellowship members if they are ready", "readycheck"),
            new SlashCommand(LotroCommands.Categories.Group,
                             "Who", "Searches for players", "who", "text to search for (name, region, class, etc)"),

            new SlashCommand(LotroCommands.Categories.Pet,
                             "Pet Mode", "Sets the pet's overall mode", "pet", new String[] {"follow", "stay", "assist on", "assist off", "guard", "aggressive", "passive"}),
            new SlashCommand(LotroCommands.Categories.Pet,
                             "Pet Command", "Issues a command to the pet", "pet", new String[] {"attack", "skill1", "skill2", "skill3", "release"}),
            new SlashCommand(LotroCommands.Categories.Pet,
                             "Pet Rename", "Rename your pet", "pet", "new name"),
            
            new SlashCommand(LotroCommands.Categories.Music,
                             "Music Toggle", "Toggle music mode", "music"),
            new SlashCommand(LotroCommands.Categories.Music,
                             "Play ABC File", "Play an ABC music file. You must be in music mode to do this.", "play", "filename song-index [sync]"),
            new SlashCommand(LotroCommands.Categories.Music,
                             "Playlist", "Lists all abc files LOTRO can find", "playlist"),
            new SlashCommand(LotroCommands.Categories.Music,
                             "Playstart", "Starts all fellowship members who are waiting with a \"play sync\"", "playstart"),
            
            //new SlashCommand("Tutorial", "Enable, disable, or reset the tutorial popup windows", "tutorial", new String[] {"enable", "disable", "reset"}),
            new SlashCommand(LotroCommands.Categories.Selection,
                             "Use (selection)", "'Use' the currently selected object, as if right-clicking it", "useselection"),
            //new SlashCommand("Emote List", "Lists all emotes", "emotelist"),
            //new SlashCommand("Filter List", "Lists kinds of things you can filter on or off in a channel", "filterlist"),

            //new SlashCommand("Detailed Coordinates", "Show the detailed coordinates that Turbine developers use", "loc"),
            //new SlashCommand("Reclaimpromotional items", "Re-issue promotional items you have deleted", "reclaim"),
            new SlashCommand(LotroCommands.Categories.Alias,
                             "Create Alias", "Creates an alias you can use on the command line. Aliases always begin with a semicolon", "alias", ";alias-name text-to-send-instead"),
            new SlashCommand(LotroCommands.Categories.Alias,
                             "Remove Alias", "Removes an alias", "alias", ";alias-name"),
            new SlashCommand(LotroCommands.Categories.Alias,
                             "Manage Aliases", "Perform various alias management tasks", "alias", new String[] {"list", "clear"}),
            new SlashCommand(LotroCommands.Categories.Alias,
                             "Shortcut", "Puts a command-line command on a quickslot", "shortcut", "quickslot-number text-to-execute"),

        
            new KeyCommand(LotroCommands.Categories.Camera, "CameraFirstPerson", "First-person view"),
            new KeyCommand(LotroCommands.Categories.Camera, "CameraFlightMode", "Third-person view"),
            new KeyCommand(LotroCommands.Categories.Camera, "CameraReset", "Reset Camera"),

            new KeyCommand(LotroCommands.Categories.Combat, "AssistFellowTwo", "Assist fellowship member 2"),
            new KeyCommand(LotroCommands.Categories.Combat, "AssistFellowThree", "Assist fellowship member 3"),
            new KeyCommand(LotroCommands.Categories.Combat, "AssistFellowFive", "Assist fellowship member 4"),
            new KeyCommand(LotroCommands.Categories.Combat, "AssistFellowFour", "Assist fellowship member 5"),
            new KeyCommand(LotroCommands.Categories.Combat, "AssistFellowSix", "Assist fellowship member 6"),
            new KeyCommand(LotroCommands.Categories.Combat, "Conjunction_Contribution_Assist", "Target conjunction target"),
            new KeyCommand(LotroCommands.Categories.Combat, "ToggleTargetMark1", "Toggle target mark Shield"),
            new KeyCommand(LotroCommands.Categories.Combat, "ToggleTargetMark2", "Toggle target mark Spear"),
            new KeyCommand(LotroCommands.Categories.Combat, "ToggleTargetMark3", "Toggle target mark Arrow"),
            new KeyCommand(LotroCommands.Categories.Combat, "ToggleTargetMark4", "Toggle target mark Sun"),
            new KeyCommand(LotroCommands.Categories.Combat, "ToggleTargetMark5", "Toggle target mark Swords"),
            new KeyCommand(LotroCommands.Categories.Combat, "ToggleTargetMark6", "Toggle target mark Moon"),
            new KeyCommand(LotroCommands.Categories.Combat, "ToggleTargetMark7", "Toggle target mark Star"),
            new KeyCommand(LotroCommands.Categories.Combat, "ToggleTargetMark8", "Toggle target mark Claw"),
            new KeyCommand(LotroCommands.Categories.Combat, "ToggleTargetMark9", "Toggle target mark Skull"),
            new KeyCommand(LotroCommands.Categories.Combat, "ToggleTargetMark10", "Toggle target mark Leaf"),
            
            
            new KeyCommand(LotroCommands.Categories.Main, "ADMIN_LIGHT", "Toggle light around character"),
            new KeyCommand(LotroCommands.Categories.Main, "AutoLootAll", "?????"),
            new KeyCommand(LotroCommands.Categories.Main, "CaptureScreenshot", "Take a screenshot"),
            new KeyCommand(LotroCommands.Categories.Main, "ChatModeReply", "Start a chat reply"),
            new KeyCommand(LotroCommands.Categories.Main, "LOGOUT", "Logout"),
            new KeyCommand(LotroCommands.Categories.Main, "SelectOutfit1", "Wear cosmetic outfit 1"),
            new KeyCommand(LotroCommands.Categories.Main, "SelectOutfit2", "Wear cosmetic outfit 2"),
            new KeyCommand(LotroCommands.Categories.Main, "SelectOutfitInventory", "Wear normal armor"),
            new KeyCommand(LotroCommands.Categories.Main, "SHOW_NAMES", "Toggle floaty names"),
            new KeyCommand(LotroCommands.Categories.Main, "START_COMMAND", "Start a command (/)"),
            new KeyCommand(LotroCommands.Categories.Main, "TOOLTIP_DETACH", "Detatch tooltip"),
            new KeyCommand(LotroCommands.Categories.Main, "UI_TOGGLE", "Hide/show UI"),
            
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK", "Toggle all backpacks"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK1", "Toggle backpack 1"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK2", "Toggle backpack 2"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK3", "Toggle backpack 3"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK4", "Toggle backpack 4"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK5", "Toggle backpack 5"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleAccomplishmentPanel", "Toggle deed panel"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleAssistancePanel", "Toggle help panel"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleBlockUI", "Toggle ?????"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleCraftingPanel", "Toggle crafting panel"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleEntityNodeLabels", "Toggle (??????)"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleHiddenDragBoxes", "Toggle drag UI mode"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleItemSellLock", "Toggle lock on item"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleJournalPanel", "Toggle ?????"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleMapPanel", "Toggle map"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleOptionsPanel", "Toggle options"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "TogglePerfGraph", "Toggle ?????"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleProfiler", "Toggle ?????"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleQuestPanel", "Toggle ?????"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleSkillPanel", "Toggle skills"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleSocialPanel", "Toggle social panel"),
            new KeyCommand(LotroCommands.Categories.OnscreenPanels, "ToggleTraitPanel", "Toggle traits"),
            
            new KeyCommand(LotroCommands.Categories.Movement, "MovementBackup", "Move back"),
            new KeyCommand(LotroCommands.Categories.Movement, "MovementForward", "Move forward"),
            new KeyCommand(LotroCommands.Categories.Movement, "MovementForwardCameraMovement", "?????"),
            new KeyCommand(LotroCommands.Categories.Movement, "MovementHighJump", "Jump"),
            new KeyCommand(LotroCommands.Categories.Movement, "MovementLongJump", "?????"),
            new KeyCommand(LotroCommands.Categories.Movement, "MovementRunLock", "Toggle autorun"),
            new KeyCommand(LotroCommands.Categories.Movement, "MovementStrafeLeft", "Strafe left"),
            new KeyCommand(LotroCommands.Categories.Movement, "MovementStrafeRight", "Strafe right"),
            new KeyCommand(LotroCommands.Categories.Movement, "MovementTurnOrStrafeLeft", "?????"),
            new KeyCommand(LotroCommands.Categories.Movement, "MovementTurnOrStrafeRight", "?????"),
            new KeyCommand(LotroCommands.Categories.Movement, "MovementWalkMode", "Toggle walk mode"),
            
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_B2",  "B2"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_C3",  "C3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_Db3", "C#3/Db3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_D3",  "D3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_Eb3", "D#3/Eb3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_E3",  "E3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_F3",  "F3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_Gb3", "F#3/Gb3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_G3",  "G3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_Ab3", "G#3/Ab3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_A3",  "A3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_Bb3", "A#3/Bb3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_B3",  "B3"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_C4",  "C4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_Db4", "C#4/Db4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_D4",  "D4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_Eb4", "D#4/Eb4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_E4",  "E4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_F4",  "F4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_Gb4", "F#4/Gb4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_G4",  "G4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_Ab4", "G#4/Ab4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_A4",  "A4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_Bb4", "A#4/Bb4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_B4",  "B4"),
            new KeyCommand(LotroCommands.Categories.Music, "MUSIC_C5",  "C5"),
            new KeyCommand(LotroCommands.Categories.Music, "MusicEndSong", "Stop playing ABC file"),
            
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_1", "Bar 1, button 1"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_2", "Bar 1, button 2"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_3", "Bar 1, button 3"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_4", "Bar 1, button 4"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_5", "Bar 1, button 5"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_6", "Bar 1, button 6"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_7", "Bar 1, button 7"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_8", "Bar 1, button 8"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_9", "Bar 1, button 9"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_10", "Bar 1, button 10"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_11", "Bar 1, button 11"),
            new KeyCommand(LotroCommands.Categories.QuickbarOne, "QUICKSLOT_12", "Bar 1, button 12"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_13", "Bar 2, button 1"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_14", "Bar 2, button 2"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_15", "Bar 2, button 3"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_16", "Bar 2, button 4"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_17", "Bar 2, button 5"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_18", "Bar 2, button 6"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_19", "Bar 2, button 7"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_20", "Bar 2, button 8"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_21", "Bar 2, button 9"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_22", "Bar 2, button 10"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_23", "Bar 2, button 11"),
            new KeyCommand(LotroCommands.Categories.QuickbarTwo, "QUICKSLOT_24", "Bar 2, button 12"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_25", "Bar 3, button 1"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_26", "Bar 3, button 2"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_27", "Bar 3, button 3"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_28", "Bar 3, button 4"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_29", "Bar 3, button 5"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_30", "Bar 3, button 6"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_31", "Bar 3, button 7"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_32", "Bar 3, button 8"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_33", "Bar 3, button 9"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_34", "Bar 3, button 10"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_35", "Bar 3, button 11"),
            new KeyCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_36", "Bar 3, button 12"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_37", "Bar 4, button 1"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_38", "Bar 4, button 2"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_39", "Bar 4, button 3"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_40", "Bar 4, button 4"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_41", "Bar 4, button 5"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_42", "Bar 4, button 6"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_43", "Bar 4, button 7"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_44", "Bar 4, button 8"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_45", "Bar 4, button 9"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_46", "Bar 4, button 10"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_47", "Bar 4, button 11"),
            new KeyCommand(LotroCommands.Categories.QuickbarFour, "QUICKSLOT_48", "Bar 4, button 12"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_49", "Bar 5, button 1"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_50", "Bar 5, button 2"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_51", "Bar 5, button 3"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_52", "Bar 5, button 4"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_53", "Bar 5, button 5"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_54", "Bar 5, button 6"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_55", "Bar 5, button 7"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_56", "Bar 5, button 8"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_57", "Bar 5, button 9"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_58", "Bar 5, button 10"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_59", "Bar 5, button 11"),
            new KeyCommand(LotroCommands.Categories.QuickbarFive, "QUICKSLOT_60", "Bar 5, button 12"),
            
            new KeyCommand(LotroCommands.Categories.Selection, "SelectFellowOne", "Select fellowship member 1 (self)"),
            new KeyCommand(LotroCommands.Categories.Selection, "SelectFellowTwo", "Select fellowship member 2"),
            new KeyCommand(LotroCommands.Categories.Selection, "SelectFellowThree", "Select fellowship member 3"),
            new KeyCommand(LotroCommands.Categories.Selection, "SelectFellowFour", "Select fellowship member 4"),
            new KeyCommand(LotroCommands.Categories.Selection, "SelectFellowFive", "Select fellowship member 5"),
            new KeyCommand(LotroCommands.Categories.Selection, "SelectFellowSix", "Select fellowship member 6"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_ASSIST", "Assist selection"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_LAST", "Previous selection"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_NEAREST_CREATURE", "Select nearest creature"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_NEAREST_FELLOW", "Select nearest fellowship member"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_NEAREST_FOE", "Select nearest foe"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_NEAREST_ITEM", "Select nearest item"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_NEAREST_PC", "Select nearest PC"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_NEXT_PC", "Select next PC"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_PREVIOUS_PC", "Select previous PC"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_NEXT_FOE", "Select next foe"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_PREVIOUS_CREATURE", "Select previous creature"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_PREVIOUS_FOE", "Select previous foe"),
            new KeyCommand(LotroCommands.Categories.Selection, "SELECTION_SELF", "Select self"),
         }; 
	#endregion    
    }

    public class LotroCommand
    {
        public String                   Name           {get; set;}
        public LotroCommands.Categories Category       {get; set;}
        public String                   Description    {get; set;}
    }

    public class SlashCommand : LotroCommand
    {   //====================================================================
        public String   Command     {get; private set;}
        public String   ArgumentTip {get; private set;}
        public String[] AllowedArgs {get; private set;}
        
        public SlashCommandType Type {get; private set;}
        public enum SlashCommandType {UNKNOWN, NoArg, StringArg, ArgChoice}

        public SlashCommand(LotroCommands.Categories category, String name, String description, String command)
        {   //--------------------------------------------------------------------
            // This is for slash commands with no arguments
            Category    = category;
            Name        = name;
            Description = description;
            Command     = command;
            ArgumentTip = String.Empty;
            AllowedArgs = null;
            Type       = SlashCommandType.NoArg;
            return;
        }
        public SlashCommand(LotroCommands.Categories category, String name, String description, String command, String tip)
        {   //--------------------------------------------------------------------
            // Slash commands with a string argument
            Category    = category;
            Name        = name;
            Description = description;
            Command     = command;
            ArgumentTip = tip;
            AllowedArgs = null;
            Type       = SlashCommandType.StringArg;
            return;
        }
        public SlashCommand(LotroCommands.Categories category, String name, String description, String command, String[] allowed)
        {   //--------------------------------------------------------------------
            // Slash commands with a set of allowed arguments
            Category    = category;
            Name        = name;
            Description = description;
            Command     = command;
            ArgumentTip = String.Empty;
            AllowedArgs = allowed;
            Type       = SlashCommandType.ArgChoice;
            return;
        }
    }

    public class KeyCommand : LotroCommand
    {
        public short      MappedScanCode {get; set;}
        public BuckyBits  Bits           {get; set;}
        public KeyCommand(LotroCommands.Categories cat, String strName, String strDesc)
        {
            Bits         = new BuckyBits();
            Category     = cat;
            Name         = strName;
            Description  = strDesc;
            return;
        }
    #region Lotro Function List
       // static public KeyCommand[] KeyCommandArray =
       // {
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraDecreaseFOV", ""),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraIncreaseFOV", ""),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraInstantMouseLook", "Mouse look"),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraInstantMouseSteer", "Mouse steer"),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraInstantMoveAway", ""),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraInstantMoveToward", ""),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraMoveAway", ""),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraMoveToward", ""),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraRotateDown", "Turn camera down"),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraRotateLeft", "Turn camera left"),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraRotateRight", "Turn camera right"),
       //     //new KeyCommand(LotroCommands.Categories.Camera, "CameraRotateUp", "Turn camera up"),
            
       //     //new KeyCommand(LotroCommands.Categories.Dialogs, "FocusMoveDown", "Move focus down"),
       //     //new KeyCommand(LotroCommands.Categories.Dialogs, "FocusMoveLeft", "Move focus left"),
       //     //new KeyCommand(LotroCommands.Categories.Dialogs, "FocusMoveRight", "Move focus right"),
       //     //new KeyCommand(LotroCommands.Categories.Dialogs, "FocusMoveUp", "Move focus up"),
       //     //new KeyCommand(LotroCommands.Categories.Dialogs, "FocusNext", "Move to next dialog control"),
       //     //new KeyCommand(LotroCommands.Categories.Dialogs, "FocusPrevious", "Move to previous dialog control"),
            
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorCharLeft", "Cursor left"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorCharRight", "Cursor right"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorEndOfDocument", "Move to end of document"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorEndOfLine", "Move to end of line"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorNextLine", "Cursor down"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorNextPage", "Next page"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorPreviousLine", "Cursor up"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorPreviousPage", "Previous page"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorStartOfDocument", "Move to start of document"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorStartOfLine", "Move to start of line"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorWordLeft", "Move a word to the left"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CursorWordRight", "Move a word to the right"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "CutText", "Cut text"),
       //     //new KeyCommand(LotroCommands.Categories.EditControls, "PasteText", "Paste text"),
            
       //     //new KeyCommand(LotroCommands.Categories.Main, "BackspaceKey", "Backspace"),
       //     //new KeyCommand(LotroCommands.Categories.Main, "CopyText", "Copy text"),
       //     //new KeyCommand(LotroCommands.Categories.Main, "DeleteKey", "DEL key"),
       //     //new KeyCommand(LotroCommands.Categories.Main, "DressingRoom", "Dressing Room"),
       //     //new KeyCommand(LotroCommands.Categories.Main, "EscapeKey", "ESC key"),
            
       //     //new KeyCommand(LotroCommands.Categories.Main, "USE", "Use (right-click) current selection"),
       //     //new KeyCommand(LotroCommands.Categories.Main, "VOICECHAT_TALK", ""),
       //     //new KeyCommand(LotroCommands.Categories.Scrolling, "ScrollDown", "Scroll down"),
       //     //new KeyCommand(LotroCommands.Categories.Scrolling, "ScrollUp", "Scroll Up"),
            
       //};
    #endregion
    }

}