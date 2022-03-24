using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int fungusTotal;
    public TMP_Text UIFungus;
    // Start is called before the first frame update
    void Start()
    {
        this.fungusTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GlobalVars.b_gamePaused)
        {
            case false:
                this.UIFungus.text = System.Convert.ToString(this.fungusTotal);
                break;
        }
    }

    public void AddFungus(int fungusToAdd)
    {
        this.fungusTotal += fungusToAdd;

    }
}
