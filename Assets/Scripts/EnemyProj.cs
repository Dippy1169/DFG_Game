using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProj : MonoBehaviour
{

    public float speed = 20.0f;
    public float life = 3.0f;

    public float damageDealt;

    public GameObject Explode;

    public Color explosionColor = Color.white; //new Color(255, 255, 255);
    public bool test = false;

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
        //if (col.gameObject.tag == "Unbreakable")
        //{
        //    Kill(explosionColor, test);
        //}

        //Debug.Log("No damage on collision with: " + col);
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyProj" || col.gameObject.tag == "PlayerProj")
        {
            Debug.Log("Ignore collision with: " + col);

            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), col);
        } else {
            if (col.gameObject.tag == "Player")
            {
                explosionColor = new Color(231f / 255f, 205f / 255f, 144f / 255f, 1f / 255f);//"#E7CD90";
                //explosionColor = Color.blue;
                PlayerHealth health = col.gameObject.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    //Debug.Log("We collided with: " + col);
                    health.TakeDamage(damageDealt);
                    test = true;
                    //Kill(explosionColor, test);
                    ColorExplode(explosionColor);
                    Kill();
                    return;
                }
            } else {
                EnemyHealth health = col.gameObject.GetComponent<EnemyHealth>();
                if (health != null)
                {
                    //Debug.Log("We collided with: " + col);
                    health.TakeDamage(damageDealt);
                }
                Kill();
            }
    }

        test = false;
        
    }

    void ColorExplode(Color explosionColor)
    {
        //if (log)
        //    Debug.Log("Explosion Color: " + explosionColor);
        GameObject myBomb = Instantiate(Explode, transform.position, transform.rotation);
        //myBomb.GetComponent<Renderer>().material.color = explosionColor;
        myBomb.GetComponent<Renderer>().material.color = explosionColor;
    }

    void Kill()
    {
        //Destroy(Instantiate(Explode, transform.position, transform.rotation) as GameObject, 2);
        Destroy(this.gameObject);
        return;
    }
}
