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

        currentProduct.GetComponent<ProductSetup>().PaintColor();

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
        float Hue = Random.Range(0f, 1f);
        ps.Hue = Hue;
        float Sat = .75f;
        ps.Sat = Sat;
        float Val = .5f;
        ps.Val = Val;

        return Color.HSVToRGB(Hue, Sat, Val);
    }
}
