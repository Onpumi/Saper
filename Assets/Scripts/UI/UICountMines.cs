using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICountMines : MonoBehaviour, IUI
{

    [SerializeField] private GameField _gameField;
    [SerializeField] private TMP_Text _tmpText;

    
    private void Start()
    {
        gameObject.SetActive(false);
        _tmpText.text = "0";
    }

    public void Lose() { }

    public void EnableForDisplay()
    {
        gameObject.SetActive(true);
    }

    public void Display( int countMines )
    {
        _tmpText.text =  Convert.ToString( countMines );
    }
    

    public void OpenMenuSettings()
    {
        gameObject.SetActive(false);
    }
}
