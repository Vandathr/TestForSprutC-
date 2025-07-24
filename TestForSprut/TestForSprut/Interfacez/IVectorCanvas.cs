using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForSprut
{
    internal interface IVectorCanvas
    {
        void SetCurrentColor(int indexOfColor);
        void SetCurrentLineWidth(int lineWidth);
        void BeginDraw();
        void EndDraw();
        void AddVertex(ICanvasCell Cell);
        void AddFigure(IFigure ToAdd);

    }
}
