using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float turnSpeed = 360.0f;

    private float yVelocity = 0;
    public float gravity = 30.0f;
    private Vector3 moveVelocity = Vector3.zero;

    private CharacterController controller;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        controller.Move(transform.forward * speed * Time.deltaTime);

        yVelocity -= gravity * Time.deltaTime;
        Vector3 velocity = moveVelocity + yVelocity * Vector3.up;
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            yVelocity = 0;
        }

        if (transform.position.y <= -50)
        {
            Destroy(gameObject);
        }
    }
}
