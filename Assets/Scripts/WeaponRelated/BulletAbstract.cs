using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : MonoBehaviour
{
    // Start is called before the first frame update
    protected float bulletSpeed { get; set; }
    public bool isPlayerBullet { get; set; }
    public Vector2 pointerPosition { get; set; }
    private Vector3 moveDirection;
    private Transform target = null;

    void Start()
    {
        moveDirection = (target.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Add future damage
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add future damage
        }
        Destroy(gameObject); // will be changed for object pooling
    }
}
