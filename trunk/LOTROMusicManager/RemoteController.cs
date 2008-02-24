using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LOTROMusicManager
{
    class RemoteController
    {
        public enum Focus {REMOTE, LOCAL, UNCHANGED}
        public static void ExecuteString(string str, Focus kf)
        {//====================================================================
            System.Diagnostics.Process[] ap = System.Diagnostics.Process.GetProcessesByName(Properties.Settings.Default.ClientAppID);
            if (ap.Length > 0)
            {
                SDK.BringWindowToTop(ap[0].MainWindowHandle);

                // Send RETURN, string, RETURN
                SendVK(SDK.VK_RETURN);
                SendString(str);
                SendVK(SDK.VK_RETURN);

                if (kf == Focus.LOCAL) System.Threading.Thread.Sleep(Properties.Settings.Default.MillisWaitOnCommand); // Let the commands execute so we can get focus again
            }
            else
            {
                MessageBox.Show("Unable to find LOTRO client to send commands", "LOTRO Music Manager", MessageBoxButtons.OK);
            }
            return;
        }

        public static void SendKey(char ch, Focus kf)
        {//====================================================================
            System.Diagnostics.Process[] ap = System.Diagnostics.Process.GetProcessesByName(Properties.Settings.Default.ClientAppID);
            if (ap.Length > 0)
            {
                SDK.BringWindowToTop(ap[0].MainWindowHandle);
                SendChar(ch);
                if (kf == Focus.LOCAL) System.Threading.Thread.Sleep(Properties.Settings.Default.MillisWaitOnCommand); // Let the commands execute so we can get focus again
            }
            else
            {
                MessageBox.Show("Unable to find LOTRO client to send commands", "LOTRO Music Manager", MessageBoxButtons.OK);
            }
            return;
        }

        private static void SendString(String str)
        {//--------------------------------------------------------------------
            for (int i = 0; i < str.Length; i += 1)
            {
                // Send a keydown followed by a keyup and use unicode so we 
                // don't have to mess with converting to VK codes
                //
                // Note: Only sends succesfully when there is an insertion 
                // caret on the LOTRO screen. Cannot send in-play keys
                //
                // To send keypresses when there is no insertion caret, send VKs
                SendChar(str[i]);
            }
            return;
        }

        private static void SendVK(short vk)
        {//--------------------------------------------------------------------
            // Convert the VK to a scancode
            IntPtr hkl = SDK.GetKeyboardLayout(0);
            uint scEnter = SDK.MapVirtualKeyEx((uint)vk, (uint)SDK.MAPVKFLAGS.MAPVK_VK_TO_VSC, hkl);

            // Now send the scancode as a press and depress
            SDK.INPUT input = new SDK.INPUT();
            input.type = (int)SDK.InputType.INPUT_KEYBOARD;
            input.ki.wVk = 0;
            input.ki.time = 0;
            input.ki.dwExtraInfo = (IntPtr)0;
            input.ki.wScan = (short)scEnter;

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
            input.ki.wVk = 0;
            input.ki.time = 0;
            input.ki.dwFlags = 0;
            input.ki.dwExtraInfo = (IntPtr)0;
            input.ki.wScan = (short)ch;
            
            input.ki.dwFlags = (int)SDK.KEYEVENTF.UNICODE & ~(int)SDK.KEYEVENTF.KEYUP;  // Not Keyup
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));

            input.ki.dwFlags = (int)SDK.KEYEVENTF.UNICODE |  (int)SDK.KEYEVENTF.KEYUP;   // And now lift the key up
            SDK.SendInput(1, ref input, Marshal.SizeOf(input));
            return;
        } // SendChar
    } // RemoteController class
}
