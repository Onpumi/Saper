using System;
using System.Collections.Generic;

public class ContainerMines
{
    private int MaxCountMines;
    private int _percentMine;
    private GameField _gameField;
    private ICell[,] _cells;
    private int[] _firstIndexes;
    public int CountMines { get; private set; }
    public int CountFlags { get; private set; }

    public ContainerMines( GameField gameField, ICell[,] cells, int[] firstIndexes )
    {
        _gameField = gameField;
        _cells = cells;
        _firstIndexes = firstIndexes;
    }
    
    public void GenerateMines( int percentMine, int countCells )
    {
        percentMine = _gameField.PercentMine;
        MaxCountMines = countCells * percentMine / 100;    

        List<int>[] arrayIndexes = new List<int>[_cells.GetLength(1)];
        
        for (int j = 0; MaxCountMines > 0; j++)
        {
            if (j >= _cells.GetLength(1) - 1) j = 0;
            if( j < 0 || j > _cells.GetLength(1)-1) throw new IndexOutOfRangeException(j.ToString());
            if( arrayIndexes[j] == null ) arrayIndexes[j] = new List<int>();
            var indexRandom = UnityEngine.Random.Range(0, _cells.GetLength(0));
            var maxIteration = 300000;
            var iteration = 0;
            while (DeniedSetMines(indexRandom, j) && iteration < maxIteration )
            {
                indexRandom = UnityEngine.Random.Range(0, _cells.GetLength(0));
                iteration++;
            }

            if (arrayIndexes[j].Count > 0)
            {
                var result = true;
                foreach (var index in arrayIndexes[j])
                {
                    if (indexRandom == index) result = false;
                }
                if( result == false )
                    continue;
            }
            arrayIndexes[j].Add(indexRandom);
            
            _cells[indexRandom, j].CreateMine( -1, indexRandom, j);
            CountMines++;
            MaxCountMines--;
            if (j >= _cells.GetLength(1) - 1) j = 0;
        }

        CountFlags = CountMines;
        _gameField.DisplayCountMines(CountMines);
    }
    
    
    private bool DeniedSetMines( int i, int j )
    {
        bool result = true;
        if ( 
            ( (i > _firstIndexes[0] + 1 || i < _firstIndexes[0] - 1 ) ||
              (j > _firstIndexes[1] + 1 || j < _firstIndexes[1] - 1)
            )
        )
        {
            result = result & false;
        }
        else
        {
            result = result & true;
        }
        return result;
    }
    
    public void  SetCountFlags( int value )
    {
        if ( CountFlags+value >= 0  )
        {   
            CountFlags+=value;
        }
    }
    
    

}
   
