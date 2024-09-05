using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public Slider healthSlider;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = this.GetComponent<Health>().maxHealth;
        healthSlider.value = this.GetComponent<Health>().currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateDisplay()
    {
        healthSlider.value = this.GetComponent<Health>().currentHealth;
    }
}
