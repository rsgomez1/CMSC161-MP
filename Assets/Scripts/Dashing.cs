using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashTime = 1.5f;

    [SerializeField] private Cooldown cooldown;

    private void Start()
    {
        characterController = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        if (cooldown.isCoolingDown) return;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(Dash());
            cooldown.startCooldown();
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 moveDir = transform.right * x + transform.forward * z;
            characterController.Move(moveDir * dashSpeed * Time.deltaTime);

            yield return null;
        }

    }

}
