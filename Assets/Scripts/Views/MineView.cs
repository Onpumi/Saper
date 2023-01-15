using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineView : MonoBehaviour, IMineView
{
    [SerializeField] private BoomView _prefabBoomView;
    [SerializeField] private FlagView _prefabFlagView;
    private void Awake()
    {
        transform.localScale = new Vector3(0.1f,0.1f,0.1f);
    }

}
