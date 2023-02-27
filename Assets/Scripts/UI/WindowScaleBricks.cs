using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowScaleBricks : UIBase
{
    [SerializeField] private GameField _gameField;
    [SerializeField] private UISliderSizeCells _uiSliderSizeCells;
    [SerializeField] private UIScalingBlocks _uiScalingBlocks;
    [SerializeField] private Transform _backGround;

   
    private void Start()
    {
        var canvasScaler = GetComponent<CanvasScaler>()
                             ?? throw new ArgumentException("Canvas Scaler is not available");
        canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);
        var resolutionX =  canvasScaler.referenceResolution.x;
        var resolutionY = canvasScaler.referenceResolution.y;
        canvasScaler.referenceResolution = new Vector2(resolutionX, resolutionY);
        var gridLayout = _backGround.GetComponent<GridLayoutGroup>()
                                        ?? throw new ArgumentException("Grid Layout Group is not available");
        gridLayout.cellSize = new Vector2( resolutionX, resolutionY / 5f );
        Hide();
    }

    public override void OpenMenuSizeCells()
    {
        
        Open();
        _uiScalingBlocks.OpenMenuSizeCells();
        _uiSliderSizeCells.OpenMenuSizeCells();
    }
    
    
}
   
