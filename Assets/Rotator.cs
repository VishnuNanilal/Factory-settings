using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public void TurnToObject(Transform point)
    {
        transform.LookAt(point);
    }
}
