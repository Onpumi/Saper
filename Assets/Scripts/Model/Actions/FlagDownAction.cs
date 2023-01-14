using System;
using UnityEngine;

public class FlagDownAction : IDownAction
{
    public void Select( ICell cell )
    {
        cell.SetFlag();
    }

}