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

        private IBlock Iblock;
        private Graphics g;
        private int Score;
        /**
         * 0: 未开始
         * 1：开始
         * 2：暂停
         */
        private int GameStatus = 0;
        public Form1()
        {
            InitializeComponent();
            inderArrays = new int[row, col];
            initIndexArray();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Enabled = true;
            timer.Tick += Update_timer;
            // 注册 PreviewKeyDown 事件处理程序
            this.PreviewKeyDown += MainForm_PreviewKeyDown;

            // 禁用默认的焦点导航
            //this.KeyPreview = true;
            //this.KeyDown += MainForm_KeyDown;
        }

        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // 按下上下左右箭头键时，阻止焦点导航
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // 按下上下左右箭头键时，禁用焦点导航
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.Handled = true;

                // 将焦点设置到当前活动控件
                ActiveControl = (Control)sender;
            }
        }

        private void initIndexArray()
        {
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

            if (GameStatus == 1)
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (Iblock != null && Iblock.CanMove(EventType.Down, inderArrays))
                    {
                        Iblock.Down(inderArrays);
                        DrawGraphies();
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    if (Iblock != null && Iblock.CanMove(EventType.Left, inderArrays))
                    {
                        Iblock.Left(inderArrays);
                        DrawGraphies();
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (Iblock != null && Iblock.CanMove(EventType.Right, inderArrays))
                    {
                        Iblock.Right(inderArrays);
                        DrawGraphies();
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (Iblock != null)
                    {
                        Iblock.Rotate(inderArrays);
                        DrawGraphies();
                    }
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
            if (Iblock == null)
            {
                if (GameStatus != 0)
                {
                    Iblock = GetNewBlock();
                    Iblock.Draw(inderArrays);
                    DrawGraphies();
                }
            }
            else
            {
                if (Iblock.CanMove(EventType.Down, inderArrays))
                {
                    Iblock.Down(inderArrays);
                    DrawGraphies();
                }
                else
                {
                    CalculateScore();
                    Iblock = GetNewBlock();
                    Iblock.Draw(inderArrays);
                }
            }
            // 控制block的下落
            //if
            //Iblock.Down(inderArrays);

        }

        private IBlock? GetNewBlock()
        {
            IBlock block = null;
            Random random = new Random();
            // 生成介于 0 到 6 之间的随机数
            int randomNumber = random.Next(0, 7);
            switch (randomNumber)
            {
                case 0:
                    block = new Block1(0, 4);
                    break;
                case 1:
                    block = new Block2(0, 4);
                    break;
                case 2:
                    block = new Block3(0, 4);
                    break;
                case 3:
                    block = new Block4(0, 4);
                    break;
                case 4:
                    block = new Block5(0, 4);
                    break;
                case 5:
                    block = new Block6(0, 4);
                    break;
                case 6:
                    block = new Block7(0, 4);
                    break;
            }

            return block;
        }

        private void CalculateScore()
        {

            for (int i = 0; i < row; i++)
            {
                bool flag = true;
                for (int j = 0; j < col; j++)
                {
                    if (inderArrays[i, j] == 0)
                    {
                        flag = false;
                        break;
                    }

                }
                if (flag)
                {
                    Score++;
                    scoreLable.Text = Score.ToString();
                    for (int row1 = i; row1 >= 0; row1--)
                    {
                        for (int j = 0; j < col; j++)
                        {
                            if (row1 == 0)
                            {
                                inderArrays[row1, j] = 0;
                            }
                            else if (row1 - 1 > 0)
                            {
                                inderArrays[row1, j] = inderArrays[row1 - 1, j];
                            }
                        }
                    }
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Iblock = null;
            Score = 0;
            scoreLable.Text = Score.ToString();
            initIndexArray();
            DrawGraphies();
            GameStatus = 1;
            timer.Start();

            this.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GameStatus == 1)
            {
                timer.Stop();
            }
            else if (GameStatus == 2)
            {
                timer.Start();
            }
            this.Focus();

        }

        private void panel3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (GameStatus == 1)
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (Iblock != null && Iblock.CanMove(EventType.Down, inderArrays))
                    {
                        Iblock.Down(inderArrays);
                        DrawGraphies();
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    if (Iblock != null && Iblock.CanMove(EventType.Left, inderArrays))
                    {
                        Iblock.Left(inderArrays);
                        DrawGraphies();
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (Iblock != null && Iblock.CanMove(EventType.Right, inderArrays))
                    {
                        Iblock.Right(inderArrays);
                        DrawGraphies();
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (Iblock != null)
                    {
                        Iblock.Rotate(inderArrays);
                        DrawGraphies();
                    }
                }
            }
        }
    }

}