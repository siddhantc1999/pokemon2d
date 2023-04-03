using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] float xdirection = 0.5f;
    [SerializeField] float period= 2f;
    [SerializeField] Vector3 newpos;
    [SerializeField] ParticleSystem particlefire;

    float tau;
    float frequency;
    float value;
    float offset;
    float realoffset;
    // Start is called before the first frame update
    BoxCollider2D charifeet;
    playercontroller myplayer;
    bool keepmoving = true;
    void Start()
    {
        /*charifeet = GetComponent<BoxCollider2D>();*/
        myplayer = FindObjectOfType<playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  transform.Translate(xdirection, transform.position.y, transform.position.z);*/
        xenemymove();
        yenemymove();

    }

    private void yenemymove()
    {
        if (keepmoving)
        {
            tau = 2 * Mathf.PI;
            frequency = Time.time / period;
            value = tau * frequency;
            offset = Mathf.Sin(value);
        
            Vector3 realpos1 = offset * newpos * Time.deltaTime;
         
            transform.position += realpos1;
        }
        
        

      
    }

    private void xenemymove()
    {
        if (keepmoving)
        {
            if (Mathf.Sign(transform.localScale.x) == 1)
            {

                transform.position += new Vector3(-xdirection * Time.deltaTime, 0, 0);

            }
            else
            {
                transform.position += new Vector3(xdirection * Time.deltaTime, 0, 0);


            }
        }
    }
    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(" in collision ");
    }*/
    /* public void OnColliderExit2D(Collider2D collision)
     {
         Debug.Log(" i am in ontrigger exit 2d");

       *//* transform.localScale = new Vector2(-transform.localScale.x, 1f);*//*
     }*/
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "foreground")
        {
            transform.localScale = new Vector2(-transform.localScale.x, 1f);
        }
    }
    /*    public void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.name== "player")
            {

                Destroy(gameObject);
            }
        }*/
    public void OnCollisionEnter2D(Collision2D collision)
    {

        string playanimaton = myplayer.currentanimation();
        if (collision.gameObject.name == "player" && playanimaton == "roll")
        {

            keepmoving = false;
            ParticleSystem num = Instantiate(particlefire, transform.position, Quaternion.identity);
            Destroy(gameObject, 1f);

           
           
        }
    }

}
