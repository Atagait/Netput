using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Netput
{
    public class WindowsMouseStrategy : IMouseStrategy
    {
        public WindowsMouseStrategy()
        {
            if(!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new PlatformNotSupportedException("WindowsMouseStrategy must be run on a Windows system.");
        }

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_MOVE = 0x01;
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void Move(double x, double y, int DisplayX = 1920, int DisplayY = 1080)
        {
            double xPercent = x / (double)DisplayX;
            double yPercent = y / (double)DisplayY;

            uint AbsoluteX = (uint)(65535 * xPercent);
            uint AbsoluteY = (uint)(65535 * yPercent);

            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, AbsoluteX, AbsoluteY, 0, 0);
        }

        public void LeftClick() =>
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

        public void RightClick() =>
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);

        public Point getPosition()
        {
            GetCursorPos(out Point pos);
            return pos;
        }
    }
}