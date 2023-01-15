using System;
using UnityEngine;

public class FlagDownAction : IDownAction
{
    public bool Select( ICell cell )
    {
        cell.SetFlag();
        return true;
    }

}