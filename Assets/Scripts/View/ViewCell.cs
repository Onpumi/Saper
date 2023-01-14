using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ViewCell : MonoBehaviour, IViewCell
{
    [SerializeField] private ViewMine _prefabViewMine;
    [SerializeField] private Sprite[] _spriteNumbers;
    [SerializeField] private ViewBrick _prefabViewBrick;
    [SerializeField] private ViewFlag _prefabViewFlag;
    [SerializeField] private ViewBoom _prefabViewBoom;
    public  float WidthSpriteCell { get; private set; }
    public  float HeightSpriteCell { get; private set; }
    private Sprite _sprite;
    private ViewBrick _viewBrick;
    private ViewFlag _viewFlag;
    
    

    private IDownAction _downAction;
    public CellData CellData { get; private set; }

    private void Awake()
    {
        _sprite = GetComponent<Image>().sprite ?? throw new ArgumentNullException("Sprite cell need is not null!");
        WidthSpriteCell = _sprite.rect.width;
        HeightSpriteCell = _sprite.rect.height; 
    }

    public void InitAction( GridCells grid, IDownAction downAction )
    {
        _downAction = downAction ?? throw new ArgumentNullException("Selection need is not be null");
        _downAction.Select(grid.Cells[CellData.Index1,CellData.Index2]);
    }
    
     public void SetTextNumbers( int value )
      {
          if (value >= 1 && value <= 8)
          {
              var image = GetComponent<Image>();
              image.sprite = _spriteNumbers[value - 1];
          }
      }

      public void InitCellData(CellData cellData)
      {
          cellData.Index1.TryThrowIfLessThanZero();
          cellData.Index2.TryThrowIfLessThanZero();
          CellData = cellData;
      }


      public bool InitFlag()
      {
          if (_viewFlag is null)
          {
              _viewFlag = Instantiate(_prefabViewFlag, transform);
          }
          else
          {
              _viewFlag.transform.gameObject.SetActive(!_viewFlag.Value);
          }
          _viewFlag.transform.localScale = Vector3.one / 3f;
          return _viewFlag.Value;
      }

        public void Display( ICell cell, Vector3 positionStart, float scale)
      {
          var widthSprite = WidthSpriteCell * scale;
          var heightSprite = HeightSpriteCell * scale;
          var camera = Camera.main;
          
          var currentPosition = new Vector3( positionStart.x, positionStart.y, 0f );
          var currentPositionScreen = camera.WorldToScreenPoint(currentPosition);
          currentPositionScreen.x += (float)widthSprite * (float)cell.CellData.Index1 ;
          currentPositionScreen.y += (float)heightSprite * (float)cell.CellData.Index2;
          var resultPosition = camera.ScreenToWorldPoint(currentPositionScreen);

          transform.position = resultPosition;
          transform.localScale = new Vector3(scale, scale, 0);
      }

      
}
