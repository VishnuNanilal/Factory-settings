using System;
using System.Collections;
using UnityEngine;

public class ContainerSystem : MonoBehaviour
{
    [SerializeField] Transform lid;
    [SerializeField] int ContainerCapacity = 10;
    [SerializeField] float openSpeed = 5f;
    [SerializeField] float lidOpenedTime = 5f;
    private float massCount = 0f;

    public float GetMassCount()
    {
        return massCount;
    }

    public void SetMassCount(float value)
    {
        massCount += value;
    }    

    private void Update() 
    {
        if(massCount >= ContainerCapacity)
        {
            StartCoroutine(OpenLid());    
            massCount = 0;
        }
            
    }

    IEnumerator OpenLid()
    {
        while (true)
        {   
            if(Mathf.Approximately(transform.rotation.z, 0)) break;
            lid.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x,transform.rotation.y,0), Time.deltaTime * openSpeed);
            yield return null;
        }      
        StartCoroutine(CloseLid());
    }

    IEnumerator CloseLid()
    {
        float timer = 0f;
        while(true)
        {
            timer += Time.deltaTime;
            if(timer<lidOpenedTime) continue;
            if (Mathf.Approximately(transform.rotation.z, -90)) break;
            lid.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90), Time.deltaTime * openSpeed);
            yield return null;
        }
        StopAllCoroutines();
    }
}
