using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimer : MonoBehaviour, IUI
{
    public void Lose()
    {
        
    }

    public void OpenMenuSettings()
    {
        gameObject.SetActive(false);   
    }
}
