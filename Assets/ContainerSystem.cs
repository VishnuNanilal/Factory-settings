using System;
using System.Collections;
using UnityEngine;

public class ContainerSystem : MonoBehaviour
{
    [SerializeField] Transform lid;
    [SerializeField] Transform openRotation;
    Quaternion originalRotation;
    
    [Space]
    [SerializeField] int ContainerCapacity = 10;
    [SerializeField] float openSpeed = 5f;
    [SerializeField] float lidOpenedTime = 5f;
    private float massCount = 0f;
    
    private void Start() {
        originalRotation = lid.transform.rotation;
    }

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
            massCount = 0;
            StartCoroutine(OpenLid());    
        }      
    }

    IEnumerator OpenLid()
    {
        while (true)
        {   
            if(lid.localEulerAngles.z > 350) break;
            lid.localRotation = Quaternion.Lerp(lid.localRotation, openRotation.localRotation, Time.deltaTime * openSpeed);
            yield return null;
        }      
        StartCoroutine(CloseLid());
    }

    IEnumerator CloseLid()
    {
        StopCoroutine(OpenLid());
        float timer = 0f;

        while(true)
        {
            timer += Time.deltaTime;
            if(timer>lidOpenedTime)
            {
                if (lid.localEulerAngles.z < 0) break;
                lid.localRotation = Quaternion.Lerp(lid.localRotation, originalRotation, Time.deltaTime * openSpeed);
                yield return null;
            }
        }
        StopAllCoroutines();
    }
}
