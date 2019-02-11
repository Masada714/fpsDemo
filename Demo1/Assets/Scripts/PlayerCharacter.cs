using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 5.0f;
        currentHealth = maxHealth;
    }
    public void Hurt(int damage)
    {
        currentHealth -= damage;
        float reduceHealth = currentHealth / maxHealth;
        
        healthBar.transform.localScale = new Vector3(reduceHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
