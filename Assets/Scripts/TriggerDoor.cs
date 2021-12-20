using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : ProductTriggerable
{
    [SerializeField] MoveToPoint[] controlledDoors;

    protected override void OnProductEnterTrigger(GameObject other)
    {
        if (gameObject.name != "Exit Door") return;
        foreach (MoveToPoint door in controlledDoors)
        {
            door.OpenDoor();
        }
    }

    protected override void OnProductExitTrigger(GameObject other)
    {
        if (gameObject.name != "Enter Door") return;
        foreach (MoveToPoint door in controlledDoors)
        {
            door.CloseDoor(other);
        }
    }
}