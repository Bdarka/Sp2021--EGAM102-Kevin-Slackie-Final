using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    public int Health;
    public GameObject Bullet;
    Rigidbody2D rb;
    BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(IsFacingLeft())
        {
            // Move Right
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
        else
        {
            // Move Left 
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
    }

    public void Damage()
    {
        Health--; 
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Turn 
        transform.localScale = new Vector2((Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }

    private bool IsFacingLeft()
    {
        return transform.localScale.x > -Mathf.Epsilon; // Checks for an incredibly small value, better than putting .0001
    }
}
