using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int maxJumps;
    public LayerMask whatIsGround;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private Animator animator;
    public static bool _isFracingRight = true;
    private int jumpsLeft;

    public static bool _isShielded;
    public GameObject shield;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        jumpsLeft = maxJumps;
        shield = transform.Find("Shield").gameObject;
        DeactivateShield();
    }

    void Update()
    {
        Movement();
        Jump();
        Shield();
    }

    bool OnGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, whatIsGround);
        return raycastHit.collider != null;
    }

    void Jump()
    {
        if (OnGround())
        {
            jumpsLeft = maxJumps;
            animator.SetBool("isGrounded", false);
        }
        else
        {
            animator.SetBool("isGrounded",true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            jumpsLeft--;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        if(horizontalMovement != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        rigidBody.velocity = new Vector2(horizontalMovement * speed, rigidBody.velocity.y);

        Flip(horizontalMovement);
    }

    void Flip(float xMovement)
    {
        if ((_isFracingRight == true && xMovement < 0) || (_isFracingRight == false && xMovement > 0))
        {
            _isFracingRight = !_isFracingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180);
        }
    }
    
    void Shield()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && _isShielded == false)
        {
            ActiateShield();
        }
    }

    void ActiateShield()
    {
        shield.SetActive(true);
        _isShielded = true;
        Invoke("DeactivateShield", 3f);
    }

    void DeactivateShield()
    {
        shield.SetActive(false);
        _isShielded = false;
    }
}
