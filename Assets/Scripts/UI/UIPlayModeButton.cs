using UnityEngine;

public class UIPlayModeButton : UIBase
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
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
