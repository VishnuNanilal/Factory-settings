using System;
using System.Collections;
using UnityEngine;

public class ContainerSystem : MonoBehaviour
{
    [SerializeField] GameObject lid;
    [SerializeField] Transform openRotation;
    Transform originalRotation;
    
    Rotator rotator;
    
    [Space][Space][Space]
    [SerializeField] int ContainerCapacity = 10;
    //[SerializeField] float openSpeed = 1f;
    [SerializeField] float stayOpenedTime = 5f;
    private float massCount = 0f;


    private void Awake() {
        rotator = GetComponent<Rotator>();
        originalRotation = transform;
        StartCoroutine(OpenLid());
        //originalRotation = lid.localEulerAngles;
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
        yield return rotator.TurnObjectTo(lid, openRotation);
        yield return new WaitForSeconds(stayOpenedTime);
        yield return StartCoroutine(CloseLid());
    }

    IEnumerator CloseLid()
    {
        yield return rotator.TurnObjectTo(lid, originalRotation);
        /*
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
        }*/
        StopAllCoroutines();
    }
}
