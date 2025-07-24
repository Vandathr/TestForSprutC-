using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Reflection;

namespace TestForSprut
{
    internal class MapTab: TabPage
    {

        private readonly ComandzPanel PanelOfComandz;
        private readonly MapPanel PaintPanel;


        public void RefreshTab() => PaintPanel.RefreshCanvas();

        public int GetCurrentColor() => PaintPanel.GetCurrentColor();
        public void SetCurrentColor(int index) => PaintPanel.SetCurrentColor(index);

        public int GetCurrentLineWidth() => PaintPanel.GetCurrentLineWidth();
        public void SetCurrentLineWidth(int index) => PaintPanel.SetCurrentLineWidth(index);

        public void ClearMap() => PaintPanel.ClearMap();



        public MapTab(Visual refToVisual)
        {

            Text = "Main tab";

            var defaultDistance = 5;



            PanelOfComandz = new ComandzPanel(refToVisual, defaultDistance, defaultDistance, 200, 800);

            Controls.Add(PanelOfComandz);

            PaintPanel = new MapPanel(refToVisual, PanelOfComandz.Right + defaultDistance, PanelOfComandz.Top, Width - 500, Height - 80);

            PaintPanel.SetMapSize(4000, 4000);



            this.SizeChanged += (sender, args) => ResizeWindow();

            Controls.Add(PaintPanel);
        }



        private void ResizeWindow()
        {
            PaintPanel.Height = Height - 80;
            PaintPanel.Width = Width - 500;


        }

    }
}
