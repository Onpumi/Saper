using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(UIData))]

public class GameState : SerializedMonoBehaviour, ICompositeRoot
{
    [SerializeField] private List<IUI> _ui;
    private UIData _uiData;
    private Timer _timer;
    public List<IUI> UI => _ui;
    public IGame Game { get; private set; }

    public void Init()
    {
        _ui ??= new List<IUI>() ;
        _uiData ??= GetComponent<UIData>(); 
        _timer = new Timer(_uiData.UITimer);
    }

    public void StopGame()
    {
        Game = new GameStoping( _timer );
    }

    public void ResetTimeView() => _uiData.UITimer.ResetValue();

    public void StartGame() => Game = new GameRunning( _timer );

    public void OpenSettings()
    {
        if (Game is GameRunning)
        {
            Game = new GameSettings( this, _timer);
        }

        _ui.ForEach(ui=>ui.OpenMenuSettings());
    }

    public void OpenMenuSizeCells() =>_ui.ForEach(ui=>ui.OpenMenuSizeCells());
    

    public int GetTimeResult() => _timer.ResultTme;


}
