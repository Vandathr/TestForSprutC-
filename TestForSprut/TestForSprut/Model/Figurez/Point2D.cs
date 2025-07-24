using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForSprut
{
    internal class Point2D: ICanvasCell
    {
        private readonly IFigure refToOwner;

        private double X;
        private double Y;

        public double GetX() => X;
        public double GetY() => Y;
        public int GetColor() => refToOwner.GetColor();
        public IFigure GetOwner() => refToOwner;

        public void Move(int X, int Y)
        {
            this.X += X;
            this.Y += Y;
        }



        public Point2D(double X, double Y, IFigure refToOwner)
        {
            this.X = X;
            this.Y = Y;

            this.refToOwner = refToOwner;
        }

        
    }
}
