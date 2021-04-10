using System;
using System.Runtime.InteropServices;

namespace Netput
{
    public class MouseController
    {
        private IMouseStrategy strategy;

        public MouseController()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                strategy = new WindowsMouseStrategy();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                strategy = new LinuxMouseStrategy();
        }

        public void Move(double x, double y) =>
            strategy.Move(x, y);

        public void Move_Tween(double x, double y, double milis)
        {
            throw new NotImplementedException("Tweening hard");
        }

        public void LeftClick(double x, double y)
        {
            strategy.Move(x, y);
            strategy.LeftClick();
        }

        public void LeftClick() =>
            strategy.LeftClick();

        public void RightClick(double x, double y)
        {
            strategy.Move(x, y);
            strategy.RightClick();
        }

        public void RightClick() =>
            strategy.RightClick();
    }
}