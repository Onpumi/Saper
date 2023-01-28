using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameState : SerializedMonoBehaviour, ICompositeRoot
{
    [SerializeField] private Views _views;
    [SerializeField] private GameField _gameField;
    [SerializeField] private List<IUI> _ui;
    [SerializeField] private UIDatas _uiDatas;
    private Timer _timer;
    public GameField GameField => _gameField;
    public List<IUI> UI => _ui;
    public IGame Game { get; private set; }
    
    

    public void Init()
    {
        _timer = new Timer(_uiDatas.UITimer);
    }

    public void StopGame()
    {
        Game = new GameStoping( _timer );
    }

    public void ResetTimeView() => _uiDatas.UITimer.ResetValue();

    public void StartGame()
    {
        _gameField.transform.gameObject.SetActive(true);
         Game = new GameRunning( _timer );
    }

    public void OpenSettings(GameField gameField)
    {
        Game = new GameSettings( _timer );
        _ui.ForEach(ui=>ui.OpenMenuSettings());
    }

    public int GetTimeResult() => _timer.ResultTme;

    private void OnApplicationQuit()
    {
        Application.Quit();
    }

    private void Update()
    {
        /*
        if (Input.GetAxis("Cancel") > 0 || Input.GetKey(KeyCode.Space))
        {
            if( Game is GameRunning) Application.Quit();
            else if (Game is GameSettings)
            {
                Game = new GameRunning( _timer );
            }
        }
        */
    }


}
