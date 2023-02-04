using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputCheckSound : UIInputCheck
{
    [SerializeField] private TypesAudio _typesAudio;
    private AudioData _audioData;

    private void Start()
    {
        IsCheckOn = GameState.DataSetting.AudioData.GetValue(_typesAudio);
        Display();
    }
    
    public override void OnPointerUp(PointerEventData eventData )
    {
        base.OnPointerUp(eventData);
        GameState.DataSetting.AudioData.SetupValue(_typesAudio,IsCheckOn);
        
    }


}