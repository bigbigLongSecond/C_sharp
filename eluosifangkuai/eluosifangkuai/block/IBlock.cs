using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eluosifangkuai.block
{
    public interface IBlock
    {

        public void Down(int[,] array);
        public void Right(int[,] array);

        public void Left(int[,] array);
        public void Rotate(int[,] array);
        public bool CanMove(EventType eventType, int[,] array);
        public void Draw(int[,] array);
    }
}
