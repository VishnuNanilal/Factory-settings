using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProductTriggerable : MonoBehaviour
{
    protected void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag != "Product") return;

        OnProductEnter(other.gameObject);
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Product") return;

        OnProductExit(other.gameObject);
    }

    protected abstract void OnProductEnter(GameObject other);
    protected abstract void OnProductExit(GameObject other);
}
