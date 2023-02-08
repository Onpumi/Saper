
using Sirenix.OdinInspector;
public abstract class UIBase : SerializedMonoBehaviour, IUI
{
    public virtual void Lose() { }

    public virtual void OpenMenuSettings() { }

    public virtual void OpenMenuSizeCells()
    {
    }


    public virtual void EnableForDisplay() => Open();

    public virtual void Hide() => gameObject.SetActive(false);

    protected void Open() => gameObject.SetActive(true);
}
