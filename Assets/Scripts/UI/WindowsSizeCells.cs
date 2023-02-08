using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class WindowsSizeCells : UIBase
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameField _gameField;
    [SerializeField] private Views _views;
    private float _scaleBricks;
    private void Start() => Open(false);

    public override void OpenMenuSettings() => Open(false);

    public void Open(bool value)
    {
        _scaleBricks = _gameField.ScaleBrick;
        transform.gameObject.SetActive(value);
        var gridLayout = GetComponent<GridLayoutGroup>();
        var brick = _views.BrickView;
        var width = brick.GetWidth();
        var height = brick.GetHeight();
        
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }

        transform.localScale = new Vector3(_scaleBricks, _scaleBricks);
        gridLayout.cellSize = new Vector2(width * _scaleBricks , height * _scaleBricks) ;
        
    }
}
