using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPackTrigger : ProductTriggerable
{
    PackingMachineSystem pms;
    private void Awake()
    {
        pms = GetComponentInParent<PackingMachineSystem>();    
    }

    protected override void OnProductEnterTrigger(GameObject other)
    {
        pms.AddToSystem(other.gameObject);
    }

    protected override void OnProductExitTrigger(GameObject other)
    {
        //none
    }
}
