using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crabfire : MonoBehaviour
{
    [SerializeField] GameObject aag;
    [SerializeField] GameObject aag1;
    public void aagfiring()
    {
   
        
       var rightfire= Instantiate(aag, new Vector2(transform.position.x+1f,transform.position.y+1f), Quaternion.identity);
       var leftfire = Instantiate(aag1, new Vector2(transform.position.x - 1f, transform.position.y+1f), Quaternion.identity);
        /*  leftfire.GetComponent<Rigidbody2D>().AddForce(transform.up*10f);
   */
        rightfire.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, 0);
        leftfire.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0);
        Destroy(rightfire, 1f);
        Destroy(leftfire, 1f);
    }
}
