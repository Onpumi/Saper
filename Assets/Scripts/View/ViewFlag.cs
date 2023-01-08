using UnityEngine;

public class ViewFlag : MonoBehaviour
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
