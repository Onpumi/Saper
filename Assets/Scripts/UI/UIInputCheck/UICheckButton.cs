using UnityEngine;
using  UnityEngine.UI;

public class UICheckButton : MonoBehaviour
{
    [SerializeField] private Sprite _spriteCheckOn;
    [SerializeField] private Sprite _spriteCheckOff;
    private Image _image;

    public void SetSprite(bool ChangeValue)
    {
        _image ??= GetComponent<Image>();
        if (ChangeValue)
        {
            _image.sprite = _spriteCheckOn;
        }
        else
        {
            _image.sprite = _spriteCheckOff;
        }

    }
}
