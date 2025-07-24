using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;
using System.Windows.Controls;

namespace TestForSprut
{
    internal class MapPanel : System.Windows.Forms.Panel, IVectorCanvas
    {
        private readonly Visual refToVisual;
        private readonly PictureBox PaintArea = new PictureBox();


        
        private readonly List<IFigure> figureN = new List<IFigure>();   

        private readonly List<ICanvasCell> pointN = new List<ICanvasCell>();

        private readonly Pen[] colorPenN = new Pen[]
        {
            new Pen(Color.White),
            new Pen(Color.Gray),
            new Pen(Color.Red),
            new Pen(Color.Blue),
            new Pen(Color.Yellow),
            new Pen(Color.Green),
        };




        private int indexOfCurrentColor;

        private int width;

        private float scale = 1;


        private int coordinateStartX;
        private int coordinateStartY;
        private int coordinateEndX;
        private int coordinateEndY;

        private int radius;


        public void SetMapSize(int sizeX, int sizeY)
        {
            PaintArea.Width = sizeX;
            PaintArea.Height = sizeY;
        }


        
        public void RefreshCanvas() => PaintArea.Invalidate();



        public void AddVertex(ICanvasCell Cell) => pointN.Add(Cell);

        public void AddFigure(IFigure ToAdd) => figureN.Add(ToAdd);


        public void ClearMap() => figureN.Clear();


        public MapPanel(Visual refToVisual, int locationX, int locationY, int sizeX, int sizeY)
        {
            this.refToVisual = refToVisual;

            Location = new Point(locationX, locationY);
            Size = new Size(sizeX, sizeY);


            AutoScroll = true;
            HorizontalScroll.Enabled = true;

            PaintArea.Location = new System.Drawing.Point(0, 0);
            PaintArea.Size = new System.Drawing.Size(sizeX, sizeY);

            PaintArea.BackColor = Color.White;

            PaintArea.Paint += (sender, args) => Draw(args);

            PaintArea.MouseDown += (sender, args) => MapMouseDown(args);

            PaintArea.MouseUp += (sender, args) => MapMouseUp(args);

            PaintArea.MouseMove += (sender, args) => MapMouseMove(args);

            //PaintArea.Click += (sender, args) => MapClick((MouseEventArgs)args);

            PaintArea.DoubleClick += (sender, args) => MapDoubleClick((MouseEventArgs)args);

            PaintArea.MouseWheel += (sender, args) => ResizeCanvas(args);


            BorderStyle = BorderStyle.Fixed3D;

            Controls.Add(PaintArea);
        }



        private void Draw(PaintEventArgs args)
        {
            args.Graphics.Clear(Color.White);

            figureN.Clear();

            refToVisual.Draw(this, args);

            colorPenN[indexOfCurrentColor].Width = width;

            args.Graphics.ScaleTransform(scale, scale);

            for (int i = 0; i < figureN.Count; i++)
            {
                if (figureN[i] is Rectangle && figureN[i].GetPoint(0) != null && figureN[i].GetPoint(1) != null)
                {
                    coordinateStartX = (int)figureN[i].GetPoint(0).GetX();
                    coordinateStartY = (int)figureN[i].GetPoint(0).GetY();
                    coordinateEndX = (int)figureN[i].GetPoint(1).GetX() - coordinateStartX;
                    coordinateEndY = (int)figureN[i].GetPoint(1).GetY() - coordinateStartY;

                    args.Graphics.DrawRectangle(colorPenN[figureN[i].GetColor()], coordinateStartX, coordinateStartY, coordinateEndX , coordinateEndY);
                }
                else if (figureN[i] is Line && figureN[i].GetPoint(0) != null && figureN[i].GetPoint(1) != null)
                {

                    args.Graphics.DrawLine(colorPenN[figureN[i].GetColor()], (float)figureN[i].GetPoint(0).GetX(), (float)figureN[i].GetPoint(0).GetY(),
                        (float)figureN[i].GetPoint(1).GetX(), (float)figureN[i].GetPoint(1).GetY());
                }
                else if (figureN[i] is Circle && figureN[i].GetPoint(0) != null && figureN[i].GetPoint(1) != null)
                {
                    radius = (int)Math.Abs(figureN[i].GetPoint(1).GetX() - figureN[i].GetPoint(0).GetX());
                    coordinateStartX = (int)Math.Min(figureN[i].GetPoint(0).GetX(), figureN[i].GetPoint(1).GetX()) - radius;
                    coordinateStartY = (int)Math.Min(figureN[i].GetPoint(0).GetY(), figureN[i].GetPoint(1).GetY()) - radius;

                    args.Graphics.DrawEllipse(colorPenN[figureN[i].GetColor()], coordinateStartX, coordinateStartY, radius * 2, radius * 2);
                }


            }

            

                //args.Graphics.FillRectangle(Brushes.Red, refToVisual.GetSelectedCellCoordinateY() * rectangleHeight,
                //    refToVisual.GetSelectedCellCoordinateX() * rectangleWidth, rectangleWidth, rectangleHeight);        
        }





        private void ResizeCanvas(MouseEventArgs args)
        {
            ((HandledMouseEventArgs)args).Handled = true;

            if (args.Delta < 0)
            {
                
                scale += (args.Delta / 100.0f);

                if (scale < 0.02) scale = 0.02f;
                

                PaintArea.Invalidate();
                

            }
            else if (args.Delta > 0)
            {
                scale += (args.Delta / 100.0f);

                if (scale > 4)
                    scale = 4;

                PaintArea.Invalidate();
                
            }
        }


        private void MapMouseDown(MouseEventArgs args)
        {
            refToVisual.ProcessMouseDown(args.X, args.Y);
            PaintArea.Invalidate();
        }
        private void MapMouseUp(MouseEventArgs args) 
        {
            refToVisual.ProcessMouseUp(args.X, args.Y);
            PaintArea.Invalidate();
        }
        private void MapMouseMove(MouseEventArgs args)
        {
            refToVisual.ProcessMouseMove(args.X, args.Y);
            PaintArea.Invalidate();
        }

        private void MapClick(MouseEventArgs args) => refToVisual.ProcessClick(args.X, args.Y);

        private void MapDoubleClick(MouseEventArgs args) => refToVisual.ProcessDoubleClick(args.X, args.Y);


        public int GetCurrentColor() => indexOfCurrentColor;
        public void SetCurrentColor(int indexOfColor) => indexOfCurrentColor = indexOfColor;

        public int GetCurrentLineWidth() => width;
        public void SetCurrentLineWidth(int lineWidth) => width = lineWidth;
        

        public void BeginDraw()
        {
            throw new NotImplementedException();
        }

        public void EndDraw()
        {
            throw new NotImplementedException();
        }


    }
}
