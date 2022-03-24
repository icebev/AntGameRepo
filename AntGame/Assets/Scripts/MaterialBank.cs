using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBank : MonoBehaviour
{
    public Material _Neutral;
    public Material _Enemy;
    public Material _Highlighted;
    public Material _Selected;

    public static Material Neutral;
    public static Material Enemy;
    public static Material Highlighted;
    public static Material Selected;

    // Start is called before the first frame update
    void Start()
    {
        MaterialBank.Neutral = this._Neutral;
        MaterialBank.Enemy = this._Enemy;
        MaterialBank.Highlighted = this._Highlighted;
        MaterialBank.Selected = this._Selected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
