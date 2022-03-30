using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControls : MonoBehaviour
{
    private Camera playerCam;
    public float cameraZoomSpeed;
    public float minCameraSize;
    public float maxCameraSize;
    public float cameraMoveSpeed;

    public Vector2 GetMinCameraPos()
    {
        float minX = 2f + (16f / 9f) * this.playerCam.orthographicSize;
        float minY = this.playerCam.orthographicSize;
        Vector2 minPos = new Vector2(minX, minY);
        return minPos;
    }

    public Vector2 GetMaxCameraPos()
    {
        float maxX = 198f - (16f / 9f) * this.playerCam.orthographicSize;
        float maxY = 160f - this.playerCam.orthographicSize;
        Vector2 maxPos = new Vector2(maxX, maxY);
        return maxPos;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.playerCam = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        this.playerCam.orthographicSize -= Input.mouseScrollDelta.y * this.cameraZoomSpeed * Time.deltaTime;
        if (this.playerCam.orthographicSize > this.maxCameraSize)
        {
            this.playerCam.orthographicSize = this.maxCameraSize;
        }
        else if (this.playerCam.orthographicSize < this.minCameraSize)
        {
            this.playerCam.orthographicSize = this.minCameraSize;
        }

        if (this.IsPointerOverUIElement())
        {
            Debug.Log("UI element hover!");
            Vector3 moveTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            moveTarget.z = -10;

            this.playerCam.transform.position = Vector3.MoveTowards(this.playerCam.transform.position, moveTarget, this.cameraMoveSpeed * Time.deltaTime);
        }
        CheckCameraLimits();
    }

    private void CheckCameraLimits()
    {
        Vector3 temp = new Vector3(this.playerCam.transform.position.x, this.playerCam.transform.position.y, this.playerCam.transform.position.z);
        Vector2 camMax = GetMaxCameraPos();
        Vector2 camMin = GetMinCameraPos();
        // Limit Checks
        if (this.playerCam.transform.position.x > camMax.x)
        {
            temp.x = camMax.x;
        }
        else if (this.playerCam.transform.position.x < camMin.x)
        {
            temp.x = camMin.x;
        }

        if (this.playerCam.transform.position.y > camMax.y)
        {
            temp.y = camMax.y;
        }
        else if (this.playerCam.transform.position.y < camMin.y)
        {
            temp.y = camMin.y;
        }

        this.playerCam.transform.position = temp;
    }

    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }

    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.name == "UI")
                return true;

            if (curRaysastResult.gameObject.CompareTag("WorkerAnt"))
            {
                Debug.Log("Hovering Over Ant!");
            }
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }

}
