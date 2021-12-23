using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingMachineSystem : MonoBehaviour
{
    [SerializeField] Transform _Prefab_OutProduct;
    [SerializeField] Transform outputPoint;
    private List<ProductSetup> products;

    private void Awake() {
        products = new List<ProductSetup>();
    }

    public void AddToList(ProductSetup product)
    {
        products.Add(product);
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
        if(products.Count != 0)
        {
            GameObject currentProduct = products[0].gameObject;
            products.RemoveAt(0);
            Destroy(currentProduct); 
        }

        Instantiate(_Prefab_OutProduct, outputPoint.position, Quaternion.identity);
    }


}
