using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AntController : MonoBehaviour
{

    public GameObject activeAnt;
    public TunnelToLocation activeAntMoveComponent;
    public SpriteRenderer activeAntSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);


                if (hit.collider.gameObject.CompareTag("WorkerAnt"))
                {
                    if (this.activeAnt != null)
                    {
                        this.activeAntSpriteRenderer.material = MaterialBank.Neutral;
                        this.activeAntMoveComponent.isSelected = false;
                    }

                    this.activeAnt = hit.collider.gameObject;
                    this.activeAntMoveComponent = this.activeAnt.GetComponent<TunnelToLocation>();
                    this.activeAntMoveComponent.isSelected = true;
                    this.activeAntSpriteRenderer = this.activeAnt.GetComponent<SpriteRenderer>();
                    this.activeAntSpriteRenderer.material = MaterialBank.Selected;
                    //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                }
            }
        }

        if (this.activeAnt != null && Input.GetButtonDown("Fire2") && !EventSystem.current.IsPointerOverGameObject())
        {
            this.activeAntMoveComponent.targetLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.activeAntMoveComponent.targetLocation.z = 0;

        }
    }


}
