using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller; 

    Rigidbody2D rb;
    public int Health;
    public float speed = 0f;

    GameObject BulletOrigin;
    public GameObject Bullet; 
    int delay = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump(); 
        }

        delay++; 
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
    }

    void Jump()
    {

    }

    void Shoot()
    {
        delay = 0;
        Instantiate(Bullet, BulletOrigin.transform.position, Quaternion.identity);
    }
}
