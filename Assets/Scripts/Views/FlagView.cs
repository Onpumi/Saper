using System;
using UnityEngine;
using UnityEngine.UI;

public class FlagView : MonoBehaviour, IFlagView
{
    [SerializeField] private Sprite _spriteError;
    private Image _image;
    public bool Value { get; private set; }

    private void Awake()
    {
        gameObject.SetActive(false);
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        
        Value = true;
    }

    private void OnDisable()
    {
        Value = false;
    }

    public float GetWidth() => _image.sprite.rect.width;

    public float GetHeight() => _image.sprite.rect.height;

    public void SetFlagError()
    {
        _image.sprite = _spriteError;
        transform.localScale = Vector3.one;
    }
    
    
    public Transform GetTransform() => transform;
}
