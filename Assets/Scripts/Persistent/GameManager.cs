using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float ProductProductionRate = 3.5f;

    public GameObject[] spawnObjectList;

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
    }
}
