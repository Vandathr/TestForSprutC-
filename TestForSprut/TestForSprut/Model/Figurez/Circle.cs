using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace TestForSprut
{
    internal class Circle: IFigure
    {
        private readonly int id;

        private Point2D[] mainPointN = new Point2D[2];

        private double radius;

        private double tempValue;

        private int currentColor;

        private int width;

        public void Draw(IVectorCanvas refToReceiver, PaintEventArgs args) => refToReceiver.AddFigure(this);



        public void Make(int startX, int startY, int endX, int endY)
        {
            mainPointN[0] = new Point2D(startX, startY, this);
            mainPointN[1] = new Point2D(endX, endY, this);

            radius = Math.Abs(endX - startX);
        }


        public bool CheckCross(int X, int Y, int width)
        {
            tempValue = Math.Pow(X - mainPointN[0].GetX(), 2) + Math.Pow(Y - mainPointN[0].GetY(), 2);

            if (tempValue > Math.Pow(radius - width, 2) && tempValue < Math.Pow(radius + width, 2)) return true;


            return false;
        }



        public void Scale(int endX, int endY)
        {
            if (mainPointN[0] != null)
                Make((int)mainPointN[0].GetX(), (int)mainPointN[0].GetY(), endX, endY);
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

        

        public Circle()
        {

        }


        


    }
}
