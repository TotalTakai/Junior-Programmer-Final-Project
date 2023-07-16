using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponAbstract
{
    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = 1f;
        isAutomatic = false;
    }
}
