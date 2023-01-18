using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class UIDatas : MonoBehaviour
{
    [SerializeField] private List<IUI> _uis;  
    [SerializeField] private UIButtonPlay _buttonPlay;
    [SerializeField] private GameState _gameState;
    [SerializeField] private Transform _transformCanvas;
    [SerializeField] private GameField _gameField;

    public UIButtonPlay UIButtonPlay => _buttonPlay;
    public GameState GameState => _gameState;
    public Transform TransformCanvas => _transformCanvas;
    public GameField GameField => _gameField;
}