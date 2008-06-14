using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LotroMusicManager.Properties;
using System.Diagnostics;
using System.Threading;

namespace LotroMusicManager
{
    class Keymap
    {
        private static IntPtr _hkl    = new IntPtr();
        private static short _scShift  = 0;    
        private static short _scCtrl   = 0;
        private static short _scAlt    = 0;
        private static short _scReturn = 0;
        private static short _scWindows = 0;

        public short Shift   {get {return _scShift;}}
        public short Alt     {get {return _scAlt;}}
        public short Ctrl    {get {return _scCtrl;}}
        public short Return  {get {return _scReturn;}}
        public short Windows {get {return _scWindows;}}

        public Keymap()
        {
            _hkl = SDK.GetKeyboardLayout(0);
            _scShift   = (short)SDK.MapVirtualKeyEx((uint)SDK.VK.SHIFT,   (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
            _scAlt     = (short)SDK.MapVirtualKeyEx((uint)SDK.VK.ALT,     (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
            _scCtrl    = (short)SDK.MapVirtualKeyEx((uint)SDK.VK.CONTROL, (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
            _scReturn  = (short)SDK.MapVirtualKeyEx((uint)SDK.VK.RETURN,  (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
            _scWindows = (short)SDK.MapVirtualKeyEx((uint)SDK.VK.LWIN,    (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
        }

        public short ToScan(SDK.VK vk) {return ToScan((char)vk);}
        public short ToScan(char ch)
        {
            return (short)SDK.MapVirtualKeyEx((uint)ch,   (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, _hkl);
        }
    }

    public class RemoteController
    {
        private static Keymap _keys = new Keymap();

        public enum KEYSTATE {DOWN, UP};
        public enum Focus    {REMOTE, LOCAL, UNCHANGED}

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
            // That is (Return <String Length> + Return) * (UP + DOWN) = (string length + 2) * 2
            SDK.INPUT[] input = new SDK.INPUT[(strText.Length + 2) * 2];

            //--------------------------------------------------------------------
            // Return key down and up
            FillKeyInput(ref input[0], 0, _keys.Return, SDK.KEYEVENTF.SCANCODE, KEYSTATE.DOWN);
            FillKeyInput(ref input[1], 0, _keys.Return, SDK.KEYEVENTF.SCANCODE, KEYSTATE.UP);

            //--------------------------------------------------------------------
            // Add the string to send. The docs say that UNICODE doesn't require a 
            // KEYUP but it seems to consolidate duplicate keys without one :-(
            for (int i = 0; i < strText.Length; i += 1)
            {
                FillKeyInput(ref input[i * 2 + 2], 0, (short)strText[i], SDK.KEYEVENTF.UNICODE, KEYSTATE.DOWN);
                FillKeyInput(ref input[i * 2 + 3], 0, (short)strText[i], SDK.KEYEVENTF.UNICODE, KEYSTATE.UP);
            }

            //--------------------------------------------------------------------
            // Add the ending return
            FillKeyInput(ref input[strText.Length * 2 + 2], 0, _keys.Return, SDK.KEYEVENTF.SCANCODE, KEYSTATE.DOWN);
            FillKeyInput(ref input[strText.Length * 2 + 3], 0, _keys.Return, SDK.KEYEVENTF.SCANCODE, KEYSTATE.UP);

            //--------------------------------------------------------------------
            // And... send the input collection to Windows
            uint ret = SDK.SendInput((uint)input.Length, ref input[0], Marshal.SizeOf(input[0]));
            Thread.Sleep(Settings.Default.MillisWaitOnCommand); // Let the commands execute so we can get focus again

            return;
        }
        
        public static void SendScanCode(short scan, BuckyBits bits)
        {   //====================================================================
            if (!BringLOTROToTop()) return;

            SDK.INPUT[] input = new SDK.INPUT[8]; // 3 + down + up + 3
            //--------------------------------------------------------------------
            int iEvent = 0;
            if (bits.Shift)   FillKeyInput(ref input[iEvent++], SDK.VK.SHIFT,   _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);
            if (bits.Control) FillKeyInput(ref input[iEvent++], SDK.VK.CONTROL, _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);
            if (bits.Alt)     FillKeyInput(ref input[iEvent++], SDK.VK.ALT,     _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);

            //--------------------------------------------------------------------
            FillKeyInput(ref input[iEvent++], 0, scan, SDK.KEYEVENTF.SCANCODE, KEYSTATE.DOWN);
            FillKeyInput(ref input[iEvent++], 0, scan, SDK.KEYEVENTF.SCANCODE, KEYSTATE.UP);

            //--------------------------------------------------------------------
            if (bits.Shift)   FillKeyInput(ref input[iEvent++], SDK.VK.SHIFT,   _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);
            if (bits.Control) FillKeyInput(ref input[iEvent++], SDK.VK.CONTROL, _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);
            if (bits.Alt)     FillKeyInput(ref input[iEvent++], SDK.VK.ALT,     _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);

            //--------------------------------------------------------------------
            uint ret = SDK.SendInput((uint)iEvent, ref input[0], Marshal.SizeOf(input[0]));
            Thread.Sleep(Settings.Default.MillisWaitOnCommand); // Let the commands execute so we can get focus again

            return;
        }

        public static void SendChars(char[] ach, BuckyBits bits)
        {   //====================================================================
            // Okay...
            //  1) Send the BuckyBits as KEYDOWN with no flags, sending the VK *and* the 
            //     converted scancode
            //  2) Send the characters as SCANCODE (after mapping), DOWN and UP
            //  3) Send the BuckyBits as KEYUP with no flags, both VK and scancode
            //
            //  Potentially ALT, CONTROL, SHIFT, and each char in ach, all down and up
            if (!BringLOTROToTop()) return;

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
            uint ret = SDK.SendInput((uint)iEvent, ref input[0], Marshal.SizeOf(input[0]));
            Thread.Sleep(Settings.Default.MillisWaitOnCommand); // Let the commands execute so we can get focus again

            return;
        }

        public static void SendKey (SDK.VK    vk, BuckyBits bits) {SendKeys(new SDK.VK[] {vk}, bits);}
        public static void SendKeys(SDK.VK[] avk, BuckyBits bits)
        {   //====================================================================
            // Send the BuckyBits as KEYDOWN, no flags, VK and scancode
            // Send the converted VKs as mapped SCANCODE
            // Send the BuckyBits as KEYUP, no flags, VK and scancode
            if (!BringLOTROToTop()) return;

            int nMaxEvents = (avk.Length + 4) * 2; 
            SDK.INPUT[] input = new SDK.INPUT[nMaxEvents];

            int iEvent = 0;
            if (bits.Shift)   FillKeyInput(ref input[iEvent++], SDK.VK.SHIFT,   _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);
            if (bits.Control) FillKeyInput(ref input[iEvent++], SDK.VK.CONTROL, _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);
            if (bits.Alt)     FillKeyInput(ref input[iEvent++], SDK.VK.ALT,     _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);
            if (bits.Windows) FillKeyInput(ref input[iEvent++], SDK.VK.LWIN,    _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.DOWN);

            foreach (SDK.VK vk in avk)
            {
                short scan = _keys.ToScan(vk);
                FillKeyInput(ref input[iEvent++], 0, scan, SDK.KEYEVENTF.SCANCODE, KEYSTATE.DOWN);
                FillKeyInput(ref input[iEvent++], 0, scan, SDK.KEYEVENTF.SCANCODE, KEYSTATE.UP);
            }

            if (bits.Shift)   FillKeyInput(ref input[iEvent++], SDK.VK.SHIFT,   _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);
            if (bits.Control) FillKeyInput(ref input[iEvent++], SDK.VK.CONTROL, _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);
            if (bits.Alt)     FillKeyInput(ref input[iEvent++], SDK.VK.ALT,     _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);
            if (bits.Windows) FillKeyInput(ref input[iEvent++], SDK.VK.LWIN,    _keys.Shift, SDK.KEYEVENTF.NONE, KEYSTATE.UP);

            //--------------------------------------------------------------------
            // And... send the input collection to Windows
            uint ret = SDK.SendInput((uint)iEvent, ref input[0], Marshal.SizeOf(input[0]));
            Thread.Sleep(Settings.Default.MillisWaitOnCommand); // Let the commands execute so we can get focus again
            
            return;
        }

        public static void ExecuteFunction(String strFunctionName)
        {   //====================================================================
            MappedLotroCommand lf = MappedLotroCommand.Functions[strFunctionName];
            SendScanCode(lf.MappedScanCode, lf.Bits);
            return;
        }

    } // RemoteController class
}
