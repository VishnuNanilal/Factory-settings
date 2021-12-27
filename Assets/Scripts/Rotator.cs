using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;

    protected GameObject controlledObject;
    private float timeToStopCoroutines = 10f;
    private float timer = 10f;
    

    //overload 1
    public IEnumerator TurnObjectTo(Transform point)
    {
        this.controlledObject = gameObject;
        StopAllCoroutines();
        yield return StartCoroutine(Rotate(point));
    }

    //overload2
    public IEnumerator TurnObjectTo(GameObject controlledObject, Transform point)
    {
        this.controlledObject = controlledObject;
        StopAllCoroutines();
        yield return StartCoroutine(Rotate(point));
    }
    
    protected IEnumerator Rotate(Transform point)
    {
        while(true)
        {
            if(Mathf.Approximately((int)controlledObject.transform.localEulerAngles.y, (int)point.localEulerAngles.y)) break;
            controlledObject.transform.localEulerAngles = Vector3.Lerp(controlledObject.transform.localEulerAngles, point.localEulerAngles, Time.deltaTime*speed);
            yield return null;
        }
    }

    private void Update() 
    {
        if(timer < 0)
        {
            StopAllCoroutines();
            timer = timeToStopCoroutines;
        }    
        timer -= Time.deltaTime;
    }
}
