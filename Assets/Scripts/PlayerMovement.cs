using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 3.0f;
    private float movementSpeedMod = 1.0f;

    public Transform head;

    public float maxHeadRotation = 40.0f;
    public float minHeadRotation = -40.0f;
    private float currentHeadRotation = 0;


    private float yVelocity = 0;
    public float jumpSpeed = 30.0f;
    public float gravity = 50.0f;
    private Vector3 moveVelocity = Vector3.zero;

    //public bool wasGrounded = true;
    //public int updateCounter = 0;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isShiftKeyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        if (isShiftKeyDown == true)
        {
            movementSpeedMod = 2.0f;
        }
        else
        {
            movementSpeedMod = 1.0f;
        }
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        yVelocity -= gravity * Time.deltaTime;
        Vector3 velocity = moveVelocity + yVelocity * Vector3.up;
        controller.Move(velocity * Time.deltaTime);
        //gameObject.controller.Move(transform.TransformDirection(input * movementSpeed * Time.deltaTime + yVelocity * Vector3.up * Time.deltaTime));
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);
        head.Rotate(Vector3.left, mouseInput.y * rotationSpeed);

        currentHeadRotation = Mathf.Clamp(currentHeadRotation + mouseInput.y * rotationSpeed, minHeadRotation, maxHeadRotation);

        head.localRotation = Quaternion.identity;
        head.Rotate(Vector3.left, currentHeadRotation);

        // A hacked way to handle uneven ground. if you have touched the gorund in the last 30 updates. you can still jump
        //if (controller.isGrounded)
        //{
        //    wasGrounded = true;
        //    updateCounter = 0;
        //}
        //else
        //{
        //    updateCounter += 1;
        //    if (updateCounter >= 100)
        //    {
        //        wasGrounded = false;
        //    }
        //}

        if (controller.isGrounded)
        {
            moveVelocity = transform.TransformDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))) * movementSpeed * movementSpeedMod;
            yVelocity = 0;
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpSpeed;
            }
        }

        
    }
}
