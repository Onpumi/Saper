using UnityEngine;

public interface IUI
{

    public UIButtonPlay UIButtonPlay { get; }
    public float Scale { get; }
    public GameState GameState { get; }
    public Transform TransformCanvas { get; }
    public GameField GameField { get; }
}
