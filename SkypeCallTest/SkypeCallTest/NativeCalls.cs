using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace InvertedSoftwareRecorder
{
    [Flags]
    public enum SendMessageTimeoutFlags : uint
    {
        SMTO_NORMAL = 0x0,
        SMTO_BLOCK = 0x1,
        SMTO_ABORTIFHUNG = 0x2,
        SMTO_NOTIMEOUTIFNOTHUNG = 0x8
    }

    public static class NativeCalls
    {
        public static uint SKYPECONTROLAPI_ATTACH_SUCCESS = 0;
        public static uint SKYPECONTROLAPI_ATTACH_PENDING_AUTHORIZATION = 1;
        public static uint SKYPECONTROLAPI_ATTACH_REFUSED = 2;
        public static uint SKYPECONTROLAPI_ATTACH_NOT_AVAILABLE = 3;
        public static uint SKYPECONTROLAPI_ATTACH_API_AVAILABLE = 0x8001;
        // The type of message to pass between applications
        public const int WM_COPYDATA = 0x004A;
        // The Skypw window handle
        public static IntPtr HWND_BROADCAST = new IntPtr(-1);

        public static uint APIDiscover;
        public static uint APIAttach;
        // Handle to the current window
        private static IntPtr hWnd;

        #region Externals
        [DllImport("user32.dll")]
        static extern uint RegisterWindowMessage(string lpString);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageTimeout(IntPtr windowHandle, uint Msg, IntPtr wParam, IntPtr lParam, SendMessageTimeoutFlags flags, uint timeout, out IntPtr result);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageTimeout(IntPtr windowHandle, uint Msg, IntPtr wParam, ref COPYDATASTRUCT lParam, SendMessageTimeoutFlags flags, uint timeout, out IntPtr result); 
        #endregion

        /// <summary>
        /// Run at startup to register a system window message
        /// </summary>
        /// <param name="windowHandle">Handle to the current program window</param>
        /// <returns></returns>
        public static bool DetectSkype(IntPtr windowHandle)
        {
            hWnd = windowHandle;
            APIDiscover = RegisterWindowMessage(Utils.SkypeDiscover);
            if (APIDiscover == 0)
                return false;
            APIAttach = RegisterWindowMessage(Utils.SkypeAttach);
            if (APIAttach == 0)
                return false;

            return true;
        }

        public static void ConnectToSkype()
        {
            // To initiate communication, a client application broadcasts the SkypeControlAPIDiscover message, 
            // including its window handle as a wParam parameter. 
            // Skype responds with a SkypeControlAPIAttach message to the specified window and indicates the connection status.
            IntPtr result;
            IntPtr aResult = SendMessageTimeout(HWND_BROADCAST, APIDiscover, hWnd, IntPtr.Zero, SendMessageTimeoutFlags.SMTO_NORMAL, 100, out result);
        }

        /// <summary>
        /// Send a command to Skype
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool SendSkypeMessage(string command)
        {
            // Make a new message
            COPYDATASTRUCT message = new COPYDATASTRUCT() { dwData = "1", lpData = command };
            message.cbData = message.lpData.Length + 1;
            IntPtr result;
            IntPtr iResult = SendMessageTimeout(HWND_BROADCAST, WM_COPYDATA, hWnd, ref message, SendMessageTimeoutFlags.SMTO_NORMAL, 100, out result);
            if (iResult.ToInt32() == 0)
                return false;
            return true;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COPYDATASTRUCT
    {
        public string dwData;
        public int cbData;
        public string lpData;
    }
}
