using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameState : SerializedMonoBehaviour, ICompositeRoot
{
    [SerializeField] private Views _views;
    [SerializeField] private GameField _gameField;
    [SerializeField] private List<IUI> _ui;
    public GameField GameField => _gameField;
    public List<IUI> UI => _ui;
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
        _gameField.transform.gameObject.SetActive(true);
        Game = new GameRunning();
    }

    public void OpenSettings(GameField gameField)
    {
        Game = new GameSettings(gameField);
        _ui.ForEach(ui=>ui.OpenMenuSettings());
    }
    
}
