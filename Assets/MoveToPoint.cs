using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    [SerializeField] Transform targetPoint = null;
    [SerializeField] float doorSpeed;
    Vector3 originalPosition;

    GameObject currentProduct = null;

    private void Awake() {
        originalPosition = transform.position;
    }

    public void OpenDoor()
    {   
        StopAllCoroutines();
        StartCoroutine(OpenDoorCOR());
    }

    public void CloseDoor(GameObject product)
    {      
        currentProduct = product;
        StopAllCoroutines();
        StartCoroutine(CloseDoorCOR());
    }

    IEnumerator CloseDoorCOR()
    {
        while(true)
        {
            if(Mathf.Approximately(transform.position.y, targetPoint.position.y)) break;
            transform.position = Vector3.Lerp(transform.position, targetPoint.position, doorSpeed*Time.deltaTime);
            yield return null;
        }

        currentProduct.GetComponent<MeshRenderer>().material.color = GetRandomColor();

        print("Coroutine Stopped");
        StopAllCoroutines();
    }

    IEnumerator OpenDoorCOR()
    {
        while (true)
        {
            if(Mathf.Approximately(transform.position.y, originalPosition.y)) break;
            transform.position = Vector3.Lerp(transform.position, originalPosition, doorSpeed*Time.deltaTime);
            yield return null;
        }
        print("Coroutine Stopped");
        StopAllCoroutines();
    }

    Color GetRandomColor()
    {
        ProductSetup ps = currentProduct.GetComponent<ProductSetup>();
        float R = Random.Range(0f, .75f);
        ps.R = R;
        float G = Random.Range(0f, .75f);
        ps.G = G;
        float B = Random.Range(0f, .75f);
        ps.B = B;

        return new Color(R, G, B);
    }
}
