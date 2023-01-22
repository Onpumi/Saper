using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerMines
{
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
    
    public void GenerateMines()
    {
        for (int j = 0; j < _cells.GetLength(1); j++)
        {
            var indexRandom = UnityEngine.Random.Range(0, _cells.GetLength(0));
            var maxIteration = 100000;
            var iteration = 0;
            while (DeniedSetMines(indexRandom, j) && iteration < maxIteration)
            {
                indexRandom = UnityEngine.Random.Range(0, _cells.GetLength(0));
                iteration++;
            }
            _cells[indexRandom, j].CreateMine( -1, indexRandom, j);
            CountMines++;
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
        //Debug.Log(CountFlags);
        if ( CountFlags+value >= 0  )
        {   
            CountFlags+=value;
        }
    }
    
    

}
   
