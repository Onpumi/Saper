using UnityEngine;
using UnityEngine.EventSystems;

   public class UIInputCheckGame : UIInputCheck
{
    [SerializeField] private GameState _gameState;
    [SerializeField] private TypesOption TypeOption;


    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if( TypeOption == TypesOption.SizeCells )
          _gameState.OpenMenuSizeCells();
        else if (TypeOption == TypesOption.Vibration)
        {
            Debug.Log("Set Vibro");
            base.OnPointerUp(eventData);
           // GameField.DataSetting.ScreenData.SetupValue(_typesScreen,IsCheckOn);
            //GameField.DataSetting.SetScreen(_typesScreen, IsCheckOn);
        }
        else if (TypeOption == TypesOption.GenerationMinesAfterFirstStep)
        {
            base.OnPointerUp(eventData);
        }
    }
    
}
