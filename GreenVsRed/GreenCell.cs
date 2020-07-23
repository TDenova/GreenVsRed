using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenVsRed
{
    class GreenCell : Cell
    {
        public int CellValue { get; private set; }


        public GreenCell(int positionX, int positionY, int cellValue)
            :base(positionX ,positionY)
        {
            CellValue = cellValue;
        }
        public GreenCell(int positionX, int positionY, int cellValue, int sum)
            : base(positionX, positionY, sum)
        {
            CellValue = cellValue;
        }

        public override int GetCellType()
        {
            return 1; 
        }
        public override int GetValue()
        {
            return CellValue;
        }
        //Method check next value of the cell.
        public override int CheckNextValue(int sum)
        {
            int nextValue = 0;
            if (sum == 2 || sum == 3 || sum == 6)
            {
                nextValue = 1;
            }
            else
            {
                nextValue = 0;
            }
            return nextValue;
        }
    }
}
