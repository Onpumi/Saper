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
    public Cell Cell { get; private set; }
    private void Awake()
    {
        _scale = Vector3.one / 1.5f;
    }

    public void SetColor( Color color)
    {
        transform.GetComponent<SpriteRenderer>().color = color;
    }

      public void InstantiateMine()
      {
          var mine = Instantiate(_prefabViewMine, transform);
          mine.transform.localScale = _scale;
      }

      public void SetTextNumbers( int value )
      {
          if (value >= 1 && value <= 8)
              GetComponent<Image>().sprite = _spriteNumbers[value - 1];
      }

      public void InstatiateBricks()
      {
          _viewBrick = Instantiate(_prefabViewBrick, transform);
          _viewBrick.transform.localScale = Vector3.one;
      }

      public void InstatiateFlags()
      {
          var flag = Instantiate(_prefabViewFlag, transform);
          flag.transform.localScale = Vector3.one / 3f;
          flag.transform.position = Camera.main.ScreenToWorldPoint( new Vector3(20f,50f, 0f) );
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
