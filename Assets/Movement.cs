using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float vroom = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool groundTouch;

    // Update is called once per frame
    void Update()
    {
        groundTouch = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(groundTouch && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float posX = Input.GetAxis("Horizontal");
        float posZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * posX + transform.forward * posZ;

        controller.Move(move * vroom * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
