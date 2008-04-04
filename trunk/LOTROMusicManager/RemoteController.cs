using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LOTROMusicManager.Properties;
using System.Diagnostics;
using System.Threading;

namespace LOTROMusicManager
{
    class Keymap
    {
        private static IntPtr _hkl    = new IntPtr();
        private static short _scShift  = 0;    
        private static short _scCtrl   = 0;
        private static short _scAlt    = 0;
        private static short _scReturn = 0;

        public short Shift  {get {return _scShift;}}
        public short Alt    {get {return _scAlt;}}
        public short Ctrl   {get {return _scCtrl;}}
        public short Return {get {return _scReturn;}}

        public Keymap()
        {
            _hkl = SDK.GetKeyboardLayout(0);
            _scShift  = (short)SDK.MapVirtualKeyEx((uint)SDK.VK.SHIFT,   (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
            _scAlt    = (short)SDK.MapVirtualKeyEx((uint)SDK.VK.ALT,     (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
            _scCtrl   = (short)SDK.MapVirtualKeyEx((uint)SDK.VK.CONTROL, (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
            _scReturn = (short)SDK.MapVirtualKeyEx((uint)SDK.VK.RETURN,  (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
        }

        public short ToScan(SDK.VK vk) {return ToScan((char)vk);}
        public short ToScan(char ch)
        {
            return (short)SDK.MapVirtualKeyEx((uint)ch,   (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
        }
    }

    class RemoteController
    {
        private static Keymap _keys = new Keymap();

        public enum Focus {REMOTE, LOCAL, UNCHANGED}

        private static Boolean BringLOTROToTop()
        {   //====================================================================
            Process[] ap = Process.GetProcessesByName(Settings.Default.ClientAppID);
            if (0 == ap.Length)
            {
                MessageBox.Show("Unable to find LOTRO client to send commands", "LOTRO Music Manager", MessageBoxButtons.OK);
                return false;
            }
            SDK.BringWindowToTop(ap[0].MainWindowHandle);
            return true;
        }

        //====================================================================
        // Okay...
        // Clients of this class need to:
        //
        //  - Send a string as text (to say things, use a command, etc). 
        //  SendText(String strText)
        //    This means doing the RETURNs for them.
        //    This should be just ASCII-type text
        //    Note that these are *always* commands, from the game's POV, since
        //      even /say and /f are commands.
        //    Question: should we allow "default channel" as an option? I don't
        //      think so.
        //
        //    This means:
        //      1) Send VK_RETURN (down and up) as SCANCODE (after mapping VK to SCANCODE)
        //      2) Send the string as UNICODE
        //      3) Send VL_RETURN (down and up) as SCANCODE (after mapping VK to SCANCODE)
        //
        //  - Send a string as game buttons (to press hotkeys)
        //  SendChars(char[] ach, BuckyBits bits)
        //    This means sending keys to send and a BuckyBits object
        //    Question: How to represent VKs, like TAB and ESC?
        //
        //    This mean:
        //      1) Send the BuckyBits as KEYDOWN with no flags, sending the VK *and* the 
        //         converted scancode
        //      2) Send the characters as SCANCODE (after mapping)
        //      3) Send the BuckyBits as KEYUP with no flags, both VK and scancode
        //
        //  - Send an array of VKs with a BuckyBits object
        //  SendKeys(Win32.VK[] avk, BuckyBits bits)
        //      This allows for SHIFT-TAB, for example
        //
        //  This means:
        //      1) Send the BuckyBits as KEYDOWN, no flags, VK and scancode
        //      2) Send the converted VKs as mapped SCANCODE
        //      3) Send the BuckyBits as KEYUP, no flags, VK and scancode

        private static void FillKeyInput(ref SDK.INPUT input, SDK.VK vk, short wScan, SDK.KEYEVENTF keytype, KEYSTATE direction)
        {   //====================================================================
            input.type = (int)SDK.InputType.INPUT_KEYBOARD;
            input.ki.wVk         = (short)vk;
            input.ki.time        = 0;
            input.ki.dwExtraInfo = (IntPtr)0;
            input.ki.wScan       = wScan;
            input.ki.dwFlags     = (int)keytype | (int)(direction == KEYSTATE.DOWN ? (int) SDK.KEYEVENTF.KEYDOWN : (int)SDK.KEYEVENTF.KEYUP);
            return;
        }

        public static void SendText(String strText)
        {   //====================================================================
            if (!BringLOTROToTop()) return;
            
            // Okay... we're sending
            //   VK_RETURN (down and up) as SCANCODE (after mapping VK to SCANCODE)
            //   The string as UNICODE
            //   VL_RETURN (down and up) as SCANCODE (after mapping VK to SCANCODE)
            //
            // That is (Return DOWN + UP + <String Length> + Return DOWN + UP) = string length + 4
            SDK.INPUT[] input = new SDK.INPUT[strText.Length + 4];

            //--------------------------------------------------------------------
            // Return key down and up
            FillKeyInput(ref input[0], 0, _keys.Return, SDK.KEYEVENTF.SCANCODE, KEYSTATE.DOWN);
            FillKeyInput(ref input[1], 0, _keys.Return, SDK.KEYEVENTF.SCANCODE, KEYSTATE.UP);

            //--------------------------------------------------------------------
            // Add the string to send. UNICODE doesn't require a KEYUP
            for (int i = 0; i < strText.Length; i += 1)
            {
                FillKeyInput(ref input[i + 2], 0, (short)strText[i], SDK.KEYEVENTF.UNICODE, KEYSTATE.DOWN);
            }

            //--------------------------------------------------------------------
            // Add the ending return
            FillKeyInput(ref input[strText.Length + 2], 0, _keys.Return, SDK.KEYEVENTF.SCANCODE, KEYSTATE.DOWN);
            FillKeyInput(ref input[strText.Length + 3], 0, _keys.Return, SDK.KEYEVENTF.SCANCODE, KEYSTATE.UP);

            //--------------------------------------------------------------------
            // And... send the input collection to Windows
            uint ret = SDK.SendInput((uint)input.Length, ref input[0], Marshal.SizeOf(input[0]));
            Thread.Sleep(Settings.Default.MillisWaitOnCommand); // Let the commands execute so we can get focus again

            return;
        }
        
        public static void SendChars(char[] ach, BuckyBits bits)
        {   //====================================================================
            if (!BringLOTROToTop()) return;
            
            // Okay...
            //  1) Send the BuckyBits as KEYDOWN with no flags, sending the VK *and* the 
            //     converted scancode
            //  2) Send the characters as SCANCODE (after mapping), DOWN and UP
            //  3) Send the BuckyBits as KEYUP with no flags, both VK and scancode
            //
            //  Potentially ALT, CONTROL, SHIFT, and each char in ach, all down and up
            int nMaxEvents = (ach.Length + 3) * 2; 
            SDK.INPUT[] input = new SDK.INPUT[nMaxEvents];

            int iEvent = 0;
            if (bits.Shift)   FillKeyInput(ref input[iEvent++], SDK.VK.SHIFT,   _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);
            if (bits.Control) FillKeyInput(ref input[iEvent++], SDK.VK.CONTROL, _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);
            if (bits.Alt)     FillKeyInput(ref input[iEvent++], SDK.VK.ALT,     _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);

            foreach (char ch in ach)
            {
                short scan = _keys.ToScan(ch);
                FillKeyInput(ref input[iEvent++], 0, scan, SDK.KEYEVENTF.SCANCODE, KEYSTATE.DOWN);
                FillKeyInput(ref input[iEvent++], 0, scan, SDK.KEYEVENTF.SCANCODE, KEYSTATE.UP);
            }

            if (bits.Shift)   FillKeyInput(ref input[iEvent++], SDK.VK.SHIFT,   _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);
            if (bits.Control) FillKeyInput(ref input[iEvent++], SDK.VK.CONTROL, _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);
            if (bits.Alt)     FillKeyInput(ref input[iEvent++], SDK.VK.ALT,     _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);

            //--------------------------------------------------------------------
            // And... send the input collection to Windows
            uint ret = SDK.SendInput((uint)input.Length, ref input[0], Marshal.SizeOf(input[0]));
            Thread.Sleep(Settings.Default.MillisWaitOnCommand); // Let the commands execute so we can get focus again

            return;
        }

        public static void SendKeys(SDK.VK[] avk, BuckyBits bits)
        {   //====================================================================
            // Send the BuckyBits as KEYDOWN, no flags, VK and scancode
            // Send the converted VKs as mapped SCANCODE
            // Send the BuckyBits as KEYUP, no flags, VK and scancode
            int nMaxEvents = (avk.Length + 3) * 2; 
            SDK.INPUT[] input = new SDK.INPUT[nMaxEvents];

            int iEvent = 0;
            if (bits.Shift)   FillKeyInput(ref input[iEvent++], SDK.VK.SHIFT,   _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);
            if (bits.Control) FillKeyInput(ref input[iEvent++], SDK.VK.CONTROL, _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);
            if (bits.Alt)     FillKeyInput(ref input[iEvent++], SDK.VK.ALT,     _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);

            foreach (SDK.VK vk in avk)
            {
                short scan = _keys.ToScan(vk);
                FillKeyInput(ref input[iEvent++], 0, scan, SDK.KEYEVENTF.SCANCODE, KEYSTATE.DOWN);
                FillKeyInput(ref input[iEvent++], 0, scan, SDK.KEYEVENTF.SCANCODE, KEYSTATE.UP);
            }

            if (bits.Shift)   FillKeyInput(ref input[iEvent++], SDK.VK.SHIFT,   _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);
            if (bits.Control) FillKeyInput(ref input[iEvent++], SDK.VK.CONTROL, _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);
            if (bits.Alt)     FillKeyInput(ref input[iEvent++], SDK.VK.ALT,     _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);

            //--------------------------------------------------------------------
            // And... send the input collection to Windows
            uint ret = SDK.SendInput((uint)input.Length, ref input[0], Marshal.SizeOf(input[0]));
            Thread.Sleep(Settings.Default.MillisWaitOnCommand); // Let the commands execute so we can get focus again
            
            return;
        }


        //====================================================================
        //====================================================================
        //====================================================================
        //====================================================================

        public enum KEYSTATE {DOWN, UP};
        
        public static void SendKey(char  ch, BuckyBits bits) {SendKey((short)ch, bits); return;}
        public static void SendKey(short vk, BuckyBits bits)
        {   //====================================================================
            bits.Shift = true;
            if (!BringLOTROToTop()) return;
            // Get scancodes for the bucky bits and the char
            IntPtr hkl  = SDK.GetKeyboardLayout(0);
            uint scKey  = SDK.MapVirtualKeyEx((uint)vk,             (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, hkl);
            uint scAlt  = SDK.MapVirtualKeyEx((uint)SDK.VK.ALT,     (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, hkl);
            uint scCtrl = SDK.MapVirtualKeyEx((uint)SDK.VK.CONTROL, (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, hkl);
            uint scShift= SDK.MapVirtualKeyEx((uint)SDK.VK.SHIFT,   (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, hkl);
            
            //if (bits.Shift)   SetKeyState(SDK.VK.SHIFT,   KEYSTATE.DOWN);
            //if (bits.Alt)     SetKeyState(SDK.VK.ALT,     KEYSTATE.DOWN);
            //if (bits.Control) SetKeyState(SDK.VK.CONTROL, KEYSTATE.DOWN);

                SendVK2(vk);
            
            //if (bits.Control) SetKeyState(SDK.VK.CONTROL, KEYSTATE.UP);
            //if (bits.Alt)     SetKeyState(SDK.VK.ALT,     KEYSTATE.UP);
            //if (bits.Shift)   SetKeyState(SDK.VK.SHIFT,   KEYSTATE.UP);

            return;
        }

        private static void SendVK2(short vk)
        {//--------------------------------------------------------------------
            // Convert the VK to a scancode
            IntPtr hkl   = SDK.GetKeyboardLayout(0);
            uint scKey   = SDK.MapVirtualKeyEx((uint)vk, (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, hkl);
            uint scShift = SDK.MapVirtualKeyEx((uint)SDK.VK.SHIFT,   (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, hkl);

            // Now send the scancode as a press and depress
            SDK.INPUT[] input = new SDK.INPUT[4];
            input[0].type = (int)SDK.InputType.INPUT_KEYBOARD;
            input[0].ki.wVk = (short)SDK.VK.SHIFT;
            input[0].ki.time = 0;
            input[0].ki.dwExtraInfo = (IntPtr)0;
            input[0].ki.wScan = (short)scShift;
            input[0].ki.dwFlags = (int)SDK.KEYEVENTF.KEYDOWN;

            input[1].type = (int)SDK.InputType.INPUT_KEYBOARD;
            input[1].ki.wVk = 0;
            input[1].ki.time = 0;
            input[1].ki.dwExtraInfo = (IntPtr)0;
            input[1].ki.wScan = (short)scKey;
            input[1].ki.dwFlags = (int)SDK.KEYEVENTF.SCANCODE | (int)SDK.KEYEVENTF.KEYDOWN;

            input[2].type = (int)SDK.InputType.INPUT_KEYBOARD;
            input[2].ki.wVk = 0;
            input[2].ki.time = 0;
            input[2].ki.dwExtraInfo = (IntPtr)0;
            input[2].ki.wScan = (short)scKey;
            input[2].ki.dwFlags = (int)SDK.KEYEVENTF.SCANCODE | (int)SDK.KEYEVENTF.KEYUP;

            input[3].type = (int)SDK.InputType.INPUT_KEYBOARD;
            input[3].ki.wVk = (short)SDK.VK.SHIFT;
            input[3].ki.time = 0;
            input[3].ki.dwExtraInfo = (IntPtr)0;
            input[3].ki.wScan = (short)scShift;
            input[3].ki.dwFlags = (int)SDK.KEYEVENTF.KEYUP;

            uint ret = SDK.SendInput(4, ref input[0], Marshal.SizeOf(input[0]));
            Thread.Sleep(Settings.Default.MillisWaitOnCommand); // Let the commands execute so we can get focus again

            return;
        }

        private static void SendVK(short vk)
        {//--------------------------------------------------------------------
            // Convert the VK to a scancode
            IntPtr hkl = SDK.GetKeyboardLayout(0);
            uint scKey = SDK.MapVirtualKeyEx((uint)vk, (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, hkl);

            // Now send the scancode as a press and depress
            SDK.INPUT input = new SDK.INPUT();
            input.type = (int)SDK.InputType.INPUT_KEYBOARD;
            input.ki.wVk = 0;
            input.ki.time = 0;
            input.ki.dwExtraInfo = (IntPtr)0;
            input.ki.wScan = (short)scKey;

            input.ki.dwFlags = (int)SDK.KEYEVENTF.SCANCODE;
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));
            input.ki.dwFlags |= (int)SDK.KEYEVENTF.KEYUP;
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));

            return;
        }

        private static void SendChar(char ch)
        {//--------------------------------------------------------------------
            // Use SendInput so even DirectX apps get the keys
            SDK.INPUT input = new SDK.INPUT();
            input.type = (int)SDK.InputType.INPUT_KEYBOARD;
            input.ki.wVk         = 0;           // Ignored if SCANCODE or UNICODE is supplied
            input.ki.time        = 0;           // System provides
            input.ki.dwFlags     = 0;           // Assigned below
            input.ki.dwExtraInfo = (IntPtr)0;   // No extra info
            input.ki.wScan       = (short)ch;   // Char to send. Scancode for letters and numbers is their ASCII
            
            input.ki.dwFlags = (int)SDK.KEYEVENTF.UNICODE & ~(int)SDK.KEYEVENTF.KEYUP;  // Not Keyup
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));

            input.ki.dwFlags = (int)SDK.KEYEVENTF.UNICODE |  (int)SDK.KEYEVENTF.KEYUP;   // And now lift the key up
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));
            return;
        } // SendChar
    } // RemoteController class
}
