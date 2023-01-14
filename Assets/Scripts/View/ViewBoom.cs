using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBoom : MonoBehaviour
{
    private void Awake()
    {
        transform.SetAsLastSibling();
        transform.SetParent(transform.parent.parent);
        transform.position = transform.parent.position;
    }
}
