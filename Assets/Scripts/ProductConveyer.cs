using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductConveyer : ProductTriggerable
{
    [SerializeField] float beltSpeed = 1f;
    [SerializeField] Transform conveyer;

    protected override void OnProductEnterTrigger(GameObject other)
    {
        other.transform.position += conveyer.transform.forward * beltSpeed * Time.deltaTime;
    }

    protected override void OnProductExitTrigger(GameObject other)
    {
        //empty
    }
}
