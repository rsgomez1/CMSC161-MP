using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement Physics")]
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    Vector3 velocity;

    [Header("Walking and Jumping")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask rockMask;
    public LayerMask groundMask;
    bool isRocked;
    bool isGrounded;
    private int numberOfJumps;
    private int maxJumps = 1;
    public float footStepDelay;
    private float nextFootstep = 0;

    [Header("Attacking")]
    public float attackDistance = 3f;
    public float attackDelay = 0.4f;
    public float attackSpeed = 1f;
    public int attackDamage = 3;
    public LayerMask attackLayer;

    public GameObject hitEffect;

    bool attacking = false;
    bool readyToAttack = true;
    int attackCount;

    [Header("Animation")]
    public const string IDLE = "Idle";
    public const string WALK = "Walk";
    public const string ATTACK1 = "Attack 1";
    public const string ATTACK2 = "Attack 2";

    string currentAnimationState;

    [Header("")]
    public GameObject lightSource;

    void Start()
    {
        InventoryManager.Instance.hasBoots = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryManager.Instance.hasLantern)
        {
            lightSource.SetActive(true);
        }

        if (InventoryManager.Instance.hasBoots)
        {
            maxJumps = 2;
            gameObject.GetComponent<Dashing>().enabled = true;
        } else
        {
            maxJumps = 1;
            gameObject.GetComponent<Dashing>().enabled = false;
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

        if (((Input.GetButtonDown("Jump") && isGrounded) || (Input.GetButtonDown("Jump") && isRocked)) && (numberOfJumps < maxJumps))
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

        if (Input.GetButtonDown("Jump") && !isGrounded && !isRocked && (numberOfJumps < maxJumps))
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

        if(Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }

        SetAnimations();
    }

    public void Attack()
    {
        if(!readyToAttack || attacking)
        {
            return;
        }

        readyToAttack = false;
        attacking = true;

        Invoke(nameof(ResetAttack), attackSpeed);
        Invoke(nameof(AttackRaycast), attackDelay);

        if(attackCount == 0)
        {
            ChangeAnimationState(ATTACK1);
            attackCount++;
        } else
        {
            ChangeAnimationState(ATTACK2);
            attackCount = 0;
        }
    }

    void ResetAttack()
    {
        readyToAttack = true;
        attacking = false;
    }

    void AttackRaycast()
    {
        if (Physics.Raycast(gameObject.transform.Find("Camera").transform.position, gameObject.transform.Find("Camera").transform.forward, out RaycastHit hit, attackDistance, attackLayer))
        {
            HitTarget(hit.point);
        }
    }

    void HitTarget(Vector3 pos)
    {
        GameObject GO = Instantiate(hitEffect, pos, Quaternion.identity);
        Destroy(GO, 10);
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentAnimationState == newState)
        {
            return;
        }

        currentAnimationState = newState;
        GetComponentInChildren<Animator>().CrossFadeInFixedTime(currentAnimationState, 0.2f);
    }

    void SetAnimations()
    {
        if (!attacking)
        {
            if (velocity.x == 0 && velocity.z == 0)
            {
                ChangeAnimationState(IDLE);
            }
            else
            {
                ChangeAnimationState(WALK);
            }
        }
    }
}


