using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenVsRed
{
    class RedCell : Cell
    {

        public int CellValue { get; set; }
        
        

        public RedCell(int positionX, int positionY, int cellValue)
            :base(positionX, positionY)
        {
            CellValue = cellValue;
        }
        public RedCell(int positionX, int positionY, int cellValue, int sum)
            : base(positionX, positionY, sum)
        {
            CellValue = cellValue;
        }

        public override int GetCellType()
        {
            return 0;
        }

        public override int GetValue()
        {
            return CellValue;
        }
        public override int CheckNextValue(int sum)
        {
            int nextValue = 0;
            if (sum == 3 || sum == 6)
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
