using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public SorterType sorterType;
    
    public enum SorterType
    {
        SIZE,
        COLOR
    }

    public void TurnToObject(Transform point)
    {
        transform.LookAt(point);
    }
}
