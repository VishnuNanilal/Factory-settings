using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductTrigger_Container : ProductTriggerable
{
    ContainerSystem CS;

    private void Awake() {
        CS = GetComponentInParent<ContainerSystem>();   
    }

    protected override void OnProductEnterTrigger(GameObject other)
    {
        CS.SetMassCount(other.GetComponent<Rigidbody>().mass);
    }

    protected override void OnProductExitTrigger(GameObject other)
    {
        throw new System.NotImplementedException();
    }
}
