﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1434
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LotroMusicManager.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("lotroclient")]
        public string ClientAppID {
            get {
                return ((string)(this["ClientAppID"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool PlaySync {
            get {
                return ((bool)(this["PlaySync"]));
            }
            set {
                this["PlaySync"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AOT {
            get {
                return ((bool)(this["AOT"]));
            }
            set {
                this["AOT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100, 100")]
        public global::System.Drawing.Point WindowLocation {
            get {
                return ((global::System.Drawing.Point)(this["WindowLocation"]));
            }
            set {
                this["WindowLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("746, 618")]
        public global::System.Drawing.Size WindowSize {
            get {
                return ((global::System.Drawing.Size)(this["WindowSize"]));
            }
            set {
                this["WindowSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("12")]
        public string EditorFontSize {
            get {
                return ((string)(this["EditorFontSize"]));
            }
            set {
                this["EditorFontSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public string Opacity {
            get {
                return ((string)(this["Opacity"]));
            }
            set {
                this["Opacity"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>(basic dances)</string>
  <string>  /dance</string>
  <string>  /dance1</string>
  <string>  /dance2</string>
  <string>  /dance3</string>
  <string>(learned dances)</string>
  <string>  /dance_hobbit </string>
  <string>  /dance_elf</string>
  <string>  /dance_man</string>
  <string>  /dance_dwarf</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection Dances {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Dances"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>(meet and greet)</string>
  <string>  /wave</string>
  <string>  /salute</string>
  <string>  /bow</string>
  <string>  /curtsey</string>
  <string>  /hug</string>
  <string>  /kiss</string>
  <string>  /bye</string>
  <string>(converse)</string>
  <string>  /yes</string>
  <string>  /no</string>
  <string>  /shrug</string>
  <string>  /sorry</string>
  <string>  /thank</string>
  <string>(settle in)</string>
  <string>  /sit</string>
  <string>  /kneel</string>
  <string>  /liedown</string>
  <string>  /stretch</string>
  <string>  /smoke</string>
  <string>  /smoke1</string>
  <string>  /story</string>
  <string>  /talk</string>
  <string> /dustoff</string>
  <string>(respond)</string>
  <string>  /cheer</string>
  <string>  /clap</string>
  <string>  /laugh</string>
  <string>  /bored</string>
  <string>  /fidget</string>
  <string>  /impatient</string>
  <string>  /cry</string>
  <string>  /whistle</string>
  <string>  /yawn</string>
  <string>(hobbits)</string>
  <string>  /eat</string>
  <string>  /drink</string>
  <string>  /burp</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection Emotes {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Emotes"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>(moods)</string>
  <string>  /mood_angry</string>
  <string>  /mood_apprehensive</string>
  <string>  /mood_calm</string>
  <string>  /mood_confused</string>
  <string>  /mood_fearful</string>
  <string>  /mood_happy</string>
  <string>  /mood_mischievous</string>
  <string>  /mood_sad</string>
  <string>  /mood_sleepy</string>
  <string>  /mood_solemn</string>
  <string>  /mood_surprised</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection Moods {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Moods"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Bestows an Emote</string>
  <string> /cheer (grants /firebreath - receive 100 - max 5/day)</string>
  <string> /bow  (grants /heropose - receive 100 - max 5/day)</string>
  <string> /laugh (grants /juggle - receive 200 - max 6/day)</string>
  <string> /salute (grants /swordsalute - receive 100 - max 5/day)</string>
  <string>Bestowes a Title</string>
  <string> /hug (grants The Adorable: 100 times - max 5/day)</string>
  <string> /flirt (grants The Alluring: 100 times  - max 5/day)</string>
  <string> /confused (grants The Befuddling: 100 times - max 5/day)</string>
  <string> /kiss (grants The Beloved: 100 times - max 5/day) </string>
  <string> /bored (grants The Dull: 100 times - max 5/day)</string>
  <string> /beg (grants The Harrassed: 100 times - max 5/day)</string>
  <string> /thank (grants The Helpful: 100 times - max 5/day)</string>
  <string> /angry (grants The Infuriating: 100 times - max 5/day)</string>
  <string> /rude (grants The Insulted: 200 times - max 5?/day)</string>
  <string> /cower (grants The Intimidating: 40 times - max 2/day)</string>
  <string> /scold (grants The Naughty:  100 times - max 5/day)</string>
  <string> /mock (grants The Ridiculed: 100 times - max 5/day)</string>
  <string> /surrender (grants The Victorious: 40 times - max 2/day)</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection Bestowals {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Bestowals"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("250")]
        public int MillisWaitOnCommand {
            get {
                return ((int)(this["MillisWaitOnCommand"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::MarkedEditBox.RegexTagBag TagsEdit {
            get {
                return ((global::MarkedEditBox.RegexTagBag)(this["TagsEdit"]));
            }
            set {
                this["TagsEdit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::MarkedEditBox.RegexTagBag TagsPerform {
            get {
                return ((global::MarkedEditBox.RegexTagBag)(this["TagsPerform"]));
            }
            set {
                this["TagsPerform"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MyLotroBandLoginEmail {
            get {
                return ((string)(this["MyLotroBandLoginEmail"]));
            }
            set {
                this["MyLotroBandLoginEmail"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MyLotroBandLoginPW {
            get {
                return ((string)(this["MyLotroBandLoginPW"]));
            }
            set {
                this["MyLotroBandLoginPW"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MyLotroBandRememberLoginInformation {
            get {
                return ((bool)(this["MyLotroBandRememberLoginInformation"]));
            }
            set {
                this["MyLotroBandRememberLoginInformation"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("400")]
        public int FocusTimeout {
            get {
                return ((int)(this["FocusTimeout"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool KeepLOTROFocused {
            get {
                return ((bool)(this["KeepLOTROFocused"]));
            }
            set {
                this["KeepLOTROFocused"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool HighlightABC {
            get {
                return ((bool)(this["HighlightABC"]));
            }
            set {
                this["HighlightABC"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::LotroMusicManager.MacroList Macros {
            get {
                return ((global::LotroMusicManager.MacroList)(this["Macros"]));
            }
            set {
                this["Macros"] = value;
            }
        }
    }
}