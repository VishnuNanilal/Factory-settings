using System;
using System.Collections;
using UnityEngine;

public class ContainerSystem : MonoBehaviour
{
    [SerializeField] Transform lid;
    [SerializeField] Transform openRotation;
    Vector3 originalRotation;
    
    [Space]
    [SerializeField] int ContainerCapacity = 10;
    [SerializeField] float openSpeed = 1f;
    [SerializeField] float stayOpenedTime = 5f;
    private float massCount = 0f;
    
    private void Start() {
        originalRotation = lid.localEulerAngles;
        //StartCoroutine(OpenLid());
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
            if(Mathf.Approximately ((int)lid.localEulerAngles.z, (int)openRotation.localEulerAngles.z)) 
            {
                lid.localEulerAngles = openRotation.localEulerAngles;
                break;
            }
            lid.localEulerAngles = Vector3.Lerp(lid.localEulerAngles, openRotation.localEulerAngles, Time.deltaTime * openSpeed);
            yield return null;
        }      
        StartCoroutine(CloseLid());
    }

    IEnumerator CloseLid()
    {
        StopCoroutine(OpenLid());
        float timer = 0f;
        
        while (true)
        {
            timer += Time.deltaTime;
            if (timer > stayOpenedTime)
            {
                if (Mathf.Approximately((int)lid.localEulerAngles.z, (int)originalRotation.z))
                {
                    lid.localEulerAngles = originalRotation;
                    break;
                } 
                lid.localEulerAngles = Vector3.Lerp(lid.localEulerAngles, originalRotation, Time.deltaTime * openSpeed);
                yield return null;
            }
            else
            {
                yield return null;
            }
        }
        print("Rotation back to default");
        StopAllCoroutines();
    }
}
