using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour, IButton, IPointerDownHandler
{
    [SerializeField] private Views _views;
    [SerializeField] private GameState _gameState;
    [SerializeField] private Transform _canvas;
    [SerializeField] private GameField _gameField;
    private float _scale;
    private Text _text;

    public void Start()
    {
        _scale = _gameField.Scale;        
        transform.localScale = new Vector3(_scale,_scale) * 3f;
        _text = transform.GetChild(0).GetComponent<Text>();
    }
    
    public void Play()
    {
        _gameField.DestroyField();
    }

    public void SetText( string text )
    {
        _text.text = text;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_gameState.Game.IsRun == false)
        {
            _gameState.StartGame();
            Play();
        }
    }
}
