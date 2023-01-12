
using System;

public class DownActionSelection : IDownActionSelection
{
    public IDownAction CurrentDownAction { get; private set;  }
    public void Select(IDownAction downAction)
    {
        CurrentDownAction = downAction ?? throw new ArgumentNullException("Selection can not be null");
    }
}
