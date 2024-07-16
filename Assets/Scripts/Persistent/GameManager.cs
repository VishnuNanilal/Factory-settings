using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static bool isFactoryWorking = true;
    public float ProductProductionRate;

    public GameObject[] spawnObjectList;

    [HideInInspector]
    public const float productColorSaturation = .75f;
    [HideInInspector]
    public const float productColorValue = 1f;


    private void Awake() {
        if(instance!= null) 
        {
            print("trying multiple instantiation");
            return;
        }
        else
        {
            instance = this;
        }
        ProductProductionRate = 3.5f;
    }
}
