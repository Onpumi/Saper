using UnityEngine;
using UnityEngine.UI;

public class ViewCell : MonoBehaviour, IViewItem
{
    [SerializeField] private ViewMine _prefabViewMine;
    [SerializeField] private Sprite[] _spriteNumbers;
    [SerializeField] private ViewBrick _prefabViewBrick;
    private Vector3 _scale;
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
          var mine = Instantiate(_prefabViewBrick, transform);
          mine.transform.localScale = Vector3.one;
      }

      public void CellInput( Cell cell )
      {
          Cell = cell;
      }

      public void Display()
      {
          
      }

      
      
}
