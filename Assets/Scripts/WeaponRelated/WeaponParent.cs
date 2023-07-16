using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector2 playerPos;
    public Vector2 pointerPosition { get; set; }

    private bool isPlayer;

    private void Awake()
    {
        if (transform.parent != null && transform.parent.CompareTag("Player"))
        {
            isPlayer = true;
        }
        else isPlayer = false;
    }

    private void Update()
    {
        if (isPlayer)
        {
            transform.right = (pointerPosition - (Vector2)transform.position).normalized;
        }
        else
        {
            playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            transform.right = ((Vector2)transform.position - playerPos).normalized;
        }
    }
}
