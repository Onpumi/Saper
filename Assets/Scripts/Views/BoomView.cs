using UnityEngine;
using UnityEngine.UI;

public class BoomView : MonoBehaviour, IBoomView
{
    private void Awake()
    {
        //transform.localScale = 1f * transform.localScale;
        transform.SetParent(transform.parent.root);
        transform.SetAsLastSibling();
        var img = transform.GetComponent<Image>();
        Color color = img.color;
        color.a = 0.7f;
        img.color = color;
    }
}
