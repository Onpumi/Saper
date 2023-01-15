using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameState : SerializedMonoBehaviour, ICompositeRoot
{
    [SerializeField] private Views _views;
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
}
