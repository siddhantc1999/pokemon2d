using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duplicateplayercontroller : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    Animator myanimator;
    [SerializeField] float constant = 10f;
    [SerializeField] float jumpvalue=2f;
    float xdirectionspeed;
    BoxCollider2D myfeet;
    // Start is called before th
    //e first frame update
    private void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        myfeet = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Motion();
        
    }

    private void Motion()
    {
        jumpandrun();
        jump();
        run();
    }

    private void run()
    {
        if(!myfeet.IsTouchingLayers(LayerMask.GetMask("foreground")))
        {
            return;
        }
        float magnitude = Input.GetAxis("Horizontal");
      if(magnitude!=0)
        {

            /*  float dynamicvlaue = Mathf.Sign(magnitude) * transform.localScale.x;
              Debug.Log("the transform localscale" + transform.localScale.x);*/
            if(magnitude<0)
            {
                transform.localScale = new Vector2(Mathf.Sign(magnitude) * 2f, 2f);
            }
            else
            {
             
                 transform.localScale = new Vector2(Mathf.Sign(magnitude) * 2f, 2f);
            }
            myanimator.SetBool("isrunning", true);
            xdirectionspeed = magnitude  *constant;
            Vector2 playervelocity = new Vector2(xdirectionspeed, myrigidbody.velocity.y);
            myrigidbody.velocity = playervelocity;
            
        }
      else
        {
            Vector2 playervelocity = new Vector2(0f, myrigidbody.velocity.y);
            myrigidbody.velocity = playervelocity;
            myanimator.SetBool("isrunning", false);
        }
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody.velocity = new Vector2(0f,jumpvalue);
        }
      
    }

    private void jumpandrun()
    {
        
    }
}

