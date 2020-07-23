# GreenVsRed

                                      Class 
          Cell                                                  Grid
       - Green Cell
       - Red Cell
      

Cell methods:                                              Grid methods:
- abstract int GetCellType()
- abstract int GetValue()                                  - int CheckNeighboursSum(Cell cell, Cell[,] cells)
- abstract int CheckNextValue                              - List<Cell> FindNeighbours(Cell centralCell, Cell[,] cells)
- int[] GetCellPosition(int sum)                           - bool CheckTwoCellsPosition(Cell[,] cells, Cell cell)
                                                           
    Green & Red Cell methods:
    - override int GetCellType()
    - override int GetValue()
    - override int CheckNextValue(int sum)
    
    
