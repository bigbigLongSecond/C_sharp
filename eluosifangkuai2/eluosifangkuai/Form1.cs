using eluosifangkuai.block;
using System.Runtime.Intrinsics.X86;

namespace eluosifangkuai
{
    public partial class Form1 : Form
    {
        int row = 20, col = 10;
        int width = 20;
        int[,] inderArrays;

        private Block1 block1;
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
            inderArrays = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (global::System.Int32 j = 0; j < col; j++)
                {
                    inderArrays[i, j] = 0;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);

            g = Graphics.FromImage(bitmap);
            DrawGraphies();
            this.pictureBox1.BackgroundImage = bitmap;
        }

        private void DrawGraphies()
        {

            Brush green = new SolidBrush(Color.Green);
            Brush red = new SolidBrush(Color.Red);
            for (int i = 0; i < row; i++)
            {
                for (global::System.Int32 j = 0; j < col; j++)
                {
                    if (inderArrays[i, j] == 0)
                    {
                        Draw(i, j, green);
                    }
                    else
                    {
                        Draw(i, j, red);

                    }
                }
            }

            this.pictureBox1.Refresh();
        }

        private void Draw(int i, int j, Brush color)
        {

            if (g != null)
                g.FillRectangle(color, j * width, i * width, width - 1, width - 1);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down){ 
                if (block1 != null)
                {
                    block1.Down(inderArrays);
                }
                else
                {
                    block1 = new Block1(3, 4);
                }
                DrawGraphies();
            }else if(e.KeyCode == Keys.Left) {
                if (block1 != null)
                {
                    block1.Left(inderArrays);
                }
                else
                {
                    block1 = new Block1(3, 4);
                }
                DrawGraphies();
            }
            else if(e.KeyCode == Keys.Right) {
                if (block1 != null)
                {
                    block1.Right(inderArrays);
                }
                else
                {
                    block1 = new Block1(3, 4);
                }
                DrawGraphies();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (block1 != null)
                {
                    block1.Rotate(inderArrays);
                }
                else
                {
                    block1 = new Block1(3, 4);
                }
                DrawGraphies();
            }
        }
    }
}