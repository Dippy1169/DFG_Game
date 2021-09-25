using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{

    public int startEnemyNumber = 1;
    public float roundDelay = 3.0f;
    public float spawnDelay = 2.0f;
    public int bossRound = 10;
    public int enemiesRemaining = 0;
    public bool bossSpawned;

    public GameObject enemy;
    public GameObject boss;
    public GameObject player;

    private GameObject bossStats;
    private GameObject[] spawnLocs;

    public int round = 0;
    private int bossRoundTrigger = 1;
    private int numberOfSpawnLocations;
    private int spawnSelected;

    void Start()
    {
        spawnLocs = GameObject.FindGameObjectsWithTag("SpawnPoint");
        StartCoroutine(SpawnEnemies(startEnemyNumber, spawnDelay));
        player = GameObject.FindGameObjectWithTag("Player");
        bossSpawned = false;
        numberOfSpawnLocations = spawnLocs.Length;
    }

    IEnumerator SpawnEnemies(int count, float delay)
    {
        for (int i = 0; i < count; i++)
        {
            spawnSelected = Random.Range(0, numberOfSpawnLocations);
            //spawnSelected = 1;
            enemy.transform.localScale = new Vector3(1, 1, 1);
            enemy.GetComponent<EnemyHealth>().initialHealth = 10;
            // Select a random number based on spawn points, pull that spawn points position to spawn the enemy
            //Debug.Log("Fail? " + spawnSelected);
            //Debug.Log("Fail? " + spawnLocs[spawnSelected].transform.position);
            Instantiate(enemy, spawnLocs[spawnSelected].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }

    void Update()
    {

        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (round % bossRound == 0 && bossSpawned == false && bossRoundTrigger != round)
        {
            SpawnBoss();
            bossSpawned = true;
            bossRoundTrigger = round;
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            player.GetComponent<PlayerHealth>().NewRound();
            player.GetComponent<Launcher>().reloadTime -= 0.05f;
            StartCoroutine(SpawnEnemies(++round, spawnDelay));
        }
        if (bossSpawned)
        {
            if (GameObject.Find("Boss") == null)
            {
                bossSpawned = false;
            } else
            {
                Debug.Log("Boss Health: " + bossStats.GetComponent<EnemyHealth>().currentHealth);
            }
        }
            
    }

    public void SpawnBoss()
    {
        boss.transform.localScale = new Vector3(5, 5, 5);
        boss.GetComponent <EnemyHealth>().initialHealth = 100;
        bossStats = Instantiate(boss, new Vector3(60, 10, 0), Quaternion.identity);
        bossStats.name = "Boss";
    }


}
