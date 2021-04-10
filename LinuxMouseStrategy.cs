using System;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Netput
{
    public class LinuxMouseStrategy : IMouseStrategy
    {
        // I'm not experienced enoguh to work out all the X11 needed
        // In the meantime, we'll have to rely on xdotool
        public LinuxMouseStrategy()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                throw new PlatformNotSupportedException("LinuxMouseStrategy must be run on a Linux system.");
        }

        public void Move(double x, double y, int DisplayX = 1920, int DisplayY = 1080)
        {
            Process.Start("xdotool", arguments:$"mousemove {x} {y}");
        }

        public void LeftClick() =>
            Process.Start("xdotool", arguments:$"click 1");

        public void RightClick() =>
            Process.Start("xdotool", arguments:$"click 3");

        public Point getPosition()
        {
            throw new NotImplementedException();
        }
    }
}