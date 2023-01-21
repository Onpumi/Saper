using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayModeButton : MonoBehaviour, IUI
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    
    public void Lose(){}

    public void OpenMenuSettings()
    {
        gameObject.SetActive(false);
    }

    public void EnableForDisplay()
    {
        
    }
}
