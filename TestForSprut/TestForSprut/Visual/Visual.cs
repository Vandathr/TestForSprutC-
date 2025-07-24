using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForSprut
{
    internal class Visual: Form
    {
        private readonly Model refToModel;

        private readonly MenuStrip StripOfToolz;

        private readonly TabControl ControlOfTabz = new TabControl();

        private readonly MapTab PanelsTab;

        private readonly Action<int, int>[] commandOfFirstStepN;
        private readonly Action<int, int>[] commandOfSecondStepN;
        private readonly Action<int, int>[] commandOfThirdStepN;

        private int condition;
        private int figureType;




        private Point refToStartPoint;


        private int selectedCellX;
        private int selectedCellY;

        private int pullingStep;
        private int recizingStep;
        private int drawingStep;


        public void Draw(MapPanel refToCanvas, PaintEventArgs args) => refToModel.Draw(refToCanvas, args);
        
        public void Refresh() => PanelsTab.Refresh();

        public void SendToMap(ICanvasCell Cell) => refToModel.SendToMap(Cell);



        public void SwitchToCondition(int index) => condition = index;

        public void SwitchFigureType(int index) => figureType = index;


        public void SetColor(int index)
        {
            if (condition == 2)
            {
                refToModel.SetCurrentColor(index);
            }
            else
            {
                if (PanelsTab != null)
                    PanelsTab.SetCurrentColor(index);
            }
              
        }

        public void SetWidth(int index)
        {
            if (condition == 2)
            {
                refToModel.SetCurrentWidth(index);
            }
            else
            {
                if (PanelsTab != null)
                    PanelsTab.SetCurrentLineWidth(index);
            }

        }



        public void DeleteFigure() => refToModel.DeleteFigure();

        public void ClearMap() => refToModel.ClearMap();


        public void ProcessMouseDown(int X, int Y)
        {
            selectedCellX = X;
            selectedCellY = Y;

            commandOfFirstStepN[condition](X, Y);

        }


        





        public void ProcessMouseUp(int X, int Y)
        {
            selectedCellX = X;
            selectedCellY = Y;

            commandOfThirdStepN[condition](X, Y);

        }


        public void ProcessMouseMove(int X, int Y)
        {
            commandOfSecondStepN[condition](X, Y);
        }




        public void ProcessClick(int X, int Y)
        {
            selectedCellX = X;
            selectedCellY = Y;

            commandOfFirstStepN[condition](X, Y);

        }

        public void ProcessDoubleClick(int X, int Y)
        {
            //throw new NotImplementedException("Ещё не сделано");
        }

        public int GetSelectedCellCoordinateX() => selectedCellX;


        public int GetSelectedCellCoordinateY() => selectedCellY;





        





        public Visual(Model refToModel)
        {
            this.refToModel = refToModel;

            Width = 1100;
            Height = 900;

            var defaultDistance = 20;





            StripOfToolz = new Menu(this);

            Controls.Add(StripOfToolz);


            ControlOfTabz.Location = new Point(0, StripOfToolz.Bottom);

            PanelsTab = new MapTab(this);

            PanelsTab.SetCurrentColor(2);
            PanelsTab.SetCurrentLineWidth(1);


            ControlOfTabz.TabPages.Add(PanelsTab);
            ControlOfTabz.Width = Width;
            ControlOfTabz.Height = Height;


            Controls.Add(ControlOfTabz);


            Resize += (sender, args) => ResizeWindow();


            commandOfFirstStepN = new Action<int, int>[]
            {
                (int X, int Y) => { },
                (int X, int Y) => DrawingFirstStep(X, Y),
                (int X, int Y) => SelectFigure(X, Y),
                (int X, int Y) => PullingFirstStep(X, Y),
                (int X, int Y) => ResizingFirstStep(X, Y)

            };

            commandOfSecondStepN = new Action<int, int>[]
            {
                (int X, int Y) => { },
                (int X, int Y) => DrawingSecondStep(X, Y),
                (int X, int Y) => { },
                (int X, int Y) => PullingSecondStep(X, Y),
                (int X, int Y) => ResizingSecondStep(X, Y)

            };

            commandOfThirdStepN = new Action<int, int>[]
            {
                (int X, int Y) => { },
                (int X, int Y) => DrawingThirdStep(X, Y),
                (int X, int Y) => { },
                (int X, int Y) => PullingThirdStep(X, Y),
                (int X, int Y) => ResizingThirdStep(X, Y)

            };

        }






        private void DrawingFirstStep(int X, int Y)
        {
            
            if (drawingStep == 0)
            {
                refToStartPoint = new Point(X, Y);

                drawingStep = 1;

                refToModel.MakeFigure(figureType, PanelsTab.GetCurrentColor(), PanelsTab.GetCurrentLineWidth());

            }
        }


        private void DrawingSecondStep(int X, int Y)
        {
            if (drawingStep == 1)
            {
                refToModel.FillActiveFigure(refToStartPoint, X, Y);
            }
        }


        private void DrawingThirdStep(int X, int Y)
        {
            if (drawingStep == 1)
            {
                drawingStep = 0;
            }
        }



        private void SelectFigure(int X, int Y) => refToModel.SelectFigure(X, Y);


        private void PullingFirstStep(int X, int Y)
        {          

            if (pullingStep == 0)
            {
                refToStartPoint = new Point(X, Y);

                pullingStep = 1;

                refToModel.SelectFigure(X, Y);

            }
        }

        private void PullingSecondStep(int X, int Y)
        {
            if (pullingStep == 1)
            {
                pullingStep = 1;

                refToModel.MoveSelectedFigure((X - refToStartPoint.X), (Y - refToStartPoint.Y));

                refToStartPoint = new Point(X, Y);
            }
        }


        private void PullingThirdStep(int X, int Y)
        {
            if (pullingStep == 1)
            {
                pullingStep = 0;
            }
        }



        private void ResizingFirstStep(int X, int Y)
        {
            refToStartPoint = new Point(X, Y);

            if (recizingStep == 0)
            {
                recizingStep = 1;


            }
        }

        private void ResizingSecondStep(int X, int Y)
        {
            if (recizingStep == 1)
                refToModel.ScaleActiveFigure(X, Y);
        }

        private void ResizingThirdStep(int X, int Y)
        {
            if (recizingStep == 1)
            {
                recizingStep = 0;
            }
        }


        private void ResizeWindow()
        {
            ControlOfTabz.Width = Width;
            ControlOfTabz.Height = Height;
        }



    }
}
