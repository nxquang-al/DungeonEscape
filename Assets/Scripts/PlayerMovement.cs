using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private float dirY = 0f;
    public bool isShooting = false;
    private bool isLadder = false;
    private bool isClimbing = false;
    private bool facingLeft = false;

    private int remainBullet = 10;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float climbSpeed = 7f;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private PlayerGun playerGun;
    private enum MovementState {idle, running, jumping, falling, ladder, shooting};
    private MovementState state = MovementState.idle;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (facingLeft){
            Flip();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        
        if(!isClimbing || IsGrounded()){
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //if(Input.GetButtonDown("Fire1")  && IsGrounded() && remainBullet > 0){
        //    isShooting = true;
        //}

        if (Input.GetButtonDown("Fire1") && IsGrounded() && playerGun.currentGun > 0)
        {
            isShooting = true;
        }

        if (Input.GetButtonDown("Vertical") && isLadder && Mathf.Abs(dirY) > 0f){
            isClimbing = true;
        }

        UpdateAnimationState();

    }

    private void FixedUpdate()
    {
        if(isClimbing){
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, dirY * climbSpeed);
        }
        else{
            rb.gravityScale = 3f;
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if(dirX > 0f){
            state = MovementState.running;
            // sprite.flipX = false;
            if (facingLeft == true){
                Flip();
            }
        }
        else if(dirX < 0f){
            state = MovementState.running;
            // sprite.flipX = true;
            if (facingLeft == false){
                Flip();
            }
        }
        else{
            state = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f){
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f){
            state = MovementState.falling;
        }

        if(isShooting){
            state = MovementState.shooting;
            isShooting = false;
            Shoot();
            //remainBullet -= 1;
        }

        if(isLadder && isClimbing){
            state = MovementState.ladder;
        }

        anim.SetInteger("state", (int)state); 
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Ladder")){
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Ladder")){
            isLadder = false;
            isClimbing = false;
        }
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Shoot()
    {   
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        playerGun.Shot();

    }
}