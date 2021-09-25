using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Slider healthBar;
    public Text HPText;
    public PlayerHealth playerHealth;
    public Spawner spawner;
    public Text round;
    public Text enemies;

    private static bool UIExists;

    public GameObject playerStats;


    // Start is called before the first frame update
    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
       
        }
        else
        {
            Destroy(gameObject);
            //spawner = GameObject.Find("EnemySpawner").GetComponent<Spawner>();
            //playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        }
        //playerStats = GameObject.FindGameObjectWithTag("Player");
        //spawner = GameObject.FindGameObjectWithTag("EnemySpawner");
        //spawner = Spawner.GetComponent<SlingShot>();
        //spawner = FindObjectOfType(typeof(Spawner));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerStats);
        healthBar.maxValue = PlayerPrefs.GetFloat("PlayerMaxHealth");
        healthBar.value = PlayerPrefs.GetFloat("PlayerHealth");
        HPText.text = "HP: " + healthBar.value.ToString() + "/" + healthBar.maxValue.ToString();
        //healthBar.maxValue = playerHealth.maxHealth;
        //healthBar.value = playerHealth.currentHealth;
        //HPText.text = "HP: " + playerHealth.currentHealth.ToString() + "/" + playerHealth.maxHealth.ToString();
        if (spawner != null)
        {
            
            round.text = "Round: " + spawner.round.ToString();
            enemies.text = "Enemies Remaining: " + spawner.enemiesRemaining.ToString();
        }
        else
        {
            round.text = "";
            enemies.text = "";
        }
    }
}