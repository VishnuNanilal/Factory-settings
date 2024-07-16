using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform[] cameraPositions; // Array to hold the camera positions
    public GameObject activeCam;
    private int currentCameraIndex = 0; // To keep track of the current camera position

    void Start()
    {
        if (cameraPositions.Length > 0)
        {
            activeCam.transform.position = cameraPositions[0].position;
            activeCam.transform.rotation = cameraPositions[0].rotation;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Change this key to whatever you prefer
        {
            currentCameraIndex = (currentCameraIndex + 1) % cameraPositions.Length;
            activeCam.transform.position = cameraPositions[currentCameraIndex].position;
            activeCam.transform.rotation = cameraPositions[currentCameraIndex].rotation;
        }
    }
}

