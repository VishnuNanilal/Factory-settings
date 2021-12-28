using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProduct : ProductTriggerable
{
    ProductSensor ps;

    private void Awake() 
    {
        ps = GetComponentInParent<ProductSensor>();    
    }
    protected override void OnProductEnter(GameObject other)
    {
        ps.ResetRotation();
    }

    protected override void OnProductExit(GameObject other)
    {
        //empty
    }
}
