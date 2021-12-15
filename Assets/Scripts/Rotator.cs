using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public SorterType sorterType;
    [SerializeField] float speed = 10f;
    float timeToStopCoroutines = 10f;
    float timer = 10f;
    
    public enum SorterType
    {
        SIZE,
        COLOR
    }

    public void TurnToObject(Transform point)
    {
        StartCoroutine(Rotate(point));
    }

    public void TurnByAngle(float angle)
    {
        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }

    IEnumerator Rotate(Transform point)
    {
        while(true)
        {
            if(Mathf.Approximately(transform.rotation.y, point.rotation.y)) break;
            transform.rotation = Quaternion.Lerp(transform.rotation, point.rotation, Time.deltaTime*speed);
            yield return null;
        }
    }

    private void Update() 
    {
        if(timer < 0)
        {
            StopAllCoroutines();
            timer = timeToStopCoroutines;
            print(1);
        }    
        timer -= Time.deltaTime;
    }
}
