using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoom : MonoBehaviour
{
    public float zoomSpeed = 5f;      
    public float minZoom = 3f;        
    public float maxZoom = 10f;        
    public float smoothSpeed = 10f;    

    private Camera cam;
    private float targetZoom;

    void Start()
    {
        cam = GetComponent<Camera>();
        targetZoom = cam.orthographicSize;
    }

    void Update()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData * zoomSpeed;

        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * smoothSpeed);
    }
}