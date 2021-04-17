using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    public GameObject Bullet;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + .025f * Vector3.right);
    }

    public void Damage()
    {
        Health--; 
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
