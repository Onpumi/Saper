using System;

public class FlagDownAction : IDownAction
{
    public void Select( ICell cell )
    {
        cell.SetFlag();
    }

}