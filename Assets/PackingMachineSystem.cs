using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingMachineSystem : MonoBehaviour
{
    [SerializeField] Transform _Prefab_OutProduct;
    [SerializeField] Transform outputPoint;
    private int products;

    private void Awake() {
        products = 0;
    }

    public void AddToSystem(GameObject product)
    {
        Destroy(product);
        products++;
    }

    float productProcessTimer = 0f;
    private void Update() 
    {
        productProcessTimer += Time.deltaTime;
        if(productProcessTimer > GameManager.instance.ProductProductionRate)
        {          
            productProcessTimer = 0f;
            ProductProcess();
        }    
    }

    private void ProductProcess()
    {
        if(products != 0)
        {
            Instantiate(_Prefab_OutProduct, outputPoint.position, Quaternion.identity);
            products--;
        }
    }
}
