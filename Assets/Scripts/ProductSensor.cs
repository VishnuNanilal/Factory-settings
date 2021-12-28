using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSensor : MonoBehaviour
{
    [SerializeField] SorterType sorterType;
    [SerializeField] Rotator[] turnTable;
    [SerializeField] Transform[] turnPoints;
    [SerializeField] float maxDistance = 10f;

    public enum SorterType
    {
        SIZE,
        COLOR
    }

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
            if(ps.Hue > .9445f || ps.Hue < .0834) //Red-Orange
                turnTable[0].TurnObjectTo(turnPoints[0].localEulerAngles);
            else if(ps.Hue >= .0834f && ps.Hue < 0.1945f) //yellow
                turnTable[1].TurnObjectTo(turnPoints[1].localEulerAngles);
            else if(ps.Hue >= .1945f && ps.Hue < .47223f) //Green
                turnTable[2].TurnObjectTo(turnPoints[2].localEulerAngles);
            else if (ps.Hue >= .47223f && ps.Hue < .72334f)
                turnTable[3].TurnObjectTo(turnPoints[3].localEulerAngles); //Blue
            else
                turnTable[4].TurnObjectTo(turnPoints[4].localEulerAngles); //Pink
        }
        else
        {
            if(ps.size == ProductSetup.Size.LARGE)
                turnTable[0].TurnObjectTo(turnPoints[0].localEulerAngles);
            else if (ps.size == ProductSetup.Size.MEDIUM)
                turnTable[0].TurnObjectTo(turnPoints[1].localEulerAngles);
            else 
                turnTable[0].TurnObjectTo(turnPoints[2].localEulerAngles);
        }
    }

    public void ResetRotation()
    {
        for (int i = 0; i < turnTable.Length; i++)
        {
            turnTable[i].TurnObjectTo(originalRotation.localEulerAngles);
        }
    }
}
