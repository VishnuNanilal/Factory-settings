using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSensor : MonoBehaviour
{
    [SerializeField] Rotator[] turnTable;
    [SerializeField] Transform[] turnPoints;
    [SerializeField] float maxDistance = 10f; 
    [SerializeField] TriggerProduct[] productClearTrigger;
    Ray ray;
    
    [SerializeField] Transform originalRotation;

    private void Awake() {
        ray = new Ray(transform.position, transform.forward);
    }

    private void Start() 
    {
        if (productClearTrigger.Length != 0)
        {
            foreach(TriggerProduct tp in productClearTrigger)
            {
                tp.ProductTriggerEvent += TurnerReset;
            }
            TurnerReset();
        }
    }

    private void Update() 
    {
        RaycastHit hit;

        if(!Physics.Raycast(ray, out hit, maxDistance)||hit.collider.gameObject.tag != "Product") return;
        print("Sensor has detected product "+ hit.collider.name);
        ProductSetup ps = hit.collider.GetComponent<ProductSetup>();
        SetTargetPosition(ps);
    }

    void SetTargetPosition(ProductSetup ps)
    {
        if(turnTable[0].sorterType == Rotator.SorterType.COLOR)
        {
            if(ps.Hue > .9445f || ps.Hue < .0834) //Red-Orange
                turnTable[0].TurnToObject(turnPoints[0]);
            else if(ps.Hue >= .0834f && ps.Hue < 0.1945f) //yellow
                turnTable[1].TurnToObject(turnPoints[1]);
            else if(ps.Hue >= .1945f && ps.Hue < .47223f) //Green
                turnTable[2].TurnToObject(turnPoints[2]);
            else if (ps.Hue >= .47223f && ps.Hue < .72334f)
                turnTable[3].TurnToObject(turnPoints[3]); //Blue
            else
                turnTable[4].TurnToObject(turnPoints[4]); //Pink
        }
        else
        {
            if(ps.size == ProductSetup.Size.LARGE)
                turnTable[0].TurnToObject(turnPoints[0]);
            else if (ps.size == ProductSetup.Size.MEDIUM)
                turnTable[0].TurnToObject(turnPoints[1]);
            else 
                turnTable[0].TurnToObject(turnPoints[2]);
        }
    }

    private void TurnerReset()
    {
        for(int i = 0; i < turnTable.Length; i++)
        {
            turnTable[i].TurnToObject(originalRotation);
            //turnTable[i].transform.localRotation = originalRotation.localRotation;
        }
    }
}
