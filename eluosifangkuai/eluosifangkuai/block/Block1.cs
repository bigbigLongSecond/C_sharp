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
        }
        public override void Down(int[,] array)
        {


            Modfile(X, Y, array, 0);
            X = X + 1;
            Modfile( X, Y, array, 1);



        }

        private void Modfile( int x, int y, int[,] array, int v)
        {
            switch (sharpType)
            {
                case SharpType.Up:
                    array[x, y] = v;
                    array[x, y - 1] = v;
                    array[x, y + 1] = v;
                    array[x - 1, y] = v;
                    break;
                case SharpType.Right:
                    array[x, y] = v;
                    array[x-1, y ] = v;
                    array[x+1, y ] = v;
                    array[x, y+1] = v;
                    break;
                case SharpType.Down:
                    array[x, y] = v;
                    array[x, y - 1] = v;
                    array[x, y + 1] = v;
                    array[x + 1, y] = v;
                    break;
                case SharpType.Left:
                    array[x, y] = v;
                    array[x - 1, y] = v;
                    array[x + 1, y] = v;
                    array[x, y - 1] = v;
                    break;
            }

        }

        public override void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public override void Left(int[,] array)
        {

            Modfile(X, Y, array, 0);
            Y = Y - 1;
            Modfile(X, Y, array, 1);
        }

        public override void Right(int[,] array)
        {

            Modfile(X, Y, array, 0);
            Y = Y + 1;
            Modfile(X, Y, array, 1);
        }

        public override void Rotate(int[,] array)
        {


            Modfile(X, Y, array, 0);
            int index = (int)sharpType;
            if (index + 1 ==4)
            {
                index = 0;
            }else
            {
                index++;
            }
            sharpType = (SharpType)index;
            Modfile(X, Y, array, 1);

        }
    }

}
