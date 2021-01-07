using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGone : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (transform.position.y < 0)
        {

            gameObject.GetComponent<PolygonCollider2D>().enabled = true;

        }
        else if (transform.position.y > 0)
        {


            gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        }
    }
}
