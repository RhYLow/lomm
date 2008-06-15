using System;

//====================================================================
// These classes wrap Lotro "commands", both things you can bind in 
// the key setup and things you can specify on the in-game command line
namespace LotroMusicManager
{
    public class LotroCommands
    {
        public enum Categories
        {
            Unknown = 0,
            General,
            QuickbarOne,
            QuickbarTwo,
            QuickbarThree,
            QuickbarFour,
            QuickbarFive,
            OnscreenPanels,
            Combat,
            Selection,
            Group,
            Pet,
            Music,
            Camera,
            Movement,
            Chat,
            Alias
        }

    #region Commands
		public static LotroCommand[] Commands = 
        {
        #region General commands
		    new LotroSlashCommand(LotroCommands.Categories.General,
                             "AFK", 
                             "Marks you as Away From Keyboard", 
                             "afk", 
                             "optional afk text ('brb', 'bio', 'phone', etc.)"),
            new LotroSlashCommand(LotroCommands.Categories.General,
                             "Anonymous", 
                             "Sets you as anonymous or not (anonymous characters cannot be inspected and do not show up to 'who')", 
                             "anon", 
                             new String[] {"on", "off"}),
            new LotroSlashCommand(LotroCommands.Categories.General,
                             "Played", "Show how many hours you have spent playing this character", "played"),
            new LotroSlashCommand(LotroCommands.Categories.General,
                             "Roll", "Selects a random number and shows your fellowship", "random", "max number to roll (defaults to 100)"),
            new LotroSlashCommand(LotroCommands.Categories.General,
                             "RP Flag", "Turn your role-play flag on or off", "rp", new String[] {"on", "off"}),
            new LotroSlashCommand(LotroCommands.Categories.General,
                             "Servertime", "Show the time at the server", "servertime"),
            new LotroSlashCommand(LotroCommands.Categories.General,
                             "Adopt", "Adopt the target", "adopt"),
            new LotroSlashCommand(LotroCommands.Categories.General,
                             "Local time", "Show your computer's time", "localtime"),
            new LotroBindingCommand(LotroCommands.Categories.General, "ADMIN_LIGHT", "Light", "Toggle light around character"),
            new LotroBindingCommand(LotroCommands.Categories.General, "AutoLootAll", "?????", "?????"),
            new LotroBindingCommand(LotroCommands.Categories.General, "CaptureScreenshot", "Screenshot", "Take a screenshot"),
            //new KeyCommand(LotroCommands.Categories.Main, "ChatModeReply", "Reply", "Start a chat reply"),
            new LotroBindingCommand(LotroCommands.Categories.General, "LOGOUT", "Logout", "Logout"),
            new LotroBindingCommand(LotroCommands.Categories.General, "SelectOutfit1", "Outfit 1", "Wear cosmetic outfit 1"),
            new LotroBindingCommand(LotroCommands.Categories.General, "SelectOutfit2", "Outfit 2", "Wear cosmetic outfit 2"),
            new LotroBindingCommand(LotroCommands.Categories.General, "SelectOutfitInventory", "No Outfit", "Wear normal armor"),
            new LotroBindingCommand(LotroCommands.Categories.General, "SHOW_NAMES", "Names", "Toggle floaty names"),
            //new KeyCommand(LotroCommands.Categories.Main, "START_COMMAND", "", "Start a command (/)"),
            new LotroBindingCommand(LotroCommands.Categories.General, "TOOLTIP_DETACH", "Detach Tooltip", "Detach tooltip"),
            new LotroBindingCommand(LotroCommands.Categories.General, "UI_TOGGLE", "Toggle UI", "Hide/show UI"),
	    #endregion
        #region Chat Commands
		            new LotroSlashCommand(LotroCommands.Categories.Chat,
                             "Chatlog", 
                             "Enables or disables the chatlog", 
                             "chatlog", 
                             new String[] {"on", "off"}),
            new LotroSlashCommand(LotroCommands.Categories.Chat,
                             "Capture Chat", 
                             "Captures chat that recently occurred to the chatlog", 
                             "chatlog capture"),
            new LotroSlashCommand(LotroCommands.Categories.Chat,
                             "Join a channel", "Joins a channel. Custom channel names become User1-4", "joinchannel", "channel name"),
            new LotroSlashCommand(LotroCommands.Categories.Chat,
                             "Leave a channel", "Leaves a channel, freeing that userchannel slot if one were being used", "leavechannel", "channel name"),
            new LotroSlashCommand(LotroCommands.Categories.Chat,
                             "List channels", "List all subscribed channels", "listchannels"),
	    #endregion
        #region Combat commands
		    new LotroBindingCommand(LotroCommands.Categories.Combat, "AssistFellowTwo",   "Assist 2", "Assist fellowship member 2"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "AssistFellowThree", "Assist 3", "Assist fellowship member 3"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "AssistFellowFive",  "Assist 4", "Assist fellowship member 4"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "AssistFellowFour",  "Assist 5", "Assist fellowship member 5"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "AssistFellowSix",   "Assist 6", "Assist fellowship member 6"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "Conjunction_Contribution_Assist", "Assist Conjunction", "Target conjunction target"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "ToggleTargetMark1",  "Shield", "Toggle target mark Shield"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "ToggleTargetMark2",  "Spear", "Toggle target mark Spear"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "ToggleTargetMark3",  "Arrow", "Toggle target mark Arrow"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "ToggleTargetMark4",  "Sun", "Toggle target mark Sun"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "ToggleTargetMark5",  "Swords", "Toggle target mark Swords"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "ToggleTargetMark6",  "Moon", "Toggle target mark Moon"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "ToggleTargetMark7",  "Star", "Toggle target mark Star"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "ToggleTargetMark8",  "Claw", "Toggle target mark Claw"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "ToggleTargetMark9",  "Skull", "Toggle target mark Skull"),
            new LotroBindingCommand(LotroCommands.Categories.Combat, "ToggleTargetMark10", "Leaf", "Toggle target mark Leaf"),
            new LotroSlashCommand(LotroCommands.Categories.Combat,
                             "Damagetext List", "List current on-screen damagetext options", "damagetext list"),
            new LotroSlashCommand(LotroCommands.Categories.Combat,
                             "Damagetext Range", "Set the range at which damagetext appears", "damagetext range", "range in meters"),
            new LotroSlashCommand(LotroCommands.Categories.Combat,
                             "Damagetext Toggle", "Master toggle for damagetext on or off", "damagetext all", new String[] {"true", "false"}),
            new LotroSlashCommand(LotroCommands.Categories.Combat,
                             "Damagetext Others", "Toggle damagetext for others on or off", "damagetext others", new String[] {"true", "false"}),
            new LotroSlashCommand(LotroCommands.Categories.Combat,
                             "Autotarget", "Turn autotargetting (when no target is selected and an attack skill is activated) on or off", "autotarget", new String[] {"on", "off"}),
            new LotroSlashCommand(LotroCommands.Categories.Combat,
                             "Spar", "Invite the target to duel", "duel"),
	    #endregion            
        #region Movement commands
		    new LotroSlashCommand(LotroCommands.Categories.Movement,
                             "Automove", "Toggles automove to target on and off", "automove"),
            new LotroSlashCommand(LotroCommands.Categories.Movement,
                             "Follow", "Begins auto-following the current target", "follow"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementRunLock", "Autorun", "Toggle autorun"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementWalkMode", "Walk", "Toggle walk mode"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementBackup", "Back", "Move back"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementForward", "Forward", "Move forward"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementForwardCameraMovement", "?????", "?????"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementHighJump", "Jump", "Jump"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementLongJump", "?????", "?????"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementStrafeLeft", "Strafe Left", "Strafe left"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementStrafeRight", "Strafe Right", "Strafe right"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementTurnOrStrafeLeft", "Turn Left", "Turn left (or strafe left in mouselook mode)"),
            new LotroBindingCommand(LotroCommands.Categories.Movement, "MovementTurnOrStrafeRight", "Turn Right", "Turn right (or strafe right in mouselook mode)"),
        #endregion
        #region Group commands
		    new LotroSlashCommand(LotroCommands.Categories.Group,
                             "Invite to Fellowship", "Invite", "invite", "person to invite or ';target'"),
            new LotroSlashCommand(LotroCommands.Categories.Group,
                             "LFP", "Mark yourself as looking for players", "lfp"),
            new LotroSlashCommand(LotroCommands.Categories.Group,
                             "Readycheck", "Asks fellowship members if they are ready", "readycheck"),
            new LotroSlashCommand(LotroCommands.Categories.Group,
                             "Who", "Searches for players", "who", "text to search for (name, region, class, etc)"),
        #endregion
        #region Pet commands
		    new LotroSlashCommand(LotroCommands.Categories.Pet,
                             "Pet Mode", "Sets the pet's overall mode", "pet", new String[] {"follow", "stay", "assist on", "assist off", "guard", "aggressive", "passive"}),
            new LotroSlashCommand(LotroCommands.Categories.Pet,
                             "Pet Command", "Issues a command to the pet", "pet", new String[] {"attack", "skill1", "skill2", "skill3", "release"}),
            new LotroSlashCommand(LotroCommands.Categories.Pet,
                             "Pet Rename", "Rename your pet", "pet", "new name"), 
        #endregion           
        #region Music commands
		            new LotroSlashCommand(LotroCommands.Categories.Music,
                             "Music Toggle", "Toggle music mode", "music"),
            new LotroSlashCommand(LotroCommands.Categories.Music,
                             "Play ABC File", "Play an ABC music file. You must be in music mode to do this.", "play", "filename song-index [sync]"),
            new LotroSlashCommand(LotroCommands.Categories.Music,
                             "Playlist", "Lists all abc files LOTRO can find", "playlist"),
            new LotroSlashCommand(LotroCommands.Categories.Music,
                             "Playstart", "Starts all fellowship members who are waiting with a \"play sync\"", "playstart"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MusicEndSong", "Stop ABC", "Stop playing ABC file"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_B2",  "B2",       "B2"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_C3",  "C3",       "C3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_Db3", "C#3/Db3",  "C#3/Db3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_D3",  "D3",       "D3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_Eb3", "D#3/Eb3",  "D#3/Eb3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_E3",  "E3",       "E3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_F3",  "F3",       "F3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_Gb3", "F#3/Gb3",  "F#3/Gb3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_G3",  "G3",       "G3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_Ab3", "G#3/Ab3",  "G#3/Ab3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_A3",  "A3",       "A3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_Bb3", "A#3/Bb3",  "A#3/Bb3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_B3",  "B3",       "B3"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_C4",  "C4",       "C4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_Db4", "C#4/Db4",  "C#4/Db4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_D4",  "D4",       "D4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_Eb4", "D#4/Eb4",  "D#4/Eb4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_E4",  "E4",       "E4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_F4",  "F4",       "F4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_Gb4", "F#4/Gb4",  "F#4/Gb4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_G4",  "G4",       "G4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_Ab4", "G#4/Ab4",  "G#4/Ab4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_A4",  "A4",       "A4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_Bb4", "A#4/Bb4",  "A#4/Bb4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_B4",  "B4",       "B4"),
            new LotroBindingCommand(LotroCommands.Categories.Music, "MUSIC_C5",  "C5",       "C5"),
        #endregion            
        #region Alias commands
		    new LotroSlashCommand(LotroCommands.Categories.Alias,
                             "Create Alias", "Creates an alias you can use on the command line. Aliases always begin with a semicolon", "alias", ";alias-name text-to-send-instead"),
            new LotroSlashCommand(LotroCommands.Categories.Alias,
                             "Remove Alias", "Removes an alias", "alias", ";alias-name"),
            new LotroSlashCommand(LotroCommands.Categories.Alias,
                             "Manage Aliases", "Perform various alias management tasks", "alias", new String[] {"list", "clear"}),
            new LotroSlashCommand(LotroCommands.Categories.Alias,
                             "Shortcut", "Puts a command-line command on a quickslot", "shortcut", "quickslot-number text-to-execute"),
        #endregion        
        #region Camera commands
		    new LotroBindingCommand(LotroCommands.Categories.Camera, "CameraFirstPerson", "First-person view", "First-person view"),
            new LotroBindingCommand(LotroCommands.Categories.Camera, "CameraFlightMode",  "Third-person view", "Third-person view"),
            new LotroBindingCommand(LotroCommands.Categories.Camera, "CameraReset",       "Reset Camera",      "Reset Camera"), 
	    #endregion
        #region Panel commands
		    new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK",  "Inventory", "Toggle all backpacks"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK1", "Backpack 1", "Toggle backpack 1"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK2", "Backpack 2", "Toggle backpack 2"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK3", "Backpack 3", "Toggle backpack 3"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK4", "Backpack 4", "Toggle backpack 4"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "QUICKSLOT_BACKPACK5", "Backpack 5", "Toggle backpack 5"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleAccomplishmentPanel", "Deeds", "Toggle deed panel"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleAssistancePanel", "Help", "Toggle help panel"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleBlockUI", "?????", "Toggle ?????"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleCraftingPanel", "Tradeskills", "Toggle crafting panel"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleEntityNodeLabels", "?????", "Toggle (??????)"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleHiddenDragBoxes", "Move UI Elements", "Toggle drag UI mode"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleItemSellLock", "Lock", "Toggle lock on item"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleJournalPanel", "?????", "Toggle ?????"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleMapPanel", "Map", "Toggle map"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleOptionsPanel", "Options", "Toggle options"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "TogglePerfGraph", "?????", "Toggle ?????"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleProfiler", "?????", "Toggle ?????"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleQuestPanel", "Quests", "Toggle Quest Panel"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleSkillPanel", "Skills", "Toggle skills"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleSocialPanel", "Social", "Toggle social panel"),
            new LotroBindingCommand(LotroCommands.Categories.OnscreenPanels, "ToggleTraitPanel", "Traits", "Toggle traits"),
        #endregion            
        #region Quickbar commands
		    new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_1",  "Button 1",  "Bar 1, button 1"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_2",  "Button 2",  "Bar 1, button 2"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_3",  "Button 3",  "Bar 1, button 3"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_4",  "Button 4",  "Bar 1, button 4"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_5",  "Button 5",  "Bar 1, button 5"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_6",  "Button 6",  "Bar 1, button 6"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_7",  "Button 7",  "Bar 1, button 7"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_8",  "Button 8",  "Bar 1, button 8"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_9",  "Button 9",  "Bar 1, button 9"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_10", "Button 10", "Bar 1, button 10"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_11", "Button 11", "Bar 1, button 11"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarOne,   "QUICKSLOT_12", "Button 12", "Bar 1, button 12"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_13", "Button 1",  "Bar 2, button 1"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_14", "Button 2",  "Bar 2, button 2"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_15", "Button 3",  "Bar 2, button 3"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_16", "Button 4",  "Bar 2, button 4"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_17", "Button 5",  "Bar 2, button 5"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_18", "Button 6",  "Bar 2, button 6"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_19", "Button 7",  "Bar 2, button 7"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_20", "Button 8",  "Bar 2, button 8"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_21", "Button 9",  "Bar 2, button 9"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_22", "Button 10", "Bar 2, button 10"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_23", "Button 11", "Bar 2, button 11"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarTwo,   "QUICKSLOT_24", "Button 12", "Bar 2, button 12"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_25", "Button 1",  "Bar 3, button 1"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_26", "Button 2",  "Bar 3, button 2"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_27", "Button 3",  "Bar 3, button 3"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_28", "Button 4",  "Bar 3, button 4"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_29", "Button 5",  "Bar 3, button 5"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_30", "Button 6",  "Bar 3, button 6"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_31", "Button 7",  "Bar 3, button 7"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_32", "Button 8",  "Bar 3, button 8"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_33", "Button 9",  "Bar 3, button 9"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_34", "Button 10", "Bar 3, button 10"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_35", "Button 11", "Bar 3, button 11"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarThree, "QUICKSLOT_36", "Button 12", "Bar 3, button 12"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_37", "Button 1",  "Bar 4, button 1"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_38", "Button 2",  "Bar 4, button 2"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_39", "Button 3",  "Bar 4, button 3"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_40", "Button 4",  "Bar 4, button 4"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_41", "Button 5",  "Bar 4, button 5"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_42", "Button 6",  "Bar 4, button 6"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_43", "Button 7",  "Bar 4, button 7"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_44", "Button 8",  "Bar 4, button 8"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_45", "Button 9",  "Bar 4, button 9"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_46", "Button 10", "Bar 4, button 10"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_47", "Button 11", "Bar 4, button 11"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFour,  "QUICKSLOT_48", "Button 12", "Bar 4, button 12"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_49", "Button 1",  "Bar 5, button 1"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_50", "Button 2",  "Bar 5, button 2"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_51", "Button 3",  "Bar 5, button 3"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_52", "Button 4",  "Bar 5, button 4"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_53", "Button 5",  "Bar 5, button 5"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_54", "Button 6",  "Bar 5, button 6"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_55", "Button 7",  "Bar 5, button 7"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_56", "Button 8",  "Bar 5, button 8"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_57", "Button 9",  "Bar 5, button 9"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_58", "Button 10", "Bar 5, button 10"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_59", "Button 11", "Bar 5, button 11"),
            new LotroBindingCommand(LotroCommands.Categories.QuickbarFive,  "QUICKSLOT_60", "Button 12", "Bar 5, button 12"),
        #endregion            
        #region Selection commands
		    //new KeyCommand(LotroCommands.Categories.Selection, "SelectFellowOne", "Self", "Select fellowship member 1 (self)"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_SELF",              "Self",               "Select self"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SelectFellowTwo",             "Fellow 2",           "Select fellowship member 2"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SelectFellowThree",           "Fellow 3",           "Select fellowship member 3"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SelectFellowFour",            "Fellow 4",           "Select fellowship member 4"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SelectFellowFive",            "Fellow 5",           "Select fellowship member 5"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SelectFellowSix",             "Fellow 6",           "Select fellowship member 6"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_ASSIST",            "Assist",             "Assist selection"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_LAST",              "Previous selection", "Previous selection"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_NEAREST_CREATURE",  "Nearest Creature",   "Select nearest creature"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_PREVIOUS_CREATURE", "Previous Creature",  "Select previous creature"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_NEAREST_FELLOW",    "Nearest Fellow",     "Select nearest fellowship member"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_NEAREST_FOE",       "Nearest Foe",        "Select nearest foe"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_NEXT_FOE",          "Next Foe",           "Select next foe"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_PREVIOUS_FOE",      "Previous Foe",       "Select previous foe"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_NEAREST_ITEM",      "Nearest Item",       "Select nearest item"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_NEAREST_PC",        "Nearest PC",         "Select nearest PC"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_NEXT_PC",           "Next PC",            "Select next PC"),
            new LotroBindingCommand(LotroCommands.Categories.Selection, "SELECTION_PREVIOUS_PC",       "Previous PC",        "Select previous PC"),
            new LotroSlashCommand(LotroCommands.Categories.Selection,
                             "Inspect", "Inspects the current target", "inspect"),
            new LotroSlashCommand(LotroCommands.Categories.Selection,
                             "Use", "'Use' the currently selected object, as if right-clicking it", "useselection"),
	    #endregion         
        }; 
	#endregion    
    }

    [Serializable()]
    public class LotroCommand
    {
        public String                   Name           {get; set;}
        public LotroCommands.Categories Category       {get; set;}
        public String                   Description    {get; set;}
    }

    [Serializable()]
    public class LotroSlashCommand : LotroCommand
    {   //====================================================================
        public String   Command     {get; set;}
        public String   ArgumentTip {get; set;}
        public String[] AllowedArgs {get; set;}
        
        public SlashCommandType Type {get; set;}
        public enum SlashCommandType {UNKNOWN, NoArg, StringArg, ArgChoice}

        public LotroSlashCommand(String name)
        {   //--------------------------------------------------------------------
            Name        = name;
            Type        = SlashCommandType.UNKNOWN;

            foreach (LotroCommand lc in LotroCommands.Commands)
            {
                if (lc is LotroSlashCommand && ((LotroSlashCommand)lc).Name == name)
                {
                    LotroSlashCommand lsc = (LotroSlashCommand)lc;
                    Command     = lsc.Command;
                    AllowedArgs = lsc.AllowedArgs;
                    Type        = lsc.Type;
                    Category    = lsc.Category;
                    Description = lsc.Description;
                    ArgumentTip = lsc.ArgumentTip;
                    break;
                }
            }
            if (Type == SlashCommandType.UNKNOWN) throw new ArgumentException();
            return;
        }

        public LotroSlashCommand()
        {
            Command     = String.Empty;
            ArgumentTip = String.Empty;
            AllowedArgs = null;
            Category    = LotroCommands.Categories.Unknown;
            Description = String.Empty;
            Name        = String.Empty;
        }
        public LotroSlashCommand(LotroCommands.Categories category, String name, String description, String command)
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
        public LotroSlashCommand(LotroCommands.Categories category, String name, String description, String command, String tip)
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
        public LotroSlashCommand(LotroCommands.Categories category, String name, String description, String command, String[] allowed)
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

    [Serializable()]
    public class LotroBindingCommand : LotroCommand
    {
        public String     MapfileName    {get; set;}
        public short      MappedScanCode {get; set;}
        public BuckyBits  Bits           {get; set;}

        public LotroBindingCommand()
        {
            MapfileName     = String.Empty;
            MappedScanCode  = 0;
            Bits            = new BuckyBits();
        }
        public LotroBindingCommand(String mapfilename)
        {
            foreach (LotroCommand lc in LotroCommands.Commands)
            {
                MapfileName = mapfilename;
                if (lc is LotroBindingCommand && MapfileName == ((LotroBindingCommand)lc).MapfileName)
                {
                    LotroBindingCommand lbc = (LotroBindingCommand)lc;
                    Name            = lbc.Name;
                    MappedScanCode  = lbc.MappedScanCode;
                    Bits            = lbc.Bits;
                    Category        = lbc.Category;
                    Description     = lbc.Description;
                }
            }
            if (Bits == null) throw new ArgumentException();
            return;
        }
        public LotroBindingCommand(LotroCommands.Categories cat, String strMapfileName, String strName, String strDesc)
        {
            MapfileName  = strMapfileName;
            Bits         = new BuckyBits();
            Category     = cat;
            Name         = strName;
            Description  = strDesc;
            return;
        }
    }

}