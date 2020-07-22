using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenVsRed
{
    class Grid
    {
        public int Width { get; set; }
        public int Hеight { get; set; }
        
        public Cell[,] Cells { get; set; }
        public Cell TargetCell { get; set; }

        public Grid(int width, int hеight, Cell[,] cells, Cell targetCell)
        {
            Width = width;
            Hеight = hеight;
            Cells = cells;
            TargetCell = targetCell;
        }
        
        public int CheckNeighboursSum(Cell cell, Cell[,] cells)
        {
            int sumOfNeighbours = 0;
            List<Cell> neighbours = new List<Cell>();
            neighbours = FindNeighbours(cell, cells);

            for (int i = 0; i < neighbours.Count(); i++)
            {
                int value = neighbours[i].GetValue();
                sumOfNeighbours += value;
            }

            return sumOfNeighbours;
        }
        // Go through different cases of neighbours and store them in a list.
        public List<Cell> FindNeighbours(Cell centralCell, Cell[,] cells)
        {
            int coordinateX = centralCell.PositionX;
            int coordinateY = centralCell.PositionY;

            List<Cell> neighbours = new List<Cell>();
            //central cell
            if ((coordinateX > 0 && coordinateY > 0) && (coordinateX < Width - 1 && coordinateY < Hеight - 1))
            {
                neighbours.Add(cells[coordinateX - 1, coordinateY - 1]);
                neighbours.Add(cells[coordinateX, coordinateY - 1]);
                neighbours.Add(cells[coordinateX + 1, coordinateY - 1]);
                neighbours.Add(cells[coordinateX - 1, coordinateY]);
                neighbours.Add(cells[coordinateX + 1, coordinateY]);
                neighbours.Add(cells[coordinateX - 1, coordinateY + 1]);
                neighbours.Add(cells[coordinateX, coordinateY + 1]);
                neighbours.Add(cells[coordinateX + 1, coordinateY + 1]);
            }
            else 
            {
                //corner cell
                if ((coordinateX == 0 && coordinateY == 0) || (coordinateX == (Width - 1) && coordinateY == (Hеight - 1)) || (coordinateX == (Width - 1) && coordinateY == 0) || (coordinateX == 0 && coordinateY == (Hеight - 1)))
                {
                    if (coordinateX == 0 && coordinateY == 0)
                    {
                        neighbours.Add(cells[coordinateX + 1, coordinateY]);
                        neighbours.Add(cells[coordinateX + 1, coordinateY + 1]);
                        neighbours.Add(cells[coordinateX, coordinateY + 1]);
                    }
                    else if (coordinateX == Width-1 && coordinateY == 0)
                    {
                        neighbours.Add(cells[coordinateX - 1, coordinateY]);
                        neighbours.Add(cells[coordinateX - 1, coordinateY + 1]);
                        neighbours.Add(cells[coordinateX, coordinateY + 1]);
                    }
                    else if (coordinateX == Width-1 && coordinateY == Hеight-1)
                    {
                        neighbours.Add(cells[coordinateX, coordinateY - 1]);
                        neighbours.Add(cells[coordinateX - 1, coordinateY - 1]);
                        neighbours.Add(cells[coordinateX - 1, coordinateY]);
                    }
                    else if (coordinateX == 0 && coordinateY == Hеight-1)
                    {
                        neighbours.Add(cells[coordinateX, coordinateY - 1]);
                        neighbours.Add(cells[coordinateX + 1, coordinateY - 1]);
                        neighbours.Add(cells[coordinateX + 1, coordinateY]);
                    }
                }
                //five neighbours cell
                else
                {
                    if (coordinateX == 0)
                    {
                        neighbours.Add(cells[0, coordinateY - 1]);
                        for (int i = -1; i < 2; i++)
                        {
                            neighbours.Add(cells[1, coordinateY + i]);
                        }
                        neighbours.Add(cells[0, coordinateY + 1]);
                    }
                    else if (coordinateX == Width-1)
                    {
                        neighbours.Add(cells[Width - 1, coordinateY - 1]);
                        for (int i = -1; i < 2; i++)
                        {
                            neighbours.Add(cells[Width - 2, coordinateY + i]);
                        }
                        neighbours.Add(cells[Width - 1, coordinateY + 1]);
                    }
                    else if (coordinateY == 0)
                    {
                        neighbours.Add(cells[coordinateX - 1, 0]);
                        for (int i = -1; i < 2; i++)
                        {
                            neighbours.Add(cells[coordinateX + i, 1]);
                        }
                        neighbours.Add(cells[coordinateX + 1, 0]);
                    }
                    else
                    {
                        neighbours.Add(cells[coordinateX - 1, Hеight - 1]);
                        for (int i = -1; i < 2; i++)
                        {
                            neighbours.Add(cells[coordinateX + i, Hеight - 2]);
                        }
                        neighbours.Add(cells[coordinateX + 1, Hеight - 1]);
                    }
                }
            }

            return neighbours;
        }
        // Method check if two cells is in same position. 
        public bool CheckTwoCellsPosition(Cell[,] cells, Cell cell)
        {
            int targetPositionX = TargetCell.PositionX;
            int targetPositionY = TargetCell.PositionY;
            int cellPositionX = cell.PositionX;
            int cellPositionY = cell.PositionY;
            if (targetPositionX == cellPositionX && targetPositionY == cellPositionY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
