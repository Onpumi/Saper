using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputCheckScreen : UIInputCheck
{
    [SerializeField] private TypesScreen _typesScreen;
    
    private void Start()
    {
       IsCheckOn = GameState.DataSetting.ScreenData.GetValue(_typesScreen);
       Display();
    }
    
    public override void OnPointerUp(PointerEventData eventData )
    {
        base.OnPointerUp(eventData);
        GameState.DataSetting.ScreenData.SetupValue(_typesScreen,IsCheckOn);
        GameState.DataSetting.SetScreen(_typesScreen, IsCheckOn);
    }


}