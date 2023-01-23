using UnityEngine;
using UnityEngine.UI;

public class WindowsWinner : MonoBehaviour
{

    private UIButtonPlay _buttonPlay;
    
    private void Awake()
    {
        _buttonPlay = GetComponentInChildren<UIButtonPlay>();
        Hide();
    }


    public void Display()
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        _buttonPlay.gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        _buttonPlay.gameObject.SetActive(false);
    }
        
    
    
}
