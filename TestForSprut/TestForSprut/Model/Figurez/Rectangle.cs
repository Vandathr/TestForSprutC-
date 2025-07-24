using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace TestForSprut
{
    internal class Rectangle : IFigure
    {
        private Point2D[] mainPointN = new Point2D[2];
        private int currentColor;
        private int width;



        public void Draw(IVectorCanvas refToReceiver, PaintEventArgs args) => refToReceiver.AddFigure(this);




        public void Make(int startX, int startY, int endX, int endY)
        {
            var trueStartX = Math.Min(startX, endX);
            var trueEndX = Math.Max(startX, endX);

            var trueStartY = Math.Min(startY, endY);
            var trueEndY = Math.Max(startY, endY);

            mainPointN[0] = new Point2D(trueStartX, trueStartY, this);
            mainPointN[1] = new Point2D(trueEndX, trueEndY, this);

        }



        public bool CheckCross(int X, int Y, int width)
        {
            if (X >= mainPointN[0].GetX() - width && X <= mainPointN[1].GetX() + width && Y >= mainPointN[0].GetY() - width && Y <= mainPointN[1].GetY() + width)
            {
                if (Math.Abs(mainPointN[0].GetX() - X) < width || Math.Abs(mainPointN[1].GetX() - X) < width ||
                    Math.Abs(mainPointN[0].GetY() - Y) < width || Math.Abs(mainPointN[1].GetY() - Y) < width)
                {
                    return true;
                }
            }

            return false;
        }



        public void Scale(int endX, int endY)
        {

        }

        public Point2D GetPoint(int index) => mainPointN[index];

       

        public int GetColor() => currentColor;
        public void SetColor(int colorIndex) => currentColor = colorIndex;
        public void SetWidth(int width) => this.width = width;

        

        public void Move(int X, int Y)
        {
            mainPointN[0].Move(X, Y);
            mainPointN[1].Move(X, Y);
        }

        public Rectangle()
        {

        }



    }
}
