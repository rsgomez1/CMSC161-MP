using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
    [SerializeField] private float cooldownTime;
    private float nextFireTime;

    public bool isCoolingDown => Time.time < nextFireTime;
    public void startCooldown() => nextFireTime = Time.time + cooldownTime;
}