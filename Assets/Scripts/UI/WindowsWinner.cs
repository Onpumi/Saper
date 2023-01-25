using System;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(GridLayoutGroup))]

public class WindowsWinner : MonoBehaviour
{

    [SerializeField] private UIButtonPlay _buttonPlay;
    
    
    private void Awake()
    {
         Hide();

    }


    public void Display()
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        var buttonPlay = transform.Find("ButtonPlay") ?? throw new ArgumentException("ButtonPlay is not be null");
        buttonPlay.gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        foreach (Transform child in transform.parent)
        {
            child.gameObject.SetActive(false);
        }
    }
        
    
    
}
