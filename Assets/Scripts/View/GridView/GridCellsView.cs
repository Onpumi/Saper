using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCellsView : MonoBehaviour, IGridCellsView
{
    [SerializeField] private ViewCell _prefabView;
    private GridCells _grid;
    private ViewCell[] _viewCells;
    private ScreenAdjusment _screenAdjusment;
    private SpriteData SpriteData;
    private FactoryViews<ViewCell> _factoryViews;

    public Vector2 SizePerUnit { get; private set; }
    public GridCells Grid => _grid;
    
    private void Awake()
    {
        _screenAdjusment = new ScreenAdjusment( transform );
        SpriteData.Width = _prefabView.GetComponent<Image>().sprite.rect.width;
        SpriteData.Height = _prefabView.GetComponent<Image>().sprite.rect.height;
        _factoryViews = new FactoryViews<ViewCell>(_prefabView, transform);
    }

    private void Start()
    {
        _grid = new GridCells(this);
    }
    
    
    public Vector2 GetSizePerUnit( float scaleX, float scaleY )
    {
        var resolutionCanvas = _screenAdjusment.ResolutionCanvas;
        var refPixelsPerUnit = _screenAdjusment.RefPixelsPerUnit;
        return  SizePerUnit = new Vector2( resolutionCanvas.x / (refPixelsPerUnit * scaleX), 
                                           resolutionCanvas.y / (refPixelsPerUnit * scaleY));
    }
    
    public void DisplayCells( Cell[,] cells, int countColumns, int countRows, float scale )
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
        
       _viewCells = _factoryViews.CreateAll(countRows * countColumns);
        
        for( var i = 0 ; i < countColumns ; i++ )
        for (var j = 0; j < countRows; j++)
        {
            _viewCells[indexCell].InitCellData( new CellData(i,j) );
            cells[i, j] = new Cell(_viewCells[indexCell],i,j);
            cells[i,j].Display( positionStart, scale);
            indexCell++;
        }
    }



}
