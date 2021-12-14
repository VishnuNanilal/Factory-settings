using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSetup : MonoBehaviour
{
    public Color color;
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
        print(Hue);
    }

    Color GetRandomColor()
    {
        Hue = Random.Range(0f, 1f);
        Sat = .75f;
        Val = 1f;

        return Color.HSVToRGB(Hue, Sat, Val);
    }
}
