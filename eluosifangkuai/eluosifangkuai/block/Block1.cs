﻿using System;
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
                Modfile(newSquares, array, 1);
            }
        }


        public override List<Square> getAllPoint(int x, int y, SharpType type)
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
