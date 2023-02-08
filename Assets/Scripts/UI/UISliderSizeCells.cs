using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISliderSizeCells : UIBase
{

    private void Start() => Hide();

    public override void OpenMenuSettings() => Hide();

    public override void OpenMenuSizeCells() => Open();



}
