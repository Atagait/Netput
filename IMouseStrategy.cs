using System.Drawing;

namespace Netput
{
    public interface IMouseStrategy
    {
        void Move(double x, double y, int DisplayX = 1920, int DisplayY = 1080);
        void LeftClick();
        void RightClick();
        Point getPosition();
    }
}