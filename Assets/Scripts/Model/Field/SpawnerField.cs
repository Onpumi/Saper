using System;
using UnityEngine;

public class SpawnerField
{
    private FieldCells _fieldCells;
    private ContainerMines _containerMines;
    private GameField _gameField;
    private float _scale;
    private int _countColumns;
    private int _countRows;
    private ICell[,] _cells;
    private IDownAction _downAction;

    public SpawnerField( FieldCells fieldCells, ContainerMines containerMines, ICell[,] cells, float scale, int countColumns, int countRows )
    {
        _fieldCells = fieldCells;
        _cells = cells;
        _scale = scale;
        _countColumns = countColumns;
        _countRows = countRows;
        _containerMines = containerMines;
    }
    
    public void CreateBlocks( )
    {
        _gameField = _fieldCells.GameField;
        var camera = _gameField.CameraField ?? throw new NullReferenceException("Camera is null");;
        var resolutionCanvas = _gameField.ScreenAdjusment.ResolutionCanvas;
        var heightSprite = _gameField.SpriteData.Height * _scale;
        var widthSprite = _gameField.SpriteData.Width * _scale;
        var tabLeftForSprite = (resolutionCanvas.x - (float)_countColumns * widthSprite) / 2f;
        var tabTopForSprite = resolutionCanvas.y * 0.01f;
        var positionStart = camera.ScreenToWorldPoint(new Vector3(tabLeftForSprite + widthSprite/2f, 
            tabTopForSprite + heightSprite/2f) );

        for( var i = 0 ; i < _countColumns ; i++ )
        for (var j = 0; j < _countRows; j++)
        {
            var cellData = new CellData(i, j, _scale);
            var factoryViewCell = new FactoryCellView( _gameField.PrefabCellView, _gameField.PrefabBrickView, cellData, _gameField.transform );
            var factoryCell = new FactoryCell(factoryViewCell, cellData );
            _cells[i, j] = factoryCell.Create();
            _cells[i, j].GetInputHandler().OnClickCell += ReadInputClick;
            _cells[i,j].Display( positionStart, _scale);
        }
    }
    
    private void ReadInputClick( InputHandler inputHandler)
    {
        if (_gameField.GameState.Game.IsRun == false) return;
        if (inputHandler.IsTimeShort())
        {
            if (inputHandler.transform.TryGetComponent(out CellView viewCell) == false) return;
            if (viewCell.transform.parent.TryGetComponent(out GameField gridView) == false) return;

           _downAction = new DigDownAction(_fieldCells);

            if (_gameField.ButtonMode.Mode == ButtonMode.Flag)
            {
                _downAction = new FlagDownAction(_fieldCells, _containerMines);
            }

            if (_fieldCells.IsFirstClick) viewCell.InitAction(_fieldCells, new FirstDigDownAction( _fieldCells ));

            if (viewCell.InitAction(_fieldCells, _downAction) == false)
            {
                _gameField.GameState.StopGame();
                _gameField.GameState.UI.ForEach(ui => ui.Lose());
            }
        }
        else
        {
            if (_gameField.GameState.Game.IsRun == true)
            {
                if (inputHandler.transform.TryGetComponent(out CellView viewCell) == false) return;
                if (viewCell.transform.parent.TryGetComponent(out GameField gridView) == false) return;

                _downAction = new FlagDownAction(_fieldCells, _containerMines);
                if (_gameField.GameState.GameField.ButtonMode.Mode == ButtonMode.Flag)
                {
                    _downAction = new DigDownAction(_fieldCells);
                }

                viewCell.InitAction(_fieldCells,_downAction);
            }
        }
    }

    
}
