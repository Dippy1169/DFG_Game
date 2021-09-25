using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    public GameObject rocketPrefab;
    public Transform rocketBarrel;
    public float startReloadTime = 0.5f;
    public int projectiles = 1;
    public float reloadTime;

    public GameObject player;

    private float lastFireTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        reloadTime = startReloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > lastFireTime + reloadTime)
        {
            for (int i = 0; i < projectiles; i++)
                Fire();
            lastFireTime = Time.time;
        }
        if(reloadTime <= 0)
        {
            projectiles++;
            reloadTime = startReloadTime;
        }

    }

    void Fire()
    {
        GameObject go = (GameObject)Instantiate(rocketPrefab, rocketBarrel.position, Quaternion.LookRotation(rocketBarrel.forward));
        Physics.IgnoreCollision(GetComponent<Collider>(), go.GetComponent<Collider>());
        Physics.IgnoreCollision(player.GetComponent<Collider>(), go.GetComponent<Collider>());
    }
}
