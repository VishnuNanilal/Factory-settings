using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSetup : MonoBehaviour
{
    public Size size;
    public float Hue,Sat,Val;
    
    public enum Size
    {
        SMALL,
        MEDIUM,
        LARGE
    }

    public void PaintColor()
    {
        GetComponent<Renderer>().material.color = GetRandomColor();
    }

    Color GetRandomColor()
    {
        Hue = Random.Range(0f, 1f);
        Sat = GameManager.productColorSaturation;
        Val = GameManager.productColorValue;

        return Color.HSVToRGB(Hue, Sat, Val);
    }
}
