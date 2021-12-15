using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProduct : MonoBehaviour
{
    public event Action ProductTriggerEvent;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag != "Product") return;
        ProductTriggerEvent();
    }
}
