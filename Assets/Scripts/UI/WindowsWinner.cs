using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowsWinner : MonoBehaviour
{

    [SerializeField] private UIButtonPlay _buttonPlay;
    [SerializeField] private GameState _gameState;

    private int _timeResult;
    private TextMeshPro _text;
    
    
    private void Awake()
    {
         Hide();
         _text = GetComponent<TextMeshPro>();

    }


    public void Display()
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        var buttonPlay = transform.Find("ButtonPlay") ?? throw new ArgumentException("ButtonPlay is not be null");
        buttonPlay.gameObject.SetActive(true);
        _text.text = _text.text + _gameState.GetTimeResult().ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        foreach (Transform child in transform.parent)
        {
            child.gameObject.SetActive(false);
        }
    }
        
    
    
}
