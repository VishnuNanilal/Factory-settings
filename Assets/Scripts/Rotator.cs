using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] protected float speed = 2f;

    protected GameObject controlledObject;

    //overload 1
    public IEnumerator TurnObjectTo(Vector3 point)
    {
        this.controlledObject = gameObject;
        StopAllCoroutines();
        yield return StartCoroutine(Rotate(point));
    }

    //overload 2
    public IEnumerator TurnObjectTo(GameObject controlledObject, Vector3 point)
    {
        this.controlledObject = controlledObject;
        StopAllCoroutines();
        yield return StartCoroutine(Rotate(point));
    }
    
    protected IEnumerator Rotate(Vector3 point)
    {
        while(true)
        {
            if(Mathf.Approximately((int)controlledObject.transform.localEulerAngles.y, (int)point.y)) break;
            controlledObject.transform.localEulerAngles = Vector3.Lerp(controlledObject.transform.localEulerAngles, point, Time.deltaTime*speed);
            yield return null;
        }
    }
}
