
using UnityEngine;
public abstract class UIBase : MonoBehaviour, IUI
{
    public virtual void Lose()
    {
    }

    public virtual void OpenMenuSettings()
    {
        //gameObject.SetActive(false);
        
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
