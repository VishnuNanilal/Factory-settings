using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] MoveToPoint[] controlledDoors;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Product" || gameObject.name != "Exit Door") return;
        foreach(MoveToPoint door in controlledDoors)
        {
            door.OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Product" || gameObject.name != "Enter Door") return;
        foreach (MoveToPoint door in controlledDoors)
        {
            door.CloseDoor(other.gameObject);
        }
    }
}
