using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class UIInputCheck : SerializedMonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private Sounds _sounds;
    [SerializeField] private TypeSave _typeSave;
    [SerializeField] private Sprite _spriteCheckOn;
    [SerializeField] private Sprite _spriteCheckOff;
    [SerializeField] private ISaveObject _saveObject;
    private AudioData _audioData;
    private Image _image;
    private ISettings _settings;
    public bool IsCheckOn { get; private set;  }

    private void Awake()
    { 
        _image = GetComponent<Image>();
    }

    public void Start()
    {
        IsCheckOn = _gameState.AudioData.GetValue(_typeSave);
        Display();
    }
    
    public void OnPointerDown(PointerEventData eventData )
    {
    }
    
    public void OnPointerUp(PointerEventData eventData )
    {
        IsCheckOn = !IsCheckOn;
        _gameState.AudioData.SetupValue(_typeSave,IsCheckOn);
        
        //_sounds.SetResolveSound(_soundType, IsCheckOn );
        //_settings.Save( IsCheckOn );
        Display();
        
    }


    private void Display()
    {
        _image.sprite = (IsCheckOn) ? (_spriteCheckOn) : (_spriteCheckOff);
    }
    
    


}
