using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInputCheckComplexity: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Transform _parent;
    private List<UIInputCheckComplexity> _buttons;
    private Image _image;

    private void Awake()
    {
        _parent = transform.parent;
        _buttons = new List<UIInputCheckComplexity>();
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        foreach (Transform child in _parent)
        {
            var button = child.GetComponent<UIInputCheckComplexity>();
            button.SetActive(false);
            _buttons.Add(button);
        }
        
        _buttons[0].SetActive(true); 
    }

    private void SetupButtons()
    {
        foreach (var button in _buttons)
        {
            if (button != this)
            {
                button.SetActive(false);
            }
            else
            {
                button.SetActive(true);
            }
        }
    }

    public void SetActive(bool value)
    {
            var color = _image.color;
            color.a = (value == false) ? 0.3f : 1f;
            _image.color = color;
    }
    
    public void OnPointerDown(PointerEventData eventData )
    {
      
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SetupButtons();
    }
 
}
