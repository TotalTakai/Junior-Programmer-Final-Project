using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private float horizontalInput;
    private float verticalInput;
    private const float playerSpeed = 10;
    private const float jumpForce = 14;
    private bool isGrounded = true;
    private int playerLayer, platformLayer;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.NameToLayer("Player");
        platformLayer = LayerMask.NameToLayer("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move() // Controls the player's left - right movement
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * playerSpeed * horizontalInput * Time.deltaTime);
    }

    private void Jump() // Controls the play up and down jump
    {
        verticalInput = Input.GetAxis("Vertical");
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && verticalInput >= 0)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        else if (isGrounded && Input.GetKeyDown(KeyCode.Space) && verticalInput < 0)
        {
            isGrounded = false;
            StartCoroutine("GoThroughPlatform");
        }
    }
    IEnumerator GoThroughPlatform() 
        /*Cancels player's and platform's collision for 0.5 seconds when player jump through it.
          While it is needed for downjump, Unity's platform effector is used for the up jump*/
    {
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform")) //Checks when player is grounded 
        {
            isGrounded = true;
        }
    }
}
