
using UnityEngine;
using UnityEngine.UI;

public class ScreenAdjusment
{
    private Screen _screen;
    private CanvasScaler _canvasScaler;
    private Transform _canvasParent;

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
    }
}
