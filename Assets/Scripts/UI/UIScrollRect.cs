using System;
using UnityEngine;
using UnityEngine.UI;


public class UIScrollRect : MonoBehaviour
{
    private ScrollRect _scrollRect;

    private void Awake()
    {
        _scrollRect = GetComponent<ScrollRect>() ?? throw new ArgumentException("ScrollRect is null!");

        

    }

    private void OnEnable()
    {
        _scrollRect.onValueChanged.AddListener(delegate(Vector2 arg0) { RectCallBack();});
    }
    
    private void OnDisable()
    {
        _scrollRect.onValueChanged.RemoveListener(delegate(Vector2 arg0) { RectCallBack();});
    }

    private void RectCallBack()
    {
       // Debug.Log(_scrollRect.content.position);
    //   Debug.Log(_scrollRect.verticalScrollbar.value);
    }
    
    
}
