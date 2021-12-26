using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingMachineSystem : MonoBehaviour
{
    [SerializeField] enum PackedProductColors
    {
        RED,
        YELLOW,
        GREEN,
        BLUE,
        PURPLE
    }

    private Dictionary<PackedProductColors, int> hueColorDic = new Dictionary<PackedProductColors, int>();

    [SerializeField] Transform PackedProduct;
    [SerializeField] PackedProductColors packedProductColor;
    [SerializeField] Transform outputPoint;
    private int products;

    private void Awake() {
        hueColorDic.Add(PackedProductColors.RED, 5);
        hueColorDic.Add(PackedProductColors.YELLOW, 50);
        hueColorDic.Add(PackedProductColors.GREEN, 120);
        hueColorDic.Add(PackedProductColors.BLUE, 215);
        hueColorDic.Add(PackedProductColors.PURPLE, 300);

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
            Transform packedProduct = Instantiate(PackedProduct, outputPoint.position, Quaternion.identity);
            packedProduct.GetComponentInChildren<MeshRenderer>().material.color = new Color(hueColorDic[packedProductColor], GameManager.productColorSaturation, GameManager.productColorValue);
            products--;
        }
    }
}
