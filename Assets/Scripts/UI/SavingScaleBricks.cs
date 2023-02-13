using System;
using UnityEngine;
using UnityEngine.UI;

public class SavingScaleBricks : UIBase
{
    [SerializeField] private WindowScaleBricks _windowScaleBricks;
    [SerializeField] private UIScalingBlocks _uiScalingBlocks;
    [SerializeField] private GameField _gameField;
    private TypesOption _typeOption = TypesOption.SizeCells;
    private Button _buttonSave;

    private void Awake()
    {
        _buttonSave = transform.GetChild(0).GetComponent<Button>() 
                      ?? throw new ArgumentException("You try to get null saving button");
        
        _buttonSave.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        _gameField.SaveScaleValueBricks(TypesOption.SizeCells, _uiScalingBlocks);
        _windowScaleBricks.Hide();
    }
}
