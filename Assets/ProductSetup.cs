using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSetup : MonoBehaviour
{
    public Color color;
    public Size size;
    public enum Size
    {
        SMALL,
        MEDIUM,
        LARGE
    }

    void Awake()
    {
        float R = Random.Range(0f, 1f);
        float G = Random.Range(0f, 1f);
        float B = Random.Range(0f, 1f);

        color = new Color(R,G,B);
        GetComponent<MeshRenderer>().material.color = color;
    }
}
