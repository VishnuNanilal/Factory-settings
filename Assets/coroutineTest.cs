using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutineTest : MonoBehaviour
{
    private void Start() {
        StartCoroutine(TestFunction());
    }

    IEnumerator TestFunction()
    {
        print("1");

        yield return StartCoroutine(CoRoutine1());
        print("6");
    }

    IEnumerator CoRoutine1()
    {
        print("2");
        yield return new WaitForSeconds(3f);
        print("3");
        
        while(true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                break;
            }
                

            print("4");
            yield return null;
        }
        print("5");
    }
}
