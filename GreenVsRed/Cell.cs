using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenVsRed
{
    abstract class Cell
    {
        // Cordinates of cell
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int SumOfNeighbours { get; set; }

        public Cell(int positionX, int positionY)
            
        {
            PositionX = positionX;
            PositionY = positionY;
        }
        public Cell(int positionX, int positionY, int sum)
            :this(positionX, positionY)
        {
            SumOfNeighbours = sum;
        }

        public abstract int GetCellType();
        public abstract int GetValue();

        public int[] GetCellPosition()
        {
            int[] position = new int[2];
            position[0] = PositionX;
            position[1] = PositionY;
            return position;
        }
        
        public abstract int CheckNextValue(int sum);

        
        
    }
}
