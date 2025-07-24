using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForSprut
{
    internal class Menu: MenuStrip
    {

        public Menu(Visual refToVisual)
        {

            var FileDropDown = new ToolStripMenuItem("File");



            //var SaveAsButton = new ToolStripMenuItem();
            //SaveAsButton.Text = "Save as...";
            //SaveAsButton.Click += (sender, args) => refToVisual.SaveFilez();

            //FileDropDown.DropDownItems.Add(SaveAsButton);

            //var LoadButton = new ToolStripMenuItem();
            //LoadButton.Text = "Load";
            //LoadButton.Click += (sender, args) => refToVisual.LoadFilez();

            //FileDropDown.DropDownItems.Add(LoadButton);


            Items.Add(FileDropDown);


        }

    }
}
