using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private PlayerHeart life;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private GameObject Camera;

    private float dirX = 0f;
    private float dirY = 0f;
    public bool isShooting = false;
    private bool isLadder = false;
    private bool isClimbing = false;
    private bool facingLeft = false;

    //private int remainBullet = 10;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float bigJumpForce = 14f;
    [SerializeField] private float climbSpeed = 7f;
    public float smallJumpForce = 6f;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private PlayerGun playerGun;
    private enum MovementState {idle, running, jumping, falling, ladder, shooting, hurt};
    private MovementState state = MovementState.idle;

    [HideInInspector]
    public Vector2 reloadPosition = new Vector2(-2.5f, 1.0f);

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        life = GetComponent<PlayerHeart>();

        if (facingLeft){
            Flip();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!life.isAlive){
            anim.SetInteger("state", (int)MovementState.hurt);
            return;
        }

        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        
        if(!isClimbing || IsGrounded()){
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, bigJumpForce);
        }

        if (Input.GetButtonDown("Fire1") && IsGrounded() && playerGun.currentGun > 0)
        {
            isShooting = true;
        }
        else{
            isShooting = false;
        }

        if(Input.GetButtonDown("Vertical")){
            if (isLadder){
                if (Mathf.Abs(dirY) > 0f){
                    isClimbing = true;
                }
                if (dirY < 0f && IsGrounded()){
                    isClimbing = false;
                }
            }
            else if (IsGrounded()){
                rb.velocity = new Vector2(rb.velocity.x, smallJumpForce);
            }
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
            if (facingLeft == true){
                Flip();
            }
        }
        else if(dirX < 0f){
            state = MovementState.running;
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
            //Shoot();
            Invoke("Shoot", 0.25f);
            playerGun.Reduce();

        }

        if (isLadder && isClimbing){
            state = MovementState.ladder;
        }

        anim.SetInteger("state", (int)state); 
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Ladder")){
            isLadder = true;
        }
        else if(collider.CompareTag("Button")){
            Button button = collider.GetComponent<Button>();
            if (button != null){
                button.Hit();
            }
        }
        else if(collider.CompareTag("MapTransition")){
            MapTransition mt = collider.GetComponent<MapTransition>();
            transform.position = mt.playerNewPosition.transform.position;
            Camera.transform.position = mt.cameraNewPosition.transform.position;
            reloadPosition = mt.playerNewPosition.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("Ladder")){
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
    }
}