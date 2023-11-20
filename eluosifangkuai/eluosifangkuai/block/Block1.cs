using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eluosifangkuai.block
{
    public class Block1 : Block
    {
        public Block1(int x, int y)
        {
            X = x;
            Y = y;
            sharpType = SharpType.Up;

        }
        public override void Down(int[,] array)
        {
            if (CanMove(EventType.Down, array))
            {
                Modfile(X + 1, Y, array);
            }
        }

        private void Modfile(int x, int y, int[,] array)
        {
            List<Square> oldSquares = getAllPoint(X, Y, sharpType);
            Modfile(oldSquares, array, 0);
            List<Square> newSquares = getAllPoint(x, y, sharpType);
            Modfile(newSquares, array, 1);
            X = x;
            Y = y;
        }

        private void Modfile(List<Square> squares, int[,] array, int v)
        {
            if (squares != null && squares.Count > 0)
            {
                foreach (Square square in squares)
                {
                    array[square.XPoint, square.YPoint] = v;
                }
            }

        }


        public override void Draw(int[,] array)
        {
            List<Square> newSquares = getAllPoint(X, Y, sharpType);
            Modfile(newSquares, array, 1);
        }

        public override void Left(int[,] array)
        {
            if (CanMove(EventType.Left, array))
            {
                Modfile(X, Y - 1, array);
            }
        }

        public override void Right(int[,] array)
        {
            if (CanMove(EventType.Right, array))
            {
                Modfile(X, Y + 1, array);
            }
        }

        public override void Rotate(int[,] array)
        {
            int index = (int)sharpType;
            if (index + 1 == 4)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            SharpType type = (SharpType)index;

            if (CanMove(X, Y, array, type))
            {

                List<Square> squares = getAllPoint(X, Y, sharpType);

                Modfile(squares, array, 0);
                sharpType = type;
                List<Square> newSquares = getAllPoint(X, Y, type);
                Modfile(newSquares, array, 0);
            }



        }


        public override bool CanMove(EventType eventType, int[,] array)
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



        private bool CanMove(int x, int y, int[,] array, SharpType type)
        {
            bool flag = true;

            List<Square> squares = findNewPoint(x, y, type);
            foreach (var square in squares)
            {
                if ((square.XPoint >= 0 && square.XPoint < 20) && (square.YPoint >= 0 && square.YPoint < 10)
                  && array[square.XPoint, square.YPoint] == 0
                  )
                {
                    flag = true;
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

        private List<Square> getAllPoint(int x, int y, SharpType type)
        {
            List<Square> squareList = new List<Square>();

            switch (type)
            {
                case SharpType.Up:
                    squareList.Add(new Square().setValue(x, y));
                    squareList.Add(new Square().setValue(x, y - 1));
                    squareList.Add(new Square().setValue(x, y + 1));
                    squareList.Add(new Square().setValue(x - 1, y));
                    break;
                case SharpType.Right:

                    squareList.Add(new Square().setValue(x, y));
                    squareList.Add(new Square().setValue(x - 1, y));
                    squareList.Add(new Square().setValue(x + 1, y));
                    squareList.Add(new Square().setValue(x, y + 1));

                    break;
                case SharpType.Down:

                    squareList.Add(new Square().setValue(x, y));
                    squareList.Add(new Square().setValue(x, y - 1));
                    squareList.Add(new Square().setValue(x, y + 1));
                    squareList.Add(new Square().setValue(x + 1, y));

                    break;
                case SharpType.Left:

                    squareList.Add(new Square().setValue(x, y));
                    squareList.Add(new Square().setValue(x - 1, y));
                    squareList.Add(new Square().setValue(x + 1, y));
                    squareList.Add(new Square().setValue(x, y - 1));

                    break;
            }
            return squareList;
        }
    }

}
