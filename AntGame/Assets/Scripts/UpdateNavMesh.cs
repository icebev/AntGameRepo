using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpdateNavMesh : MonoBehaviour
{
    NavMeshSurface2d navMeshScript;
    public NavMeshData data;

    public float updateInterval;
    private float timeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.navMeshScript = this.gameObject.GetComponent<NavMeshSurface2d>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GlobalVars.b_gamePaused)
        {
            case false:

                this.timeCounter += Time.deltaTime;

                if (this.timeCounter >= this.updateInterval)
                {
                    //StartCoroutine(RebuildNavMesh());
                    //this.navMeshScript.UpdateNavMesh(this.data);
                    this.timeCounter = 0;
                }
                break;
        }
    }

    public IEnumerator RebuildNavMesh()
    {
        yield return new WaitForEndOfFrame();
        this.navMeshScript.UpdateNavMesh(this.navMeshScript.navMeshData);

    }

    public void ManualUpdateOfNavMesh()
    {
        this.navMeshScript.UpdateNavMesh(this.navMeshScript.navMeshData);
    }

}