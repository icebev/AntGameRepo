using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{

    [SerializeField] private BuildingTypeSO storedBuildingSO;
    [SerializeField] private GameObject buttonBackground;

    private BuildingTypeSO activeBuildingType;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0f;
            Debug.Log(mouseWorldPosition);

            if (this.activeBuildingType != null)
            {
                Instantiate(this.activeBuildingType.prefab, mouseWorldPosition, Quaternion.identity);
            }


        }
    }

    public void SelectHouse()
    {
        this.buttonBackground.GetComponent<Outline>().effectColor = new Color(1, 0.92f, 0.016f, 1);
        this.activeBuildingType = this.storedBuildingSO;
    }
}
