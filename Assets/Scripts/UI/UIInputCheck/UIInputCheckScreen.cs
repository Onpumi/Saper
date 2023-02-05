using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputCheckScreen : UIInputCheck
{
    [SerializeField] private TypesScreen _typesScreen;
    
    private void Start()
    {
       IsCheckOn = GameField.DataSetting.ScreenData.GetValue(_typesScreen);
       Display();
    }
    
    public override void OnPointerUp(PointerEventData eventData )
    {
        base.OnPointerUp(eventData);
        GameField.DataSetting.ScreenData.SetupValue(_typesScreen,IsCheckOn);
        GameField.DataSetting.SetScreen(_typesScreen, IsCheckOn);
    }


}