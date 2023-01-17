using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameState : SerializedMonoBehaviour, ICompositeRoot
{
    [SerializeField] private Views _views;
    [SerializeField] private GameField _gameField;
    [SerializeField] private IUI _ui;
    public GameField GameField => _gameField;
    public IUI UI => _ui;
    public IGame Game { get; private set; }
    

    public void Init()
    {
         StartGame();
    }

    public void StopGame()
    {
        Game = new GameStoping();
    }

    public void StartGame()
    {
        Game = new GameRunning();
    }

    public void OpenSettings(GameField gameField)
    {
        Game = new GameSettings(gameField);
    }
    
}
