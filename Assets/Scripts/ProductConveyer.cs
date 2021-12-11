using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductConveyer : MonoBehaviour
{
    [SerializeField] float beltSpeed = 1f;
    [SerializeField] Transform parent;

    void OnCollisionStay(Collision other) 
    {
        if(other.collider.tag == "Product")
        {
            print("Box colliding");
            other.transform.position += parent.forward * beltSpeed * Time.deltaTime;
        }
    }
}
