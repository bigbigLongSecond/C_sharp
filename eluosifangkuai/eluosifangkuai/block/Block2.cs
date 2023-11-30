using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eluosifangkuai.block
{
    /**
     * 
     *  田字格
     */
    public class Block2 : Block
    {
        public Block2(int x, int y)
        {
            X = x;
            Y = y;
            sharpType = SharpType.Up;
        }


        public override void Rotate(int[,] array)
        {
            
        }
        public override List<Square> getAllPoint(int x, int y, SharpType type)
        {
            List<Square> squareList = new List<Square>();

            switch (type)
            {
                case SharpType.Up:
                    squareList.Add(new Square().setValue(x, y));
                    squareList.Add(new Square().setValue(x, y + 1));
                    squareList.Add(new Square().setValue(x-1, y ));
                    squareList.Add(new Square().setValue(x - 1, y+1));
                    break;
                case SharpType.Right:
                    squareList.Add(new Square().setValue(x, y));
                    squareList.Add(new Square().setValue(x, y + 1));
                    squareList.Add(new Square().setValue(x - 1, y));
                    squareList.Add(new Square().setValue(x - 1, y + 1));

                    break;
                case SharpType.Down:
                    squareList.Add(new Square().setValue(x, y));
                    squareList.Add(new Square().setValue(x, y + 1));
                    squareList.Add(new Square().setValue(x - 1, y));
                    squareList.Add(new Square().setValue(x - 1, y + 1));

                    break;
                case SharpType.Left:
                    squareList.Add(new Square().setValue(x, y));
                    squareList.Add(new Square().setValue(x, y + 1));
                    squareList.Add(new Square().setValue(x - 1, y));
                    squareList.Add(new Square().setValue(x - 1, y + 1));
                    break;
            }
            return squareList;
        }
    }
}
