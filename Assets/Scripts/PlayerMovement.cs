using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField]private float speed;
    private Animator anim;
    private bool grounded;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        body.velocity = new Vector2(speed, body.velocity.y);


    if(Input.GetKey(KeyCode.Space) && grounded)
        Jump();

    anim.SetBool("run", speed != 0);
    anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
    body.velocity = new Vector2(body.velocity.x , speed);
    anim.SetTrigger("jump");
    grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        grounded = true;
    }
}
