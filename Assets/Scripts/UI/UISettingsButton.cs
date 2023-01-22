using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISettingsButton : MonoBehaviour, IUI
{
   
    public void Lose() { }

    public void EnableForDisplay()
    {
        gameObject.SetActive(true);
    }

    public void OpenMenuSettings()
    {
       gameObject.SetActive(false);   
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
