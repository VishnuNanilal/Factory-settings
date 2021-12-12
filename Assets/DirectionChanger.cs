using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    Transform targetTransform;

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag != "Product") return;


    }
}

