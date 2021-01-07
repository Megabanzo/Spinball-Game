using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int cracked = 0;
    public int multiplier = 1;
    public int points = 1000;
    public int colour = 1;
    public Sprite[] sprites;
    public AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;
    public bool resets;
    private bool on = true;



    private void Update()
    {
        if (resets && GameMaster.sectionLights == 6)
        {

            GameMaster.brickReset = true;
            
        }
        if(GameMaster.brickReset == true && resets)
        {
            on = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            cracked = 0;
            StartCoroutine("Wait");
        }
        GetComponent<SpriteRenderer>().sprite = sprites[2 * (colour - 1) + cracked];
        if (transform.position.y < 0 && on)
        {

            gameObject.GetComponent<BoxCollider2D>().enabled = true;

        }
        else if (transform.position.y > 0  || !on)
        {
            

            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(cracked == 1)
        {
            audioSource.PlayOneShot(clip1);
            StartCoroutine("Break");
            
        } else
        {
            audioSource.PlayOneShot(clip2, 0.5f);
            GameMaster.BrickHit(this, false);
            cracked = 1;
        }
    }

    IEnumerator Break()
    {
        yield return new WaitForSeconds(0.08f);
        on = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameMaster.BrickHit(this, true);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        GameMaster.brickReset = false;
        
    }
}
