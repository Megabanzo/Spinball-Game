using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icons : MonoBehaviour
{
    public Sprite[] spriteSet;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<SpriteRenderer>().sprite = spriteSet[1];
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = spriteSet[i];
    }
}
