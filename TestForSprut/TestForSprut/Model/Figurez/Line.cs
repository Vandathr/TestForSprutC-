using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace TestForSprut
{
    internal class Line: IFigure
    {
        private readonly int id;

        private Point2D[] mainPointN = new Point2D[2];


        //private readonly List<Point2D> pointN = new List<Point2D>();

        private int currentColor;

        private int width;

        private double parallelKoefficient;

        private bool isCrossed;


        public void Draw(IVectorCanvas refToReceiver, PaintEventArgs args) => refToReceiver.AddFigure(this);



        


        public void Make(int startX, int startY, int endX, int endY)
        {
            mainPointN[0] = new Point2D(startX, startY, this);
            mainPointN[1] = new Point2D(endX, endY, this);
        }


        public bool CheckCross(int X, int Y, int width)
        {
            parallelKoefficient = (mainPointN[1].GetY() - mainPointN[0].GetY()) / (double)(mainPointN[1].GetX() - mainPointN[0].GetX());

            isCrossed = (parallelKoefficient * (X - mainPointN[0].GetX() + width) - (Y - mainPointN[0].GetY() + width)) * 
                (parallelKoefficient * (X - mainPointN[0].GetX() - width) - (Y - mainPointN[0].GetY() - width))  < 0;


            if (isCrossed)
            {
                return true;
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






        public Line()
        {

        }


          

        
    }
}
