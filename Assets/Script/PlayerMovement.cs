using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float axis;
    public float speed;
    public Rigidbody2D prb;
    public float jumpPower = 7f;

    public bool doubleJump = false;

    //public float fallspeed;

    private bool isFacingRight = true;
    private bool isGround;

    private float cayoteTime = .2f;
    private float CayoteCounter;
    private float bufferTime = .2f;

    private float bufferCounter;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGround && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if (isGround)
        {
            //Debug.Log("CAYOTE value is given");

            CayoteCounter = cayoteTime;


        }
        else
        {
            //Debug.Log("CAYOTE value is redued");

            CayoteCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Buffer value is given");

            bufferCounter = bufferTime;

        }
        else

        {
            //Debug.Log("Buffer value is redued");
            bufferCounter -= Time.deltaTime;
        }

        axis = Input.GetAxis("Horizontal");
        prb.velocity = new Vector2(axis * speed, prb.velocity.y);
        Flip();
        
        if ((CayoteCounter > 0 && bufferCounter > 0) || (doubleJump == true && Input.GetButtonDown("Jump")))
        {
            Debug.Log("space is working");
            prb.velocity = new Vector2(prb.velocity.x, jumpPower);
            doubleJump = !doubleJump;
            CayoteCounter = 0;
            bufferCounter = 0;
        }

        //prb.AddForce(new Vector2 (prb.velocity.x,fallspeed * -1));


    }
    public void Flip()
    {
        if ((isFacingRight == false && 0 < axis) || (isFacingRight == true && 0 > axis)) // right, left 
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Ground Is not Found");

            isGround = false;

        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // Debug.Log("Ground Is Found");
            isGround = true;


        }
    }

}
