using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sierpinski_triangle
{
    public partial class FormMain : Form
    {
        int n = 1000;
        float x;
        float y;
        float width = 10;
        float height = 10;
        float WidthScreen = SystemInformation.VirtualScreen.Width;//Ширина экрана
        float HeightScreen = SystemInformation.VirtualScreen.Height;//Высота экрана
        SolidBrush mySolidBrush = new SolidBrush(Color.Red);

        public FormMain()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics A = CreateGraphics();
            Graphics B = CreateGraphics();
            Graphics C = CreateGraphics();
            Graphics RndPoint = CreateGraphics();
            float xA = WidthScreen / 2 - width / 2;
            float yA = 20 - height / 2;
            float xB = xA - (HeightScreen - 100) / (float)(Math.Sqrt(3));
            float yB = HeightScreen - 100 + 20 - height / 2;
            float xC = xA + (HeightScreen - 100) / (float)(Math.Sqrt(3));
            float yC = yB;
            //рисует вершины равностороннего треугольника
            A.FillEllipse(mySolidBrush, xA, yA, width, height);
            B.FillEllipse(mySolidBrush, xB, yB, width, height);
            C.FillEllipse(mySolidBrush, xC, yC, width, height);
            //--
            mySolidBrush.Color = Color.Black;
            x = xA;
            y = yA + 1;
            RndPoint.FillEllipse(mySolidBrush, x, y, width, height);
            Random rndValue = new Random();
            int rnd;
            for (int i = 0; i < n; i++)
            {
                //Thread.Sleep(500);
                switch (rnd = rndValue.Next(-1, 3))
                {
                    case 0:
                        RndPoint.FillEllipse(mySolidBrush, x = (x + xA) / 2, y = (y + yA) / 2, width, height);
                        break;
                    case 1:
                        RndPoint.FillEllipse(mySolidBrush, x = (x + xB) / 2, y = (y + yB) / 2, width, height);
                        break;
                    case 2:
                        RndPoint.FillEllipse(mySolidBrush, x = (x + xC) / 2, y = (y + yC) / 2, width, height);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
