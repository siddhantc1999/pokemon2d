using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crab : MonoBehaviour
{
    [SerializeField] float xdirection = 1f;
    playercontroller myplayer;
    /* [Serializedfield] GameObject explosion;*/
    /* [SerializeField] ParticleSystem particlefire;*/
    [SerializeField] ParticleSystem particlefire;

    bool keepmoving = true;

    Animator fireanimator;
    bool isalive = true;
    destroying destroy;
    // Start is called before the first frame update
    void Start()
    {
        /*particlefire.Pause();*/
        fireanimator = GetComponent<Animator>();
        myplayer = FindObjectOfType<playercontroller>();
        
      



    }

    // Update is called once per frame
    void Update()
    {
       
        if (isalive == true)
        {
            xenemymove();
        }
        particlefire.Play();
        fire();
    }

    

    public void fire()
    {
        
        if (Mathf.Abs(Mathf.Abs(gameObject.transform.position.x) - Mathf.Abs(myplayer.transform.position.x)) <= 1f)
        {
            isalive = false;

            fireanimator.SetBool("enemycrabfiring", true);
            
        }
        else
        {
            isalive = true;
            fireanimator.SetBool("enemycrabfiring", false);
        }

    }

    private void xenemymove()
    {
        if (keepmoving)
        {
            if (Mathf.Sign(transform.localScale.x) == 1)
            {
                /*Debug.Log("i am here in xenemymove");*/
                transform.position += new Vector3(-xdirection * Time.deltaTime, 0, 0);

            }
            else
            {
                /*Debug.Log("i am here in yenemymove");*/
                transform.position += new Vector3(xdirection * Time.deltaTime, 0, 0);


            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-transform.localScale.x, 1f);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        string playanimaton = myplayer.currentanimation();
        if (collision.gameObject.name == "player" && playanimaton=="roll")
        {
            keepmoving = false;
            ParticleSystem num=Instantiate(particlefire, transform.position, Quaternion.identity);
            Destroy(gameObject);

            
            


        }
    }


}
