
using UnityEngine;
public abstract class UIBase : MonoBehaviour, IUI
{
    public virtual void Lose()
    {
    }

    public virtual void OpenMenuSettings()
    {
    }

    public virtual void EnableForDisplay()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
