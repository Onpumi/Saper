
using Sirenix.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;


public class ControllerButtonMode : MonoBehaviour, IPointerDownHandler, IUI
{
    [SerializeField] private Transform _uiFlag;
    [SerializeField] private Transform _uiMine;
    [SerializeField] private float _scaleParent = 0.7f;
    [SerializeField] private float _scaleChild = 0.3f;
    

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
            SetRectUI(_uiFlag, _uiMine);
            
        }
        else if ( Mode == ButtonMode.Mine )
        {
            SetRectUI(_uiMine, _uiFlag);
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

    private void SetRectUI( Transform transform1, Transform transform2 )
    {

        Image image1 = transform1.GetComponent<Image>();
        RectTransform rectTransform1 = transform1.GetComponent<RectTransform>();
        rectTransform1.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, image1.sprite.rect.width);
        rectTransform1.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, image1.sprite.rect.width);
        
        Image image2 = transform2.GetComponent<Image>();
        RectTransform rectTransform2 = transform2.GetComponent<RectTransform>();
        rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0,   image2.sprite.rect.width / 2f);
        rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, image2.sprite.rect.width / 2f);

    }
    
    
    public void Lose() { }

    public void EnableForDisplay()
    {
        gameObject.SetActive(true);
    }
    public void OpenMenuSettings()
    {
       gameObject.SetActive(false);   
    }
}


public enum ButtonMode
{
    Mine,
    Flag
}