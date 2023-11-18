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
    private int numberOfJumps;
    private int maxJumps = 1;

    public float footStepDelay;
    private float nextFootstep = 0;

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<DoubleJump>().enabled)
        {
            maxJumps = 1;   
        } else
        {
            maxJumps = 2;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isRocked = Physics.CheckSphere(groundCheck.position, groundDistance, rockMask);

        if ((isGrounded && velocity.y < 0) || (isRocked && velocity.y < 0))
        {
            velocity.y = -2f;
            numberOfJumps = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 motion = transform.right * x + transform.forward * z;
        controller.Move(motion * speed * Time.deltaTime);

        if (((Input.GetButtonDown("Jump") && isGrounded) || (Input.GetButtonDown("Jump") && isRocked)) && numberOfJumps < maxJumps)
        {
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W)) {
                if (isGrounded)
                {
                    SoundManager.soundManager.playGroundFootStepSFX();
                }
                else if (isRocked)
                {
                    SoundManager.soundManager.playRockFootStepSFX();
                }
            } else {
                nextFootstep = 0;
            }
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            numberOfJumps++;
        }

        if (Input.GetButtonDown("Jump") && !isGrounded && !isRocked && numberOfJumps < maxJumps)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            numberOfJumps++;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            nextFootstep -= Time.deltaTime;
            if (nextFootstep <= 0)
            {
                if (isGrounded)
                {
                    SoundManager.soundManager.playGroundFootStepSFX();
                }
                else if (isRocked)
                {
                    SoundManager.soundManager.playRockFootStepSFX();
                }
                nextFootstep += footStepDelay;
            }
        }
    }
}


