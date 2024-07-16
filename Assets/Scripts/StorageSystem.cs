using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageSystem : MonoBehaviour
{
    private int count = 0;

    public int Count => count;
    
    public void AddPackedProduct()
    {
        count++;
    }
}
