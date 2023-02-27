using System;
using UnityEngine;
using UnityEngine.UI;

public class BrickView : MonoBehaviour, IBrickView
{
    private void OnEnable() => transform.gameObject.SetActive(true);
    private void OnDisable() => transform.gameObject.SetActive(false);
    public float GetWidth() => GetComponent<Image>().sprite.rect.width;
    public float GetHeight() => GetComponent<Image>().sprite.rect.height;
    public Transform GetTransform() => transform;
    
}
