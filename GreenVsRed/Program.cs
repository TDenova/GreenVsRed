using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenVsRed
{
    class Program
    {
        static void Main(string[] args)
        {
            // First input with validation
            int width, hеight;
            do
            {
                string[] gridSize = Console.ReadLine().Split(',');
                
                width = int.Parse(gridSize[0]);
                hеight = int.Parse(gridSize[1]);
                if (gridSize.Length>2)
                {
                    Console.WriteLine("This is a 2D game, so you need to enter two dimensions!");
                }
                else if (width > hеight)
                {
                    Console.WriteLine("Please enter correct value. Width have to be equal or smaller than height!");
                }
                else if(hеight >= 1000)
                {
                    Console.WriteLine("Please enter correct value. Hight have to be smaller than 1000!");
                }
                else if(width < 0 || hеight < 0)
                {
                    Console.WriteLine("Please enter correct value. Hight and width must be positive numbers!");
                }
            } while (width > hеight || hеight >= 1000 || width < 0 || hеight < 0);

            //Second input with validation.
            string[] rows = new string [hеight];
            for (int i = 0; i < hеight; i++)
            {
                rows[i] = Console.ReadLine();
                char[] row = rows[i].ToCharArray();
                
                if (rows[i].Length != width)
                {
                    Console.WriteLine("Please enter {0} columns.", width);
                    i = -1;
                    continue;
                }
                else if (!CheckCharArr(row))
                {
                    Console.WriteLine("Please enter only 1s and 0s.");
                    i = -1;
                    continue;
                }
            }

            //Third input with validation
            int targetCoordinateX, targetCoordinateY, turns;

            do
            {
                string inputRow = Console.ReadLine();

                string[] inputArr = inputRow.Split(',').ToArray();
                targetCoordinateX = int.Parse(inputArr[0]);
                targetCoordinateY = int.Parse(inputArr[1]);
                turns = int.Parse(inputArr[2]);

                if (targetCoordinateX < 0 || targetCoordinateY < 0 || targetCoordinateX >= width || targetCoordinateY >= hеight)
                {
                    Console.WriteLine("Please enter correct coordinates.");
                }
                else if (turns < 0)
                {
                    Console.WriteLine("The number for Generation must be positive.");
                }

            } while (targetCoordinateX < 0 || targetCoordinateY < 0 || targetCoordinateX >= width || targetCoordinateY >= hеight || turns < 0 );

            //Put input 2 in char array
            char[,] values = new char[width, hеight];
            for (int i = 0; i < rows.Length; i++)
            {
                char[] row = rows[i].ToCharArray();
                for (int j = 0; j < row.Length; j++)
                {
                    values[i, j] = row[j];
                }
                
            }

            // Convert char array to integer array 
            int[,] cellValues = new int[width, hеight];
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    int value = (int)values[i, j];
                    if (value == 48)
                    {
                        cellValues[i, j] = value - 48;
                    }
                    else
                    {
                        cellValues[i, j] = value - 48;
                    }
                }
            }

            //Create array from green and red cells. 
            Cell[,] cells = new Cell[width, hеight];
            for (int i = 0; i < cellValues.GetLength(0); i++)
            {
                for (int j = 0; j < cellValues.GetLength(1); j++)
                {
                    if (cellValues[i,j] == 0)
                    {
                        RedCell redCell = new RedCell(i, j, 0);
                        cells[i, j] = redCell;
                        
                    }
                    else
                    {
                        GreenCell greenCell = new GreenCell(i, j, 1);
                        cells[i, j] = greenCell;
                    }
                }
            }
            Cell targetCell = cells[targetCoordinateX, targetCoordinateY];
            
            //Create Generation Zero.
            Grid grid = new Grid(width, hеight, cells, targetCell);

            //Counter for target cell.
            int countGreen = 0;
            
            for (int n = 0; n < turns; n++)
            {
                Cell[,] nextGeneration = new Cell[width, hеight];
                for (int i = 0; i < cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cells.GetLength(1); j++)
                    {
                        cells[i, j].SumOfNeighbours = grid.CheckNeighboursSum(cells[i, j], cells);
                        int sum = cells[i, j].SumOfNeighbours;

                        //value of the cell in this generation
                        int lastValue = cells[i, j].GetValue();
                        //value of the cell in next generation
                        int control = cells[i, j].CheckNextValue(sum);

                        bool checkTarget = grid.CheckTwoCellsPosition(cells, cells[i, j]);
                        
                        if (control == 1 && lastValue == 0)
                        {
                            if (checkTarget)
                            {
                                countGreen++;
                            }
                            Cell newCell = new GreenCell(i, j, 1);
                            nextGeneration[i, j] = newCell;
                        }
                        else if (control == 0 && lastValue == 1)
                        {
                            Cell newCell = new RedCell(i, j, 0);
                            nextGeneration[i, j] = newCell;
                        }
                        else if (lastValue == 1 && control == 1)
                        {
                            if (checkTarget)
                            {
                                countGreen++;
                            }
                            
                            Cell newCell = new GreenCell(i, j, 1);
                            nextGeneration[i, j] = newCell;
                        }
                        else
                        {
                            nextGeneration[i, j] = cells[i, j];
                        }
                    }
                }
                Grid gridNextGeneration = new Grid(width, hеight, nextGeneration, targetCell);
                cells = nextGeneration;
            }
            //Result of the game.
            Console.WriteLine(countGreen);
        }
        
        //Method is checking char array, if he contains only 1s and 0s. 
        public static bool CheckCharArr(char[] row)
        {
            bool isCorrectInput = true;
            for (int i = 0; i < row.Length; i++)
            {
                
                if (row[i] == 48 || row[i] == 49)
                {
                    continue;
                }
                else
                {
                    isCorrectInput = false;
                    break;
                }
            }
            return isCorrectInput;
        }
        
    }
}
