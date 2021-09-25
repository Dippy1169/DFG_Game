using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLauncher : MonoBehaviour
{ 

    public GameObject enemyRocketPrefab;
    public Transform rocketBarrel;
    public float reloadTime = 0.5f;
    private float fireTime;

    private GameObject player;

    private float lastFireTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fireTime = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastFireTime + reloadTime)
        {
            if (player.activeInHierarchy)
            {
                reloadTime = Random.Range(fireTime - 0.1f, fireTime + 0.1f);
                GameObject go = (GameObject)Instantiate(enemyRocketPrefab, rocketBarrel.position, Quaternion.LookRotation(rocketBarrel.forward));
                Physics.IgnoreCollision(GetComponent<Collider>(), go.GetComponent<Collider>());
                lastFireTime = Time.time;
            }
        }
    }
}