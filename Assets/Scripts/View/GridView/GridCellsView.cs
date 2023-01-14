using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCellsView : MonoBehaviour, IGridCellsView
{
    [SerializeField] private ViewCell _prefabViewCell;
    [SerializeField] private ViewBrick _prefabViewBrick;
    [SerializeField] private float _needCountBricks = 150f;
    [SerializeField] private float _scaleHeightGrid = 0.9f;
    private float _scaleBrick = 1f;
    private GridCells _grid;
    private ViewCell[] _viewCells;
    private ScreenAdjusment _screenAdjusment;
    private SpriteData SpriteData;
    private FactoryCell _factoryCell;

    public Vector2 SizePerUnit { get; private set; }
    public GridCells Grid => _grid;
    

    public void Compose()
    {
        _screenAdjusment = new ScreenAdjusment( transform );
        SpriteData.Width = _prefabViewCell.GetComponent<Image>().sprite.rect.width;
        SpriteData.Height = _prefabViewCell.GetComponent<Image>().sprite.rect.height;
        CalculateScale();
        _grid = new GridCells(this, _scaleBrick, _scaleHeightGrid);
        
    }

    private void CalculateScale()
    {
        var _needCountBricks = 150f;
        var screenArea = _screenAdjusment.ResolutionCanvas.x * _screenAdjusment.ResolutionCanvas.y;
        var spriteArea = SpriteData.Width * SpriteData.Height;
        var deltaScale = Mathf.Sqrt(screenArea / (_needCountBricks * spriteArea));
        _scaleBrick *= deltaScale;
        
    }
    
    public Vector2 GetSizePerUnit( float scaleX, float scaleY )
    {
        var resolutionCanvas = _screenAdjusment.ResolutionCanvas;
        var refPixelsPerUnit = _screenAdjusment.RefPixelsPerUnit;
        return  SizePerUnit = new Vector2( resolutionCanvas.x / (refPixelsPerUnit * scaleX), 
                                           resolutionCanvas.y / (refPixelsPerUnit * scaleY));
    }
    
    public void DisplayCells( ICell[,] cells, int countColumns, int countRows, float scale )
    {
        int indexCell = 0;
        var delta = 0;

        var camera = Camera.main ?? throw new NullReferenceException("Camera is null");;

        var resolutionCanvas = _screenAdjusment.ResolutionCanvas;
        var heightSprite = SpriteData.Height * scale;
        var widthSprite = SpriteData.Width * scale;
        var _tabLeftForSprite = (resolutionCanvas.x - (float)countColumns * widthSprite) / 2f;
        var _tabTopForSprite = resolutionCanvas.y * 0.01f;

        var positionStart = camera.ScreenToWorldPoint(new Vector3(_tabLeftForSprite + widthSprite/2f, 
            _tabTopForSprite + heightSprite/2f) );

        if (_viewCells == null)
        {
            _viewCells = new ViewCell[countRows * countColumns];
        }

        
        for( var i = 0 ; i < countColumns ; i++ )
        for (var j = 0; j < countRows; j++)
        {
            var cellData = new CellData(i, j, scale);
            var factoryViewCell = new FactoryViewCell( _prefabViewCell, _prefabViewBrick, cellData, transform );
            var factoryCell = new FactoryCell(factoryViewCell, cellData );
            cells[i, j] = factoryCell.Create();
            cells[i,j].Display( positionStart, scale);
            indexCell++;
        }
    }



}
