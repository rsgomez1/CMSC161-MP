using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask rockMask;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isRocked;
    bool isGrounded;


    public AudioClip groundFootStepSound;
    public AudioClip rockFootStepSound;
    public float footStepDelay;

    private float nextFootstep = 0;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isRocked = Physics.CheckSphere(groundCheck.position, groundDistance, rockMask);

        if ((isGrounded && velocity.y < 0) || (isRocked && velocity.y < 0))
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 motion = transform.right * x + transform.forward * z;
        controller.Move(motion * speed * Time.deltaTime);

        if ((Input.GetButtonDown("Jump") && isGrounded) || (Input.GetButtonDown("Jump") && isRocked))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                nextFootstep -= Time.deltaTime;
                if (nextFootstep <= 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(groundFootStepSound, 0.7f);
                    nextFootstep += footStepDelay;
                }
            } else if (isRocked)
            {
                nextFootstep -= Time.deltaTime;
                if (nextFootstep <= 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(rockFootStepSound, 0.7f);
                    nextFootstep += footStepDelay;
                }
            }
        }
    }
}


