using System;
using TMPro;
using UnityEngine;
public class UITimer : UIBase
{
    [SerializeField] private TMP_Text _tmpText;

    private void Start()
    {
        ResetValue();
    }

    public void ResetValue()
    {
        _tmpText.text = "0";
    }

    public void Display(int timeSecond)
    {
        _tmpText.text =  Convert.ToString( timeSecond );
    }
}


