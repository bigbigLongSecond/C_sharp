using eluosifangkuai.block;
using System.Runtime.Intrinsics.X86;
using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace eluosifangkuai
{
    public partial class Form1 : Form
    {
        int row = 20, col = 10;
        int width = 20;
        int[,] inderArrays;

       System.Windows.Forms.Timer timer;

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
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Enabled = true;
            timer.Tick += Update_timer;
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
                    DrawGraphies();
                }
            }else if(e.KeyCode == Keys.Left) {
                if (block1 != null)
                {
                    block1.Left(inderArrays);
                    DrawGraphies();
                }
            }
            else if(e.KeyCode == Keys.Right) {
                if (block1 != null)
                {
                    block1.Right(inderArrays);
                    DrawGraphies();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (block1 != null)
                {
                    block1.Rotate(inderArrays);
                    DrawGraphies();
                }
            }
        }


        /// <summary>
        /// 这个timer 要做什么事情？
        /// 1. 生成一个block --> 生成block的时机有两个。 第一个初始化时生成一个 。 第二个到达底部了的时候生成一个
        /// 2. 控制block的下落
        /// 3. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Update_timer(object? sender, EventArgs e)
        {
            // 生成一个block
            if(block1 == null)
            {
                block1 = new Block1(3, 4);
                block1.Draw(inderArrays);
                DrawGraphies();
            }
            else
            {
                if (block1.CanMove(EventType.Down, inderArrays))
                {
                    block1.Down(inderArrays);
                }
            }
            // 控制block的下落
            //if
            //block1.Down(inderArrays);

        }
    }

}