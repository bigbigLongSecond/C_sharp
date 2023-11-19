using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eluosifangkuai.block
{
    public abstract class Block
    {
         public int[,] data;
        public SharpType sharpType; 
        public int X { get; set; }

        public int Y { get; set; }

        public abstract void Down(int[,] array);
        public abstract void Right(int[,] array);

        public abstract void Left(int[,] array);
        public abstract void Rotate(int[,] array);
        public abstract void Draw(Graphics graphics);



    }

    enum EventType
    {
        Down,
        Left,
        Right,
        rotate
    }
   public enum SharpType
    {
        Up, Right, Down, Left 
    }
}
