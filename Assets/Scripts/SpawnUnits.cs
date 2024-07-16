using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnits : MonoBehaviour
{
    [SerializeField] Transform spawnPosition = null;
    float spawnTime;

    GameObject currentUnit;

    private void Awake() 
    {
        spawnTime = GameManager.instance.ProductProductionRate;
    }

    private void Start() {
        StartCoroutine(StartSpawn());
    }

    void RunSpawnFactory()
    {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        if(!GameManager.isFactoryWorking) yield return null;

        while(true)
        {
            currentUnit = GameManager.instance.spawnObjectList[Random.Range(0, GameManager.instance.spawnObjectList.Length)];
            Instantiate(currentUnit, spawnPosition);

            yield return new WaitForSeconds(spawnTime);
        }
    }

    //To stop production
    private void StopSpawnFactory()
    {
        StopAllCoroutines();
    }
}
