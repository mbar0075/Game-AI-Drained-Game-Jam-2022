using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [Header ("Player position")]
    //Variable to hold player position
    [SerializeField] private Transform player;

    [Header ("Zoom Factor and Zoom Speed")]
    //Variables to hold camera zoomfactor and zoomspeed
    [SerializeField] float zoomFactor = 4.0f;
    [SerializeField] float zoomSpeed = 5.0f;

    private float originalSize = 0f;
    private Camera thisCamera;

    // Use this for initialisation
    private void Start()
    {   
        //Getting Camera
        thisCamera = GetComponent<Camera>();
        originalSize = thisCamera.orthographicSize;
    }

    // Update is called once per frame
    private void Update()
    {   
        //Zooming out
        float targetSize = originalSize * zoomFactor;
        if (targetSize != thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
        }
        //Transforming the camera to the position of the player
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    //Setting Zoom factor
    private void SetZoom(float zoomFactor)
    {
        this.zoomFactor = zoomFactor;
    }
}