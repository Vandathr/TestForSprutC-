using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Net.Http.Headers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TestForSprut
{
    internal class ComandzPanel: Panel
    {
        private readonly Visual refToVisual;

        private readonly System.Windows.Forms.RadioButton SelectConditionButton = new System.Windows.Forms.RadioButton();
        private readonly System.Windows.Forms.RadioButton MoveConditionButton = new System.Windows.Forms.RadioButton();
        private readonly System.Windows.Forms.RadioButton ScaleConditionButton = new System.Windows.Forms.RadioButton();
        private readonly System.Windows.Forms.RadioButton LineConditionButton = new System.Windows.Forms.RadioButton();
        private readonly System.Windows.Forms.RadioButton RectangleConditionButton = new System.Windows.Forms.RadioButton();
        private readonly System.Windows.Forms.RadioButton CircleConditionButton = new System.Windows.Forms.RadioButton();
        private readonly Button DeleteFigureButton = new Button();
        private readonly Button ClearMapButton = new Button();

        private readonly ComboBox ColorSwitcher = new ComboBox();
        private readonly ComboBox WidthSwitcher = new ComboBox();

        private readonly System.Windows.Forms.Label Description = new System.Windows.Forms.Label();



        public ComandzPanel(Visual refToVisual, int locationX, int locationY, int sizeX, int sizeY)
        {
            this.refToVisual = refToVisual;

            AutoScroll = true;

            Location = new Point(locationX, locationY);
            Size = new Size(sizeX, sizeY);

            Text = "Comandz";

            BorderStyle = BorderStyle.Fixed3D;

            var StandardSize = new Size(100, 25);

            var defaultDistance = 10;

            SelectConditionButton.Location = new Point(defaultDistance, defaultDistance);
            SelectConditionButton.Size = StandardSize;
            SelectConditionButton.Text = "Select";

            SelectConditionButton.Appearance = Appearance.Button;

            SelectConditionButton.Click += (sender, args) => refToVisual.SwitchToCondition(2);

            Controls.Add(SelectConditionButton);


            MoveConditionButton.Location = new Point(defaultDistance, SelectConditionButton.Bottom + defaultDistance);
            MoveConditionButton.Size = StandardSize;
            MoveConditionButton.Text = "Move";

            MoveConditionButton.Appearance = Appearance.Button;

            MoveConditionButton.Click += (sender, args) => refToVisual.SwitchToCondition(3);

            Controls.Add(MoveConditionButton);



            ScaleConditionButton.Location = new Point(defaultDistance, MoveConditionButton.Bottom + defaultDistance);
            ScaleConditionButton.Size = StandardSize;
            ScaleConditionButton.Text = "Scale";

            ScaleConditionButton.Appearance = Appearance.Button;

            ScaleConditionButton.Click += (sender, args) => refToVisual.SwitchToCondition(4);

            Controls.Add(ScaleConditionButton);

            LineConditionButton.Location = new Point(defaultDistance, ScaleConditionButton.Bottom + defaultDistance);
            LineConditionButton.Size = StandardSize;
            LineConditionButton.Text = "Line";

            LineConditionButton.Appearance = Appearance.Button;

            LineConditionButton.Click += (sender, args) =>
                {
                    refToVisual.SwitchToCondition(1);
                    refToVisual.SwitchFigureType(1);
                };
            

            Controls.Add(LineConditionButton);


            RectangleConditionButton.Location = new Point(defaultDistance, LineConditionButton.Bottom + defaultDistance);
            RectangleConditionButton.Size = StandardSize;
            RectangleConditionButton.Text = "Rectangle";

            RectangleConditionButton.Appearance = Appearance.Button;

            RectangleConditionButton.Click += (sender, args) =>
                {
                    refToVisual.SwitchToCondition(1);
                    refToVisual.SwitchFigureType(2);
                };

            Controls.Add(RectangleConditionButton);



            CircleConditionButton.Location = new Point(defaultDistance, RectangleConditionButton.Bottom + defaultDistance);
            CircleConditionButton.Size = StandardSize;
            CircleConditionButton.Text = "Cricle";

            CircleConditionButton.Appearance = Appearance.Button;

            CircleConditionButton.Click += (sender, args) =>
            {
                refToVisual.SwitchToCondition(1);
                refToVisual.SwitchFigureType(3);
            };

            Controls.Add(CircleConditionButton);


            DeleteFigureButton.Location = new Point(defaultDistance, CircleConditionButton.Bottom + defaultDistance);
            DeleteFigureButton.Size = StandardSize;
            DeleteFigureButton.Text = "Delete figure";

            DeleteFigureButton.Click += (sender, args) =>
            {
                refToVisual.DeleteFigure();
                refToVisual.Refresh();
            };

            Controls.Add(DeleteFigureButton);



            ClearMapButton.Location = new Point(defaultDistance, DeleteFigureButton.Bottom + defaultDistance);
            ClearMapButton.Size = StandardSize;
            ClearMapButton.Text = "Clear map";

            ClearMapButton.Click += (sender, args) =>
            {
                refToVisual.ClearMap();
                refToVisual.Refresh();
            };

            Controls.Add(ClearMapButton);





            ColorSwitcher.Location = new Point(defaultDistance, ClearMapButton.Bottom + defaultDistance);
            ColorSwitcher.Size = StandardSize;



            ColorSwitcher.Items.Add("empty");
            ColorSwitcher.Items.Add("Gray");
            ColorSwitcher.Items.Add("Red");
            ColorSwitcher.Items.Add("Blue");
            ColorSwitcher.Items.Add("Yellow");
            ColorSwitcher.Items.Add("Green");

            ColorSwitcher.SelectedIndex = 2;
            refToVisual.SetColor(ColorSwitcher.SelectedIndex);

            ColorSwitcher.SelectedIndexChanged += (sender, args) => 
            { 
                refToVisual.SetColor(ColorSwitcher.SelectedIndex);
                refToVisual.Refresh();
            };

            Controls.Add(ColorSwitcher);



            WidthSwitcher.Location = new Point(defaultDistance, ColorSwitcher.Bottom + defaultDistance);
            WidthSwitcher.Size = StandardSize;



            WidthSwitcher.Items.Add("1");
            WidthSwitcher.Items.Add("2");
            WidthSwitcher.Items.Add("3");
            WidthSwitcher.Items.Add("4");
            WidthSwitcher.Items.Add("5");

            WidthSwitcher.SelectedIndex = 1;
            refToVisual.SetWidth(WidthSwitcher.SelectedIndex);

            WidthSwitcher.SelectedIndexChanged += (sender, args) =>
            {
                refToVisual.SetWidth(WidthSwitcher.SelectedIndex);
                refToVisual.Refresh();
            };

            Controls.Add(WidthSwitcher);




            Description.Location = new Point(defaultDistance, WidthSwitcher.Bottom + defaultDistance);
            Description.Size = new Size(150, 200);
            Description.Text = "Нажмите на кнопку Line, Rectangle или Circle а затем по двум произвольным точкам на холсте. По этим точкам будет построена фигура";
            Description.BorderStyle = BorderStyle.Fixed3D;

            Controls.Add(Description);



        }





    }
}
