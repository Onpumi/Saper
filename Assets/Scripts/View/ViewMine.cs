using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewMine : MonoBehaviour
{
    [SerializeField] private ViewBoom _prefabViewBoom;
    [SerializeField] private ViewFlag _prefabViewFlag;
    private void Awake()
    {
        gameObject.SetActive(false);
        var index = transform.GetSiblingIndex();
     //   transform.SetSiblingIndex(--index);
    }

    public void InstantiateBoom()
    {
        var boom = Instantiate(_prefabViewBoom, transform.parent);
        boom.transform.localScale = Vector3.one * 5f;
        gameObject.SetActive(true);
    }
}
