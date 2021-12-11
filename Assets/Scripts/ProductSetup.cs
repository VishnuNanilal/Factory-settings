using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSetup : MonoBehaviour
{
    public Color color;
    public Size size;
    public float R,G,B;
    
    public enum Size
    {
        SMALL,
        MEDIUM,
        LARGE
    }

    void Awake()
    {
        R = Random.Range(0f, 1f);
        G = Random.Range(0f, 1f);
        B = Random.Range(0f, 1f);

        color = new Color(R,G,B);
        GetComponent<MeshRenderer>().material.color = color;
    }
}
