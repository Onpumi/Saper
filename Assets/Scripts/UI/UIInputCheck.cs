using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class UIInputCheck : SerializedMonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sounds _sounds;
    [SerializeField] private SoundType _soundType;
    [SerializeField] private Sprite _spriteCheckOn;
    [SerializeField] private Sprite _spriteCheckOff;
    [SerializeField] private ISaveObject _saveObject;
    private Image _image;
    private ISettings _settings;
    public bool IsCheckOn { get; private set;  }

    private void Awake()
    {
        IsCheckOn = true;
        _image = GetComponent<Image>();
        Display();
        _settings = new SettingSounds(_sounds, _soundType);
    }

    public void OnPointerDown(PointerEventData eventData )
    {
    }
    
    public void OnPointerUp(PointerEventData eventData )
    {
        IsCheckOn = !IsCheckOn;
        //_sounds.SetResolveSound(_soundType, IsCheckOn );
        _settings.Save( IsCheckOn );
        Display();
        
    }


    private void Display()
    {
        _image.sprite = (IsCheckOn) ? (_spriteCheckOn) : (_spriteCheckOff);
    }
    
    


}
