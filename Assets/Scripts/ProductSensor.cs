using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSensor : MonoBehaviour
{
    public enum SorterType
    {
        SIZE,
        COLOR
    }

    [SerializeField] SorterType sorterType;
    [SerializeField] Rotator[] turnTable;
    [SerializeField] Transform[] turnPoints;
    [SerializeField] float maxDistance = 10f;

    Ray ray;
    
    [SerializeField] Transform originalRotation;

    private void Awake() {
        ray = new Ray(transform.position, transform.forward);
    }

    private void Update() 
    {
        RaycastHit hit;

        if(!Physics.Raycast(ray, out hit, maxDistance)||hit.collider.gameObject.tag != "Product") return;
        ProductSetup ps = hit.collider.GetComponent<ProductSetup>();
        SetTargetPosition(ps);
    }

    void SetTargetPosition(ProductSetup ps)
    {
        if(sorterType == SorterType.COLOR)
        {
            if(ps.Hue > .9445f || ps.Hue < .0834)          //Red-Orange
                StartCoroutine(turnTable[0].TurnObjectTo(turnPoints[0].rotation));
            else if(ps.Hue >= .0834f && ps.Hue < 0.1945f)  //yellow
                StartCoroutine(turnTable[1].TurnObjectTo(turnPoints[1].rotation));
            else if(ps.Hue >= .1945f && ps.Hue < .47223f)  //Green
                StartCoroutine(turnTable[2].TurnObjectTo(turnPoints[2].rotation));
            else if (ps.Hue >= .47223f && ps.Hue < .72334f) //Blue
                StartCoroutine(turnTable[3].TurnObjectTo(turnPoints[3].rotation));
            else                                            //Pink
                StartCoroutine(turnTable[4].TurnObjectTo(turnPoints[4].rotation)); 
        }
        else
        {
            if(ps.size == ProductSetup.Size.LARGE)
                StartCoroutine(turnTable[0].TurnObjectTo(turnPoints[0].rotation));
            else if (ps.size == ProductSetup.Size.MEDIUM)
                StartCoroutine(turnTable[0].TurnObjectTo(turnPoints[1].rotation));
            else
                StartCoroutine(turnTable[0].TurnObjectTo(turnPoints[2].rotation));
        }
    }

    public void ResetRotation()
    {
        for (int i = 0; i < turnTable.Length; i++)
        {
            StartCoroutine(turnTable[i].TurnObjectTo(originalRotation.rotation));
        }
    }
}
