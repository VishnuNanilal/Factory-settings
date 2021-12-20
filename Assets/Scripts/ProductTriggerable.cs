using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProductTriggerable : MonoBehaviour
{
    protected void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag != "Product") return;

        OnProductEnterTrigger(other.gameObject);
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Product") return;

        OnProductExitTrigger(other.gameObject);
    }

    protected abstract void OnProductEnterTrigger(GameObject other);
    protected abstract void OnProductExitTrigger(GameObject other);
}
