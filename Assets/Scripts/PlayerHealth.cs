using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;


    public GameObject Explode;


    void Start()
    {
        
        maxHealth = PlayerPrefs.GetFloat("PlayerHealth");
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(Instantiate(Explode, transform.position, transform.rotation) as GameObject, 2);
            Camera.main.transform.parent = null;
            gameObject.SetActive(false);
        }
        PlayerPrefs.SetFloat("PlayerHealth", currentHealth);
    }

    public void NewRound()
    {
        maxHealth += 5;
        currentHealth = maxHealth;
        PlayerPrefs.SetFloat("PlayerHealth", currentHealth);
        PlayerPrefs.SetFloat("PlayerMaxHealth", currentHealth);
    }
}
