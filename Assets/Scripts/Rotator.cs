using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] float timeOfRotation = 3;

    protected GameObject controlledObject;

    //overload 1
    public IEnumerator TurnObjectTo(Quaternion point)
    {
        this.controlledObject = gameObject;
        StopAllCoroutines();
        yield return StartCoroutine(Rotate(point));
    }

    //overload 2
    public IEnumerator TurnObjectTo(GameObject controlledObject, Quaternion point)
    {
        this.controlledObject = controlledObject;
        StopAllCoroutines();
        yield return StartCoroutine(Rotate(point));
    }
    
    protected IEnumerator Rotate(Quaternion point)
    {
        float timer = 0;
        while(true)
        {   
            timer += Time.deltaTime;
            if(timer >= timeOfRotation)
                break;

            controlledObject.transform.rotation = Quaternion.Lerp(controlledObject.transform.rotation, point, speed*Time.deltaTime);
            yield return null;
        }
    }
}
