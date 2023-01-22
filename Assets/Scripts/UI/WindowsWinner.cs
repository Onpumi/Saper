using UnityEngine;
using UnityEngine.UI;

public class WindowsWinner : MonoBehaviour
{

    private Image _image;
    private UIButtonPlay _buttonPlay;
    
    private void Awake()
    {
        _buttonPlay = GetComponentInChildren<UIButtonPlay>();
        Hide();
        _image = GetComponent<Image>();
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
