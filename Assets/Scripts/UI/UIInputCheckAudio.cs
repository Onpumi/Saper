using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class UIInputCheckAudio : SerializedMonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private Sounds _sounds;
    [SerializeField] private TypesAudio _typesAudio;
    [SerializeField] private Sprite _spriteCheckOn;
    [SerializeField] private Sprite _spriteCheckOff;
    [SerializeField] private Object obj;

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
        IsCheckOn = _gameState.AudioData.GetValue(_typesAudio);
        Display();
    }
    
    public void OnPointerDown(PointerEventData eventData )
    {
    }
    
    public void OnPointerUp(PointerEventData eventData )
    {
        IsCheckOn = !IsCheckOn;
        _gameState.AudioData.SetupValue(_typesAudio,IsCheckOn);
        Display();
    }


    private void Display()
    {
        _image.sprite = (IsCheckOn) ? (_spriteCheckOn) : (_spriteCheckOff);
    }
    
    


}
