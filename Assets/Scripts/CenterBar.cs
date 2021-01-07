using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CenterBar : MonoBehaviour
{
    
       void Update()
    {
        if (transform.position.y < 0)
        {
            
            gameObject.GetComponent<EdgeCollider2D>().enabled = true;
            
        }
        else if(transform.position.y > 0)
        {
            
           
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            
        }
    }
}
