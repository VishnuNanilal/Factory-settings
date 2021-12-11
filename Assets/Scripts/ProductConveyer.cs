using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductConveyer : MonoBehaviour
{
    [SerializeField] float beltSpeed = 1f;
    [SerializeField] Transform conveyer;

    void OnCollisionStay(Collision other) 
    {
        if(other.collider.tag == "Product")
        {
            other.transform.position += conveyer.transform.forward * beltSpeed * Time.deltaTime;
        }
    }
}
