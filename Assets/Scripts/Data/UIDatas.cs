using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class UIDatas : MonoBehaviour
{
    [SerializeField] private List<IUI> _uis;  
    [SerializeField] private GameState _gameState;
    [SerializeField] private Transform _transformCanvas;
    [SerializeField] private GameField _gameField;
    [SerializeField] private UITimer _uiTimer;

    public UITimer UITimer => _uiTimer;
    public GameState GameState => _gameState;
    public Transform TransformCanvas => _transformCanvas;
    public GameField GameField => _gameField;
}