using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    Animator myanimator;
    Animation anim;
    [SerializeField] float constant = 10f;
    [SerializeField] float jumpvalue=2f;
    float xdirectionspeed;
    BoxCollider2D myfeet;
    AnimatorClipInfo[] myclip;
    [SerializeField] int lives = 3;
    CapsuleCollider2D mybody;
    [SerializeField] int thrust=100;
    [SerializeField] int mythrust = 800;

    // Start is called before th
    //e first frame update
    private void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        myfeet = GetComponent<BoxCollider2D>();
        mybody = GetComponent<CapsuleCollider2D>();
        /* animationweight();*/
    }

    /*private void animationweight()
    {
       anim["pikachuidle"]
    }
*/
    void Update()
    {
        
        Motion();
        currentanimation();
       /* transform.position = new Vector2(transform.position.x,Mathf.Clamp(transform.position.y,0f, 10f));*/
        

    }
   
    public string currentanimation()
    {
        Debug.Log("here");
        
        myclip = myanimator.GetCurrentAnimatorClipInfo(0);

        /*
                if (myclip != null)
                {
                    Debug.Log(myclip[0].clip.name);
                }
                else
                {
                    Debug.Log("0");
                }*/
        Debug.Log("the clip name "+myclip[0].clip.name);
        return myclip[0].clip.name;
    }

    private void Motion()
    {
        jumpandrun();
        jump();
        run();
    }

    private void run()
    {
       /* if(!myfeet.IsTouchingLayers(LayerMask.GetMask("foreground")))
        {
            return;
        }*/
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
        if(!myfeet.IsTouchingLayers(LayerMask.GetMask("foreground")))
        {
            return;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            myanimator.SetBool("isrolling", true);

            myrigidbody.velocity = new Vector2(myrigidbody.velocity.x,jumpvalue);
        }
        else
        {
            myanimator.SetBool("isrolling", false);
        }
      
    }

    private void jumpandrun()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                myanimator.SetBool("isrunning", false);
                myanimator.SetBool("isrolling", true);
            }
        else
            {
                myanimator.SetBool("isrolling", false);
            }
        }
    }
    public void OnParticleCollision(GameObject other)
    {
     
     
        
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("i am in trigger");
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* Debug.Log("the vector up" + Vector2.up*100f);*/
        if (collision.gameObject.name == "spring")
        {
            Debug.Log(" i am in spring");
            myrigidbody.AddForce(Vector2.up * thrust, ForceMode2D.Force);
        }
        if (collision.gameObject.name == "Square")
        {
            Debug.Log(" i am in square");
            myrigidbody.AddForce(Vector2.up * thrust, ForceMode2D.Force);
        }
        if (collision.gameObject.name == "nextspring")
        {
            Debug.Log(" i am in spring");
            myrigidbody.AddForce(Vector2.up * mythrust, ForceMode2D.Force);
        }

    }
}


