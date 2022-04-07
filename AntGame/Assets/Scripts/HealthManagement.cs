using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagement : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    [SerializeField] private Slider healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.healthBar.value = NormalizeHealth();
    }

    private float NormalizeHealth()
    {
        return this.currentHealth / this.maxHealth;
    }
}
