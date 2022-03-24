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
