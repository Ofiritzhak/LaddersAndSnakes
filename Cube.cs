using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaddersAndSnakes.UI
{
    internal class Cube
    {
        public int Number { get; set; }

        //Roll the cube and type the number in the textbox
        public static int Roll(TextBox textBox)
        {
            Random random = new Random();
            int cubeNum = random.Next(1, 7);

            switch (cubeNum)
            {
                case 1:
                    textBox.Text = "1";
                    break;
                case 2:
                    textBox.Text = "2";
                    break;
                case 3:
                    textBox.Text = "3";
                    break;
                case 4:
                    textBox.Text = "4";
                    break;
                case 5:
                    textBox.Text = "5";
                    break;
                case 6:
                    textBox.Text = "6";
                    break;
            }
            return cubeNum;
        }
    }
}
