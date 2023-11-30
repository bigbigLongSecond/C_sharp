using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eluosifangkuai.block
{
    public abstract class Block : IBlock
    {
        public SharpType sharpType;
        public int row = 20, col = 10;
        public int X { get; set; }

        public int Y { get; set; }

        public abstract void Rotate(int[,] array);
        public abstract List<Square> getAllPoint(int x, int y, SharpType type);


        public  void Down(int[,] array)
        {
            if (CanMove(EventType.Down, array))
            {
                Modfile(X + 1, Y, array);
            }
        }

        public  void Left(int[,] array)
        {
            if (CanMove(EventType.Left, array))
            {
                Modfile(X, Y - 1, array);
            }
        }

        public  void Right(int[,] array)
        {

            if (CanMove(EventType.Right, array))
            {
                Modfile(X, Y + 1, array);
            }
        }

        public  bool CanMove(EventType eventType, int[,] array)
        {
            bool flag = false;
            switch (eventType)
            {
                case EventType.Down:
                    flag = CanMove(X + 1, Y, array, sharpType);
                    break;
                case EventType.Right:
                    flag = CanMove(X, Y + 1, array, sharpType);
                    break;
                case EventType.Left:
                    flag = CanMove(X, Y - 1, array, sharpType);
                    break;
            }

            return flag;
        }

        public  void Draw(int[,] array)
        {
            List<Square> newSquares = getAllPoint(X, Y, sharpType);
            Modfile(newSquares, array, 1);
        }



        public bool CanMove(int x, int y, int[,] array, SharpType type)
        {
            bool flag = true;

            List<Square> squares = findNewPoint(x, y, type);
            foreach (var square in squares)
            {
                if ((square.XPoint >= -3 && square.XPoint < 20) && (square.YPoint >= 0 && square.YPoint < 10))
                {
                    if (square.XPoint >= 0)
                    {
                        if (array[square.XPoint, square.YPoint] == 0)
                        {
                            flag = true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return flag;
        }

        private List<Square> findNewPoint(int x, int y, SharpType type)
        {
            List<Square> squareList = new List<Square>();

            // 获取到坐标
            List<Square> newPoints = getAllPoint(x, y, type);
            List<Square> oldPoint = getAllPoint(X, Y, sharpType);

            foreach (var item in newPoints)
            {
                bool flag = true;
                foreach (var item1 in oldPoint)
                {
                    if (item.equals(item1))
                    {
                        flag = false;

                    }

                }
                if (flag)
                {
                    squareList.Add(item);
                }

            }
            return squareList;
        }


        public void Modfile(int x, int y, int[,] array)
        {
            List<Square> oldSquares = getAllPoint(X, Y, sharpType);
            Modfile(oldSquares, array, 0);
            List<Square> newSquares = getAllPoint(x, y, sharpType);
            Modfile(newSquares, array, 1);
            X = x;
            Y = y;
        }



        public void Modfile(List<Square> squares, int[,] array, int v)
        {
            if (squares != null && squares.Count > 0)
            {
                foreach (Square square in squares)
                {
                    if (square.XPoint >= 0)
                    {
                        array[square.XPoint, square.YPoint] = v;
                    }
                }
            }

        }

    }



    public enum EventType
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

    /// <summary>
    /// 方块的类型
    /// </summary>
    public enum BlockType
    {
        
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
            if (other.XPoint == this.XPoint && other.YPoint == this.YPoint)
            {
                return true;
            }
            return false;
        }
    }
}
