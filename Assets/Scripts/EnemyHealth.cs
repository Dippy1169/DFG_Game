using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float initialHealth = 10.0f;
    public float currentHealth;


    public GameObject Explode;


    void Start()
    {
        currentHealth = initialHealth;  
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {

            Destroy(Instantiate(Explode, transform.position, transform.rotation) as GameObject, 2);
            Destroy(gameObject);
        }
    }
}