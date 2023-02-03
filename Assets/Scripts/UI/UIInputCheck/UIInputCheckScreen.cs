using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputCheckScreen : UIInputCheck
{
    //[SerializeField] private TypesScreenSetup _typesAudio;
    
    //private ScreenData _audioData;

    private void Start()
    {
       //IsCheckOn = GameState.AudioData.GetValue(_typesAudio);
        //Display();
    }
    
    public override void OnPointerUp(PointerEventData eventData )
    {
        base.OnPointerUp(eventData);
        //GameState.AudioData.SetupValue(_typesAudio,IsCheckOn);
    }


}