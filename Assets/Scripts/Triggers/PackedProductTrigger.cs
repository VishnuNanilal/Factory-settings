using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackedProductTrigger : MonoBehaviour
{
    StorageSystem storageSystem;

    private void Awake() {
     storageSystem = GetComponentInParent<StorageSystem>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PackedProduct")
        {
            storageSystem.AddPackedProduct();
        }    
    }
}
