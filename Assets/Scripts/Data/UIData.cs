using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class UIData : MonoBehaviour
{
    [SerializeField] private List<IUI> _uis;  
    [SerializeField] private GameState _gameState;
    [SerializeField] private Transform _transformCanvas;
    [SerializeField] private GameField _gameField;
    [SerializeField] private UITimer _uiTimer;
    [SerializeField] private ControllerButtonMode _buttonMode;
    [SerializeField] private WindowWinner _windowWinner;
    [SerializeField] private UICountMines _countMines;

    public UITimer UITimer => _uiTimer;
    public ControllerButtonMode ControllerButtonMode => _buttonMode;
    public WindowWinner WindowWinner => _windowWinner;
    public UICountMines UICountMines => _countMines;
    public GameState GameState => _gameState;
    public Transform TransformCanvas => _transformCanvas;
    public GameField GameField => _gameField;
}