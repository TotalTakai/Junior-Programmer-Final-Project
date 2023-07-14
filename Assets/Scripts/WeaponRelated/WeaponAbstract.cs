using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public abstract class WeaponAbstract : MonoBehaviour
{
    public UnityEvent onAttack;
    protected float attackCooldown { get; set; }
    protected bool isAutomatic { get; set; }
    protected float currentCooldown { get; set; }


    // Update is called once per frame
    void Update()
    {
        if (isAutomatic)
        {
            if (currentCooldown <= 0f)
            {
                onAttack?.Invoke();
                currentCooldown = attackCooldown;
            }
        }
        else
        {
            if (currentCooldown <= 0f)
            {
                onAttack?.Invoke();
                currentCooldown = attackCooldown;
            }
        }
        currentCooldown -= Time.deltaTime;
    }
}
