using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public SorterType sorterType;
    [SerializeField] float speed = 10f;
    
    public enum SorterType
    {
        SIZE,
        COLOR
    }

    public void TurnToObject(Transform point)
    {
        StartCoroutine(Rotate(point));
    }

    IEnumerator Rotate(Transform point)
    {
        print("Coroutine started");
        while(!Mathf.Approximately(transform.rotation.y, point.rotation.y))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, point.rotation, Time.deltaTime*speed);
            print(transform.rotation);
            yield return null;
        }
        StopAllCoroutines();
    }
}
