# GreenVsRed

                                      Class 
          Cell                                                  Grid
       - Green Cell
       - Red Cell
      

Cell methods:                                              
- abstract int GetCellType()
- abstract int GetValue()                                  
- abstract int CheckNextValue                              
- int[] GetCellPosition(int sum)                           
                                                           
    Green & Red Cell methods:
    - override int GetCellType()
    - override int GetValue()
    - override int CheckNextValue(int sum)
    
    
Grid methods:
- int CheckNeighboursSum(Cell cell, Cell[,] cells)
- List<Cell> FindNeighbours(Cell centralCell, Cell[,] cells)
- bool CheckTwoCellsPosition(Cell[,] cells, Cell cell)
