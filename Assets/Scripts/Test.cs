using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    void Start()
    {
        
        transform.SetAsLastSibling();

        Color color1 = new Color(0.6f,0,0,1);
        Color color2 = new Color(0.0f,0,1, 1);
        Color color = color1 + color2;

        color = color - color2;

        GetComponent<Image>().color = color;

    }

   
}
