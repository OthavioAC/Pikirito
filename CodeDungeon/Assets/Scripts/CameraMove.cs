using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.Collections.AllocatorManager;

public class CameraMove : MonoBehaviour 
{
    [SerializeField] private Camera cam;
    [SerializeField] private float zoomStep, minCamSize, maxCamSize;
    [SerializeField] private float minSizeX, maxSizeX, minSizeY, maxSizeY;
    [SerializeField] private int size = 250;
    private Vector3 dragOrigin;

    public GameObject foodBlock;
    public GameObject foodBuyBlock;
    public GameObject banhoBlock;

    private void Awake()
    {
        minSizeX = -size;
        maxSizeX = size;
        minSizeY = -size;
        maxSizeY = size;

    }

    private void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {

        if (!foodBlock.GetComponent<GiveFood>().GetBlocked()
            && !foodBuyBlock.GetComponent<BuyFood>().GetBlocked() 
            && !banhoBlock.GetComponent<Banho>().GetBlocked())
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 differ = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
                cam.transform.position = ClampCamera(cam.transform.position + differ);
            }
            if (Input.mouseScrollDelta.y > 0)
            {
                ZoomIn();
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                ZoomOut();
            }
        }
    }
    public void ZoomIn()
    {
        float newSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize,minCamSize, maxCamSize);
        cam.transform.position = ClampCamera(cam.transform.position);
    }
    public void ZoomOut()
    {
        float newSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
        cam.transform.position = ClampCamera(cam.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = minSizeX + camWidth;
        float maxX = maxSizeX - camWidth;
        float minY = minSizeY + camHeight;
        float maxY = maxSizeY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY,targetPosition.z);
    }

    public void Restart()
    {
        minSizeX = -size;
        maxSizeX = size;
        minSizeY = -size;
        maxSizeY = size;
    }


    private void OnMouseDown()
    {
        
    }
}
