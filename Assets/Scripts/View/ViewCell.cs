using UnityEngine;
using UnityEngine.UI;

public class ViewCell : MonoBehaviour, IViewItem
{
    [SerializeField] private ViewMine _prefabViewMine;
    [SerializeField] private Sprite[] _spriteNumbers;
    [SerializeField] private ViewBrick _prefabViewBrick;
    [SerializeField] private ViewFlag _prefabViewFlag;
    [SerializeField] private ViewBoom _prefabViewBoom;
    private Vector3 _scale;
    private ViewBrick _viewBrick;
    private ViewFlag _viewFlag;
    public Cell Cell { get; private set; }

    private void Awake()
    {
        _scale = Vector3.one / 1.5f;

    }

    public void InstantiateMine()
      {
          var mine = Instantiate(_prefabViewMine, transform);
          mine.transform.localScale = _scale;
          var index = mine.transform.GetSiblingIndex();
          mine.transform.SetSiblingIndex(--index);
      }

      public void SetTextNumbers( int value )
      {
          if (value >= 1 && value <= 8)
          {
              var image = GetComponent<Image>();
              image.sprite = _spriteNumbers[value - 1];
          }
      }

      public void InstatiateBricks()
      {
          _viewBrick = Instantiate(_prefabViewBrick, transform);
          _viewBrick.transform.localScale = Vector3.one;
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

      public void InstatiateBoom()
      {
          var boom = Instantiate(_prefabViewBoom, transform.parent);
          boom.transform.localScale = Vector3.one * 5f;
      }

      public void CellInput( Cell cell )
      {
          Cell = cell;
      }

      public void Display()
      {
          
      }
}
