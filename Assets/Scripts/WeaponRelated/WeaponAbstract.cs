using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAbstract : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    protected float attackCooldown { get; set; }
    protected bool isAutomatic { get; set; }
    protected float currentCooldown { get; set; }

    private GameObject tmpBullet;

    // Update is called once per frame
    void Update()
    {
        if (isAutomatic)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && currentCooldown <= 0f)
            {
                tmpBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                tmpBullet.GetComponent<BulletAbstract>();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && currentCooldown <= 0f)
            {
                Instantiate(bulletPrefab);
                Debug.Log("Bullet Spawned"); //debugging
                currentCooldown = attackCooldown;
            }
        }
        currentCooldown -= Time.deltaTime;
    }
}
