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

        protected Square square1;
        protected Square square2;
        protected Square square3;
        protected Square square4;

        public SharpType sharpType; 
        public int row  = 20 , col = 10 ;
        public int X { get; set; }

        public int Y { get; set; }

        public abstract void Down(int[,] array);
        public abstract void Right(int[,] array);

        public abstract void Left(int[,] array);
        public abstract void Rotate(int[,] array);
        public abstract bool CanMove(EventType eventType ,  int[,] array);
        public abstract void Draw(int[,] array);



    }

  public   enum EventType
    {
        Down,
        Left,
        Right,
        Rotate
    }
   public enum SharpType
    {
        Up, Right, Down, Left 
    }

    public struct Square
    {
        public int XPoint { get; set; }
        public int YPoint { get; set; }

        public Square setValue(int x, int y)
        {
            XPoint = x;
            YPoint = y;
            return this;
        }

        public bool equals(Square other)
        {
            if(other.XPoint == this.XPoint &&  other.YPoint == this.YPoint)
            {
                return true;
            }
            return false;
        }
    }
}
