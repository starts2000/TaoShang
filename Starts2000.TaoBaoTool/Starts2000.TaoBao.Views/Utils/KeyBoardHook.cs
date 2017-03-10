using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Starts2000.TaoBao.Views.Utils
{
    internal static class KeyBoardHook
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern void keybd_event(byte bVk,
            byte bScan, int dwFlags, int dwExtraInfo);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern void mouse_event(int flags, 
            int dx, int dy, int dwData, int dwExtraInfo);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool SetCursorPos(int X, int Y);

        public static void Key(Keys keyCode)
        {
            Thread.Sleep(10);
            KeyDown(keyCode);
            Thread.Sleep(10);
            KeyUp(keyCode);
            Thread.Sleep(10);
        }

        public static void KeyDown(Keys keyCode)
        {
            keybd_event((byte)keyCode, 0, 1, 0);
        }

        public static void KeyUp(Keys keyCode)
        {
            keybd_event((byte)keyCode, 0, 2, 0);
        }
    }
}