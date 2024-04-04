using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject GridManager;
    [SerializeField] private float zoomStep, minCamSize, maxCamSize;
    [SerializeField] private float minSizeX, maxSizeX, minSizeY, maxSizeY;
    [SerializeField] private GameObject Block;
    private Vector3 dragOrigin;


    private void Awake()
    {
        minSizeX = GridManager.transform.position.x -3;
        maxSizeX = GridManager.GetComponent<GridManager>().GetWidth()+3;
        minSizeY = GridManager.transform.position.y-3;
        maxSizeY = GridManager.GetComponent<GridManager>().GetHeight()+3;

    }
    private void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        if (!Block.GetComponent<SideBlock>().GetBlocked())
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
        minSizeX = GridManager.transform.position.x - 4;
        maxSizeX = GridManager.GetComponent<GridManager>().GetWidth() + 3;
        minSizeY = GridManager.transform.position.y - 4;
        maxSizeY = GridManager.GetComponent<GridManager>().GetHeight() + 3;
    }
}
