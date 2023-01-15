using System;
using UnityEngine;
using UnityEngine.UI;

public class BrickView : MonoBehaviour, IBrickView
{
    private void OnEnable()
    {
        transform.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        transform.gameObject.SetActive(false);
    }

    private void Awake()
    {
        //Image img = GetComponent<Image>();
        //Color color = img.color;
        //color.a = 0.5f;
        //img.color = color;
    }
}
