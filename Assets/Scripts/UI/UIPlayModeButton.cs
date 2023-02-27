using UnityEngine;

public class UIPlayModeButton : UIBase
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    
    

    public override void OpenMenuSettings()
    {
        gameObject.SetActive(false);
    }

    /*    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    */
}
