using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSystem : MonoBehaviour
{
    [SerializeField] Transform startPoint = null;
    [SerializeField] float beltSpeed = 1f;

    private void OnCollisionEnter(Collision other) 
    {
        if(other.collider.tag == "Product")
        {
            other.transform.position += transform.forward*beltSpeed*Time.deltaTime;
        }    
    }
} 
