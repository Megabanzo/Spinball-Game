using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPointBumper : MonoBehaviour
{
    public bool turnsOff = false;
    public int points = 1000;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public Light light1;

    public Sprite[] spriteSet;

    private void Awake()
    {
        light1.enabled = false;
    }

    void start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //Plays bumper collision sound
        audioSource.PlayOneShot(clip, volume);
        light1.enabled = true;

        //Changes sprite on collision
        GetComponent<SpriteRenderer>().sprite = spriteSet[1];
        GameMaster.LightBumperHit(this);

        //yield return new WaitForSeconds(1);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (turnsOff)
        {
            StartCoroutine("Off");
        }
    }

    IEnumerator Off()
    {
        yield return new WaitForSeconds(0.08f);
        GetComponent<SpriteRenderer>().sprite = spriteSet[0];
        light1.enabled = false;
    }
}
