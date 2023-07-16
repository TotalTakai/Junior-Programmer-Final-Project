using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Vector2 pointerInput;
    private float horizontalInput;
    private float verticalInput;
    private const float playerSpeed = 10;
    private const float jumpForce = 14;
    private bool isGrounded = true;
    private int playerLayer, platformLayer;
    private WeaponParent weaponParent;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        playerLayer = LayerMask.NameToLayer("Player"); //Needed for the jump down through platform
        platformLayer = LayerMask.NameToLayer("Platform"); //Needed for the jump down through platform
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        PointerInput();
        weaponParent.pointerPosition = pointerInput; //Pivots the weapon around the player to look at mouse position
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

    private void PointerInput() //Updates pointerInput to look at the mouse position
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pointerInput= new Vector2(mousePos.x, mousePos.y);
    }
}
