using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForSprut
{
    internal class Map
    {
        private int canvasHeight = 2000;
        private int canvasWidth = 2000;


        private readonly ICanvasCell[,] mapN;

        private readonly List<IFigure> figureN = new List<IFigure>();

        private readonly NullCell EmptyCell = new NullCell();

        private IFigure refToActiveFigure;

        private int previousColorOfTheFigure;

        private int tempX;
        private int tempY;

        private List<Point2D> refToPointN;


        public void MakeFigure(int indexOfCommand, int color, int width)
        {
            if (indexOfCommand == 1)
            {
                figureN.Add(new Line());

                refToActiveFigure = figureN.Last();
                refToActiveFigure.SetColor(color);
                refToActiveFigure.SetWidth(width);
            }
            else if (indexOfCommand == 2)
            {
                figureN.Add(new Rectangle());

                refToActiveFigure = figureN.Last();
                refToActiveFigure.SetColor(color);
                refToActiveFigure.SetWidth(width);
            }
            else if (indexOfCommand == 3)
            {
                figureN.Add(new Circle());

                refToActiveFigure = figureN.Last();
                refToActiveFigure.SetColor(color);
                refToActiveFigure.SetWidth(width);
            }

        }


        public void SelectFigure(int X, int Y)
        {
            if (refToActiveFigure != null && refToActiveFigure.GetColor() == 1)                  
            {                     
                refToActiveFigure.SetColor(previousColorOfTheFigure);       
            }
            
            refToActiveFigure = figureN.Find(e => e.CheckCross(X, Y, 20));

            if (refToActiveFigure != null)
            {
                previousColorOfTheFigure = refToActiveFigure.GetColor();

                refToActiveFigure.SetColor(1);
            }


        }


        public void FillActiveFigure(Point startPoint, int endX, int endY)
        {
            if (refToActiveFigure != null)
            {
                refToActiveFigure.Make(startPoint.X, startPoint.Y, endX, endY);
            }
        }

        




        public void ScaleActiveFigure(int endX, int endY) 
        {
            if (refToActiveFigure != null)
            {
                refToActiveFigure.Scale(endX, endY);
            }
        } 



        public void Draw(MapPanel refToCanvas, PaintEventArgs args)
        {
            for (int i = 0; i < figureN.Count; i++)
            {
                figureN[i].Draw(refToCanvas, args);
            }
        }


        public void DeleteFigure()
        {
            for (int i = 0; i < mapN.GetLength(0); i++)
                for (int j = 0; j < mapN.GetLength(1); j++)
                    mapN[i, j] = EmptyCell;

            figureN.Remove(refToActiveFigure);
        }





        public void SetCurrentColor(int indexOfColor)
        {
            if (refToActiveFigure != null)
            {
                refToActiveFigure.SetColor(indexOfColor);
            }
        }


        public void SetCurrentWidth(int width)
        {
            if (refToActiveFigure != null)
            {
                refToActiveFigure.SetWidth(width);
            }
        }




        public void MoveSelectedFigure(int X, int Y) => refToActiveFigure.Move(X, Y);




        public void ClearMap()
        {
            figureN.Clear();

            for (int i = 0; i < mapN.GetLength(0); i++)
                for (int j = 0; j < mapN.GetLength(1); j++)
                    mapN[i, j] = EmptyCell;
        }



        public void SendToMap(ICanvasCell Cell) 
        {
            if(Cell.GetX() > 0 && Cell.GetX() < canvasWidth && Cell.GetY() > 0 && Cell.GetY() < canvasHeight)
                mapN[(int)Cell.GetX(), (int)Cell.GetY()] = Cell;

        }




        public Map()
        {
            mapN = new ICanvasCell[canvasWidth, canvasHeight];


            for (int i = 0; i < mapN.GetLength(0); i++)
                for (int j = 0; j < mapN.GetLength(1); j++)
                    mapN[i, j] = EmptyCell;
        }






        public ICanvasCell this[int X, int Y] => mapN [X, Y];
            
        



    }
}
