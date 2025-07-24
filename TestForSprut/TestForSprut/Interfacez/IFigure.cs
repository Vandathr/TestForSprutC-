using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForSprut
{
    internal interface IFigure
    {
        void Draw(IVectorCanvas refToReceiver, PaintEventArgs args);
        void Make(int startX, int startY, int endX, int endY);
        int GetColor();
        void SetColor(int colorIndex);
        void Move(int X, int Y);
        void SetWidth(int width);
        void Scale(int endX, int endY);
        Point2D GetPoint(int index);
        bool CheckCross(int X, int Y, int width);


    }
}
