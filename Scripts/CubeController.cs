using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public CharacterController characterController;
    private Vector3 velocity;
    public float speed = 5f;
    public float jump = 2f;
    public float Gravity = -5.8f;
    CharacterController controller;
    void Start()
    {
           controller = GetComponent<CharacterController>();
           
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3 (xInput, 0f, zInput).normalized;
        controller.SimpleMove(dir * speed);
       
            if (Input.GetKeyDown(KeyCode.Space))
            {
            velocity.y = Mathf.Sqrt(jump * -2f * Gravity);
            if (controller.isGrounded)
            {
                controller.SimpleMove(dir * speed);
               
            }

        }
        else
        {
            velocity.x = dir.x * speed;

            velocity.z = dir.z * speed;
        }

        ApplyGravity();
    }

    void ApplyGravity()
    {
        velocity.y += Gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

}
