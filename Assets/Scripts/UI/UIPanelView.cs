using UnityEngine;

public class UIPanelView : MonoBehaviour, IUI
{
    public void Lose()
    {
        
    }

    public void OpenMenuSettings()
    {
     gameObject.SetActive(false);   
    }
}
