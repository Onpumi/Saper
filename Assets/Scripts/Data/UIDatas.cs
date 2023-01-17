using UnityEngine;

public class UIDatas : MonoBehaviour,IUI
{
    [SerializeField] UIButtonPlay _buttonPlay;
    [SerializeField] private GameState _gameState;
    [SerializeField] private Transform _transformCanvas;
    [SerializeField] private GameField _gameField;

    public UIButtonPlay UIButtonPlay => _buttonPlay;
    public GameState GameState => _gameState;
    public Transform TransformCanvas => _transformCanvas;
    public GameField GameField => _gameField;
}