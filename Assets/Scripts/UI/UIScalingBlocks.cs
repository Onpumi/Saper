using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class UIScalingBlocks : UIBase
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private GameField _gameField;
    [SerializeField] private Views _views;
    public float ScaleBricks { get; private set; }
    private float _widthBrick;
    private float _heightBrick;
    private GridLayoutGroup _gridLayout;

    public override void OpenMenuSizeCells() => Open(true);


    public void Open(bool value)
    {
        
        ScaleBricks = _gameField.ScaleBrick;
        transform.gameObject.SetActive(value);
        _gridLayout = GetComponent<GridLayoutGroup>();
        var brick = _views.BrickView;
        _widthBrick = brick.GetWidth();
        _heightBrick = brick.GetHeight();

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
        
        foreach (Transform child in transform.GetChild(0))
        {
            child.gameObject.SetActive(value);
        }
        Display();
    }

    public void SetScale( float value )
    {
          ScaleBricks = value;
    }
    public void Display()
    {
        _gridLayout.cellSize = new Vector2(_widthBrick * ScaleBricks , _heightBrick * ScaleBricks) ;
    }
    
}
