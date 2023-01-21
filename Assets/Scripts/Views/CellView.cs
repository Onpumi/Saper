using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour, ICellView, IView
{
    [SerializeField] private MineView _prefabMineView;
    [SerializeField] private Sprite[] _spriteNumbers;
    [SerializeField] private FlagView _prefabFlagView;
    [SerializeField] private BoomView _prefabBoomView;
    public  float WidthSpriteCell { get; private set; }
    public  float HeightSpriteCell { get; private set; }
    private Sprite _sprite;
    private FlagView _flagView;

    public MineView MineView => _prefabMineView;
    public BoomView BoomView => _prefabBoomView;
    public FlagView FlagView => _flagView;
    private IDownAction _downAction;
    public CellData CellData { get; private set; }

    private void Awake()
    {
        _sprite = GetComponent<Image>().sprite ?? throw new ArgumentNullException("Sprite cell need is not null!");
        WidthSpriteCell = _sprite.rect.width;
        HeightSpriteCell = _sprite.rect.height; 
    }

    public bool InitAction( FieldCells field, IDownAction downAction )
    {
        _downAction = downAction ?? throw new ArgumentNullException("Selection need is not be null");
        return _downAction.Select(field.Cells[CellData.Index1,CellData.Index2]);
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


      public bool InitFlag( bool value )
      {
          if (_flagView is null)
          {
              _flagView = Instantiate(_prefabFlagView, transform);
               
          }
          else
          {
              //_flagView.transform.gameObject.SetActive(!_flagView.Value);
              _flagView.transform.gameObject.SetActive(value);
          }
          _flagView.transform.localScale = Vector3.one / 3f;
          return _flagView.Value;
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

        public float GetWidth() => GetComponent<Image>().sprite.rect.width;
        public float GetHeight() => GetComponent<Image>().sprite.rect.height;

        public Transform GetTransform() => transform;

        public CellData GetCellData() => CellData;
        
        public InputHandler GetInput() => transform.GetComponent<InputHandler>();
}
