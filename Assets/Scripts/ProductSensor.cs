using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSensor : MonoBehaviour
{
    [SerializeField] Rotator turnTable;
    [SerializeField] Transform[] turnPoints;
    [SerializeField] float maxDistance = 10f; 
    Ray ray;

    private void Awake() {
        ray = new Ray(transform.position, transform.forward);
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
        if(turnTable.sorterType == Rotator.SorterType.COLOR)
        {
            if(ps.Hue < .2f)
                turnTable.TurnToObject(turnPoints[0]);
            else if(ps.Hue >= .2f && ps.Hue < .4f)
                turnTable.TurnToObject(turnPoints[1]);
            else if(ps.Hue >= .4f && ps.Hue < .6f)
                turnTable.TurnToObject(turnPoints[2]);
            else if (ps.Hue >= .6f && ps.Hue < .8f)
                turnTable.TurnToObject(turnPoints[3]);
            else
                turnTable.TurnToObject(turnPoints[4]);

        }
        else
        {
            if(ps.size == ProductSetup.Size.LARGE)
                turnTable.TurnToObject(turnPoints[0]);
            else if (ps.size == ProductSetup.Size.MEDIUM)
                turnTable.TurnToObject(turnPoints[1]);
            else 
                turnTable.TurnToObject(turnPoints[2]);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.forward * maxDistance;
        Gizmos.DrawRay(transform.position, direction);
    }
}
