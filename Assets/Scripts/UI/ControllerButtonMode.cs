
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//public class ControllerButtonMode : MonoBehaviour, IPointerDownHandler, IUI
public class ControllerButtonMode : UIBase, IPointerDownHandler
{
    [SerializeField] private Transform _uiFlag;
    [SerializeField] private Transform _uiMine;
    public ButtonMode Mode { get; private set; }
    
    private void Awake()
    {
        Mode = ButtonMode.Mine;
        Display();
        gameObject.SetActive(false);
    }

    public void OnPointerDown( PointerEventData eventData )
    {
        SetModePlay();
    }
    
    private void Display()
    {
        if ( Mode == ButtonMode.Flag )
        {
            ExchangeScaleUI(_uiFlag, _uiMine);
        }
        else if ( Mode == ButtonMode.Mine )
        {
            ExchangeScaleUI(_uiMine, _uiFlag);
        }
    }

    private void SetModePlay()
    {
        Mode = (Mode == ButtonMode.Mine) ? (ButtonMode.Flag) : (ButtonMode.Mine);
        ReplacingIndexesUI(_uiFlag.transform, _uiMine.transform );
        Display();
    }

    private void ReplacingIndexesUI( Transform transform1, Transform transform2)
    {
        var bufferIndex = transform2.GetSiblingIndex();
        transform2.SetSiblingIndex(transform1.GetSiblingIndex());
        transform1.SetSiblingIndex(bufferIndex);
    }

    private void ExchangeScaleUI( Transform transform1, Transform transform2 )
    {
        SetScaleUI( transform1, RectTransform.Edge.Left, RectTransform.Edge.Bottom, 1f );
        SetScaleUI( transform2, RectTransform.Edge.Right, RectTransform.Edge.Top, 0.5f );
    }

    private void SetScaleUI( Transform transformUI, RectTransform.Edge edge1, RectTransform.Edge edge2, float scale)
    {
        Image image = transformUI.GetComponent<Image>();
        RectTransform rectTransform = transformUI.GetComponent<RectTransform>();
        rectTransform.SetInsetAndSizeFromParentEdge(edge1, 0,   image.sprite.rect.width * scale);
        rectTransform.SetInsetAndSizeFromParentEdge(edge2, 0, image.sprite.rect.width * scale);
    }

    
    
}

public enum ButtonMode
{
    Mine,
    Flag
}