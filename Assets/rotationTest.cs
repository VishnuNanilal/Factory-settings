using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationTest : MonoBehaviour
{
    [SerializeField] Transform[] targetTransform;
    [SerializeField] float speed;
    Vector3 angle;  

    private Transform activeTransform;

    private void Start()
    {
        activeTransform = transform;
        //angle = targetTransform.position - transform.position; 
        //StartCoroutine(StartRotation());   
    }

    /*IEnumerator StartRotation()
    {
        float angle = Quaternion.Angle(transform.rotation, targetTransform.rotation);
        while(true)
        {
            if(Mathf.Approximately(transform.localEulerAngles.y, targetTransform.localEulerAngles.y)) break;
            transform.rotation *= Quaternion.AngleAxis(angle*Time.deltaTime, Vector3.up);
            yield return null;
        }
    }*/

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            activeTransform = targetTransform[0];
        }        
        if(Input.GetKeyDown(KeyCode.X))
        {
            activeTransform = targetTransform[1];
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            activeTransform = targetTransform[2];
        }


        //float deltaAngle = Mathf.Min(Quaternion.Angle(transform.rotation, activeTransform.rotation), Quaternion.Angle(activeTransform.rotation, transform.rotation));
        //float deltaAngle = Quaternion.Angle(transform.localRotation, activeTransform.localRotation);
        //transform.rotation *= Quaternion.AngleAxis(deltaAngle*speed*Time.deltaTime, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, activeTransform.rotation, .1f);
             

        
    }    
}
