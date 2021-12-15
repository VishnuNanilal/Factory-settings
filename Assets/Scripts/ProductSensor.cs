using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSensor : MonoBehaviour
{
    [SerializeField] Rotator[] turnTable;
    [SerializeField] Transform[] turnPoints;
    [SerializeField] float maxDistance = 10f; 
    [SerializeField] TriggerProduct productClearTrigger;
    Ray ray;

    private void Awake() {
        ray = new Ray(transform.position, transform.forward);
    }

    private void Start() 
    {
        if (productClearTrigger != null)
        {
            productClearTrigger.ProductTriggerEvent += TurnerReset;
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
            if(ps.Hue < .2f)
                turnTable[0].TurnByAngle(90);
            else if(ps.Hue >= .2f && ps.Hue < .4f)
                turnTable[1].TurnByAngle(90);
            else if(ps.Hue >= .4f && ps.Hue < .6f)
                turnTable[2].TurnByAngle(90);
            else if (ps.Hue >= .6f && ps.Hue < .8f)
                turnTable[3].TurnByAngle(90);
            else
                turnTable[4].TurnByAngle(90);

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
        foreach(Rotator rotator in turnTable)
        {
            rotator.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.forward * maxDistance;
        Gizmos.DrawRay(transform.position, direction);
    }
}
