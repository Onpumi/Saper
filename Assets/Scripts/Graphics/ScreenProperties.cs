
using UnityEngine;
using UnityEngine.UI;

public class ScreenAdjusment
{
    private Screen _screen;
    private CanvasScaler _canvasScaler;
    private readonly Transform _canvasParent;
    public readonly Vector2 ResolutionCanvas;
    public float RefPixelsPerUnit { get; private set; }
    
    public ScreenAdjusment( Transform canvasParent)
    {
        _canvasParent = canvasParent;
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
        _canvasScaler = _canvasParent.GetComponent<CanvasScaler>();
        _canvasScaler.referenceResolution = new Vector2(Screen.width,Screen.height);
        ResolutionCanvas = _canvasScaler.referenceResolution;
        RefPixelsPerUnit = _canvasScaler.referencePixelsPerUnit;
    }

   
    
    
    
}
