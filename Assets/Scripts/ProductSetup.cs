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
}
