using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;
    private Animator anim;
    private float input;
    private bool isJumping;
    private string isMoving = "isMoving";
    private string JumpCheck = "isJumping";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input < 0) sr.flipX = true; else if (input > 0) sr.flipX = false;

        RunningAnimation();

        if (Input.GetButtonDown("Jump") && !isJumping) PlayerJump();
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(input * moveForce * Time.deltaTime, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.CompareTag("ground")) isJumping = false; anim.SetBool(JumpCheck, false);
    }

    private void PlayerJump()
    {
        rb.velocity = Vector2.up * jumpForce;
        isJumping = true;
        anim.SetBool(JumpCheck, true);
    }

    private void RunningAnimation()
    {
        if(input != 0) anim.SetBool(isMoving, true); else anim.SetBool(isMoving, false);
    }
}
