using System;
using System.Collections;
using UnityEngine;

public class ContainerSystem : MonoBehaviour
{
    [SerializeField] GameObject lid;
    [SerializeField] Transform openTransform;
    Vector3 originalRotation;
    
    Rotator rotator;
    
    [Space][Space][Space]
    [SerializeField] int ContainerCapacity = 10;
    [SerializeField] float stayOpenedTime = 5f;
    private float massCount = 0f;


    private void Awake() {
        rotator = GetComponent<Rotator>();
        originalRotation = lid.GetComponent<Transform>().localEulerAngles;
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
        Vector3 openedRotation = openTransform.localEulerAngles;

        yield return rotator.TurnObjectTo(lid, openedRotation);

        yield return new WaitForSeconds(stayOpenedTime);

        yield return rotator.TurnObjectTo(lid, originalRotation);

        StopAllCoroutines();
    }
}
