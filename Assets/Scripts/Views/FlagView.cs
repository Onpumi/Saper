using UnityEngine;

public class FlagView : MonoBehaviour, IFlagView
{
    public bool Value { get; private set; }
    private void OnEnable()
    {
        Value = true;
    }

    private void OnDisable()
    {
        Value = false;
    }
}
