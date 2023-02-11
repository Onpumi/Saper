using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISliderSizeCells : UIBase
{

    [SerializeField] private UIScalingBlocks _uiScalingBlocks;
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(delegate { ChangeScaleBrick(); });
    }
    
    

    public override void OpenMenuSizeCells()
    {
        _slider.value = _uiScalingBlocks.ScaleBricks;
        Open();
    }

    private void ChangeScaleBrick()
    {
        _uiScalingBlocks.SetScale(_slider.value);
        _uiScalingBlocks.Display();
    }

}
