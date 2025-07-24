using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForSprut
{
    internal class Model
    {
        private readonly Map mapN = new Map();


        public void SetCurrentColor(int indexOfColor) => mapN.SetCurrentColor(indexOfColor);
        public void SetCurrentWidth(int width) => mapN.SetCurrentWidth(width);
        public void Draw(MapPanel refToCanvas, PaintEventArgs args) => mapN.Draw(refToCanvas, args);
        public void MakeFigure(int indexOfCommand, int color, int width) => mapN.MakeFigure(indexOfCommand, color, width);
        public void FillActiveFigure(Point startPoint, int endX, int endY) => mapN.FillActiveFigure(startPoint, endX, endY);
        public void ScaleActiveFigure(int endX, int endY) => mapN.ScaleActiveFigure(endX, endY);
        public void SelectFigure(int X, int Y) => mapN.SelectFigure(X, Y);
        public void DeleteFigure() => mapN.DeleteFigure();
        public void ClearMap() => mapN.ClearMap();
        public void SendToMap(ICanvasCell Cell) => mapN.SendToMap(Cell);
        public void MoveSelectedFigure(int X, int Y) => mapN.MoveSelectedFigure(X, Y);
        


    }
}
