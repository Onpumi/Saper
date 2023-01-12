public interface IDownActionSelection
{
    IDownAction CurrentDownAction { get; }
    void Select(IDownAction downAction);
}