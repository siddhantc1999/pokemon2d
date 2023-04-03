using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beesattack : MonoBehaviour
{
    // Start is called before the first frame update
    playercontroller myplayercontroller;
    Animator myanimator;
    Vector2 myvelocity;
    Vector2 myfirstposition;
    void Start()
    {
        myplayercontroller = FindObjectOfType<playercontroller>();
        myvelocity = myplayercontroller.GetComponent<Rigidbody2D>().velocity;
        myanimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        checkposition();
        
    }

    public void checkposition()
    {
        if(Mathf.Abs(Mathf.Abs(transform.position.x)-Mathf.Abs(myplayercontroller.transform.position.x))<1f && myvelocity==new Vector2(0,0))
        {
            myanimator.SetBool("attack",true);
            Vector3 finalposition = myplayercontroller.transform.position + new Vector3(0.3f, 0.3f, 0);
            Vector3 myfirstposition = transform.position;
            /*StartCoroutine(movebee());*/
            if (transform.position!= finalposition)
            {

                transform.position = Vector3.MoveTowards(transform.position, finalposition+new Vector3(0.5f,0.5f),0.25f);
            }
            /*else
            if(transform.position==myplayercontroller.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position,myfirstposition,0.5f);
            }*/
        }
        /*StartCoroutine(restartmovebee());
        myanimator.SetBool("attack", false);*/


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = Vector3.MoveTowards(transform.position, myfirstposition, 0.5f);
    }


    /* IEnumerator movebee()
     {
         Vector2 startposition = transform.position;
         Vector2 myfirstposition = startposition;
         Debug.Log("myfirstposition"+myfirstposition);
         Vector2 endposition = myplayercontroller.transform.position;
         float moveposition = 0f;

         while(moveposition<1f)
         {
             moveposition += Time.deltaTime*0.1f;
             transform.position = Vector2.Lerp(startposition,endposition+(new Vector2(1,1)),moveposition);
         }
         yield  return new WaitForEndOfFrame(); 

     }
     IEnumerator restartmovebee()
     {
         Vector2 startposition = transform.position;
         Vector2 endposition = myfirstposition;
         float moveposition = 0f;
         Debug.Log("restartmovebee");
         while (moveposition < 0.1f)
         {
             moveposition += Time.deltaTime * 0.1f;
             transform.position = Vector2.Lerp(startposition, endposition, moveposition);
         }
         yield return new WaitForEndOfFrame();

     }*/
}
