using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace LOTROMusicManager
{
    internal class SDK
    {
        //[DllImport("User32.dll")] public extern static int     SendMessageA    (IntPtr hwnd, int msg, int wParam, int lParam);
        //[DllImport("User32.Dll")] public static extern IntPtr  PostMessageA    (IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("User32.Dll")] public static extern Boolean BringWindowToTop(IntPtr hWnd);

        //public const int WM_CHAR = 0x0102; 
                         
        [DllImport("user32.dll", EntryPoint = "SendInput", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

        public enum InputType
        {
            INPUT_MOUSE    = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2,
        }

        [Flags()]
        public enum MOUSEEVENTF
        {
            MOVE =        0x0001,  // mouse move 
            LEFTDOWN =    0x0002,  // left button down
            LEFTUP =      0x0004,  // left button up
            RIGHTDOWN =   0x0008,  // right button down
            RIGHTUP =     0x0010,  // right button up
            MIDDLEDOWN =  0x0020,  // middle button down
            MIDDLEUP =    0x0040,  // middle button up
            XDOWN =       0x0080,  // x button down 
            XUP =         0x0100,  // x button down
            WHEEL =       0x0800,  // wheel button rolled
            VIRTUALDESK = 0x4000,  // map to entire virtual desktop
            ABSOLUTE =    0x8000,  // absolute move
        }

        [Flags()]
        public enum KEYEVENTF
        {
            EXTENDEDKEY = 0x0001,
            KEYUP       = 0x0002,
            UNICODE     = 0x0004,
            SCANCODE    = 0x0008,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        } 
  
        public const int VK_RETURN = 0x0D;

        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyEx", SetLastError = true)]
        public static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);

        public enum MAPVKFLAGS
        {
            MAPVK_VK_TO_VSC    = 0,
            MAPVK_VSC_TO_VK    = 1,
            MAPVK_VK_TO_CHAR   = 2,
            MAPVK_VSC_TO_VK_EX = 3, // NT and later
            MAPVK_VK_TO_VSC_EX = 4  // Vista and later
        }

        public enum KLFFlags
        {
            KLF_ACTIVATE        = 0x00000001,
            KLF_SUBSTITUTE_OK   = 0x00000002,
            KLF_REORDER         = 0x00000008,
            KLF_REPLACELANG     = 0x00000010,
            KLF_NOTELLSHELL     = 0x00000080,
            KLF_SETFORPROCESS   = 0x00000100,
            KLF_SHIFTLOCK       = 0x00010000,
            KLF_RESET           = 0x40000000
        }

        [DllImport("user32.dll", EntryPoint = "GetKeyboardLayout", SetLastError = true)]
        public static extern IntPtr GetKeyboardLayout(uint idThread);
    }
}
