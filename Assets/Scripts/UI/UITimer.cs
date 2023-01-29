using System;
using TMPro;
using UnityEngine;
public class UITimer : UIBase
{
    [SerializeField] private TMP_Text _tmpText;
    private DateTime _time = DateTime.Today;
    private void Start()
    {
        ResetValue();
    }

    public void ResetValue()
    {
        _tmpText.text = DateTime.Today.ToString("mm:ss");
        _time = DateTime.Today;
    }

    public void Display(int timeSecond)
    {
        _time = _time.AddSeconds(1);
        _tmpText.text = _time.ToString("mm:ss");
    }
}


