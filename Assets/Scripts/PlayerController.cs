using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public Animator animator;

    Rigidbody2D rb;
    public int Health;
    public float speed = 0f;

    public int JumpSpeed;
    public bool isGrounded = true;
    private RaycastHit2D GroundRaycast;
    private LayerMask groundMask;

    public GameObject BulletOrigin;
    public GameObject Bullet; 
    int delay = 1001;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetTrigger("IsWalking");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && delay > 500) 
        {
            StartCoroutine (Shoot());
        }

        delay++; 
    }

    private void FixedUpdate()
    {
        
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));

        groundMask = LayerMask.GetMask("Ground");

        GroundRaycast = Physics2D.Raycast(transform.position, Vector3.down, 5f, groundMask);
        if (GroundRaycast.collider == null)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
            animator.SetTrigger("IsWalking");
        }
    }

    void Jump()
    {
        if (isGrounded == true)
        {
            animator.SetTrigger("IsJumping");
            rb.AddForce(transform.up * JumpSpeed, ForceMode2D.Impulse);
        }
    }

     IEnumerator Shoot()
    {
        delay = 0;
        animator.SetTrigger("IsAttacking");

        yield return new WaitForSeconds(1f);

        Instantiate(Bullet, BulletOrigin.transform.position, Quaternion.identity);
    }
}
