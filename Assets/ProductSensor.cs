using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSensor : MonoBehaviour
{
    [SerializeField] Rotator turnTable;
    Ray ray;
    float maxDistance = 10f;

    private void Awake() {
        ray = new Ray(transform.position, Vector3.forward);
    }
    private void Update() {
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            if(hit.collider.gameObject.tag != "Product") return;

            turnTable.TurnToObject(hit.transform);
        }
    }
}
