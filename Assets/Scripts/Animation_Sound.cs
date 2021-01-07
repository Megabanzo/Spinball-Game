using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Sound : MonoBehaviour
{
    public AudioClip bounce;
    public AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Bounce()
    {
        audioS.PlayOneShot(bounce);
    }
}
