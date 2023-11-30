namespace eluosifangkuai
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel4 = new Panel();
            scoreLable = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 441);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(220, 441);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(234, 5);
            label1.Name = "label1";
            label1.Size = new Size(0, 17);
            label1.TabIndex = 1;
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(220, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(184, 37);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(9, 10);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 0;
            label2.Text = "分数";
            label2.Click += label2_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(button3);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(220, 225);
            panel3.Name = "panel3";
            panel3.Size = new Size(184, 216);
            panel3.TabIndex = 3;
            panel3.PreviewKeyDown += panel3_PreviewKeyDown;
            // 
            // button3
            // 
            button3.CausesValidation = false;
            button3.Location = new Point(46, 131);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.TabStop = false;
            button3.Text = "回  退";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.CausesValidation = false;
            button2.Location = new Point(46, 83);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.TabStop = false;
            button2.Text = "暂  停";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.CausesValidation = false;
            button1.Location = new Point(46, 32);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.TabStop = false;
            button1.Text = "开  始";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(scoreLable);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(220, 37);
            panel4.Name = "panel4";
            panel4.Size = new Size(184, 188);
            panel4.TabIndex = 4;
            // 
            // scoreLable
            // 
            scoreLable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scoreLable.AutoSize = true;
            scoreLable.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            scoreLable.Location = new Point(71, 77);
            scoreLable.Name = "scoreLable";
            scoreLable.Size = new Size(31, 35);
            scoreLable.TabIndex = 0;
            scoreLable.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 441);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private Panel panel4;
        private Button button1;
        private Label scoreLable;
        private Button button2;
        private Button button3;
    }
}