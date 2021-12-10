using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistency : MonoBehaviour
{
   private void Awake() 
   {
       DontDestroyOnLoad(gameObject);   
   }
}
