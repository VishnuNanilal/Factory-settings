using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSensor : MonoBehaviour
{
    [SerializeField] Rotator turnTable;
    [SerializeField] Transform[] turnPoints;
    Ray ray;
    float maxDistance = 10f;

    private void Awake() {
        ray = new Ray(transform.position, Vector3.forward);
    }
    private void Update() 
    {
        RaycastHit hit;
        if(!Physics.Raycast(ray, out hit, maxDistance)||hit.collider.gameObject.tag == "Product") return;
    
        ProductSetup ps = hit.collider.GetComponent<ProductSetup>();
        SetTargetPosition(ps);
    }

    void SetTargetPosition(ProductSetup ps)
    {
        if(turnTable.sorterType == Rotator.SorterType.COLOR)
        {
            if(ps.R > ps.G && ps.R > ps.B)
                turnTable.TurnToObject(turnPoints[0]);
            else if(ps.G > ps.B)
                turnTable.TurnToObject(turnPoints[1]);
            else
                turnTable.TurnToObject(turnPoints[2]);
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
}
