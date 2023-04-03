using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charizardfire : MonoBehaviour
{
    [SerializeField] ParticleSystem pr;
    // Start is called before the first frame update
    void Start()
    {
         var em = pr.GetComponent<ParticleSystem>().emission;
         em.enabled = false;
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void turnonfire()
    {
        var em = pr.GetComponent<ParticleSystem>().emission;
        em.enabled = true;
    }
    void turnofffire()
    {
        var em = pr.GetComponent<ParticleSystem>().emission;
        em.enabled = false;
    }

}
