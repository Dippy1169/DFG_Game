using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj : MonoBehaviour
{

    public float speed = 20.0f;
    public float life = 5.0f;

    public float damageDealt;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Kill", life);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player" || col.gameObject.tag == "EnemyProj")
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), col);
        }
        else
        {
            EnemyHealth health = col.gameObject.GetComponent<EnemyHealth>();
            Debug.Log("Player Proj Collision with " + col);

            if (health != null)
            {
                health.TakeDamage(damageDealt);
            }

            Kill();
        }
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
