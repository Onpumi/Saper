using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class ScalerRowMenu : MonoBehaviour
{

   private GridLayoutGroup _gridLayout;
   private RectTransform _rectTransform;


   private void Awake()
   {
       _rectTransform = GetComponent<RectTransform>() ?? throw new ArgumentException("RectTransform is null");
       _gridLayout = GetComponent<GridLayoutGroup>() ??  throw new ArgumentException("GridLayoutGroup is null"); ;
       var widthRow = _rectTransform.rect.width;
       _gridLayout.cellSize = new Vector2(widthRow * 0.9f, _gridLayout.cellSize.y);
       _gridLayout.childAlignment = TextAnchor.MiddleCenter;
       _gridLayout.constraint = GridLayoutGroup.Constraint.Flexible;
       _gridLayout.padding.left = 0;
       _gridLayout.padding.right = 0;
       _gridLayout.padding.top = 0;
   }
   

}
