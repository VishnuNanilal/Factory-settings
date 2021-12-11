using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSystem : MonoBehaviour
{
    [SerializeField] Transform startPoint = null;
    [SerializeField] Rotator sorter;
    
    [HideInInspector]
    public Rotator.SorterType sorterType;

    private void Awake() {
        sorterType = sorter.sorterType;
    }
} 
