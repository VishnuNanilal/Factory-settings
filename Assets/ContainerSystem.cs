using System;
using System.Collections;
using UnityEngine;

public class ContainerSystem : MonoBehaviour
{
    [SerializeField] GameObject lid;
    [SerializeField] 
    Transform openTransform;
    Transform originalTransform;
    
    Rotator rotator;
    
    [Space][Space][Space]
    [SerializeField] int ContainerCapacity = 10;
    [SerializeField] float stayOpenedTime = 2f;
    private float massCount = 0f;


    private void Awake() {
        rotator = GetComponent<Rotator>();
        originalTransform = lid.transform;
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
            StartCoroutine(RotateLid());
        }      
    }

    IEnumerator RotateLid()
    {
        Quaternion openedRotation = openTransform.localRotation;
        Quaternion originalRotation = originalTransform.localRotation; 

        yield return rotator.TurnObjectTo(lid, openedRotation);

        yield return new WaitForSeconds(stayOpenedTime);

        yield return rotator.TurnObjectTo(lid, originalRotation);

        StopAllCoroutines();
    }
}
