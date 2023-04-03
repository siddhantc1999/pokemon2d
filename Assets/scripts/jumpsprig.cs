using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpsprig : MonoBehaviour
{
    Rigidbody2D rb;
    Animator myanimator;
    [SerializeField] int thrust = 2;
    // Start is called before the first frame update
    void Start()
    {
        myanimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        /*rb = collision.gameObject.GetComponent<Rigidbody2D>();
       
        if(collision.gameObject.name=="player")
        {
            Debug.Log("i am in player");

            myanimator.SetTrigger("moving");
            rb.AddForce(transform.forward * thrust);
           
        }
       */
       
    }
}
