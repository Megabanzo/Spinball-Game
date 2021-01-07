using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBumpers : MonoBehaviour
{
    public bool turnsOff = false;
    public bool isSpring;
    public bool isSection = true;
    public int points = 1000;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip2;
    public float volume = 0.5f;
    public Light light1;
    public bool isBumper;
   

    public bool isOn = false;

    public Sprite[] spriteSet;

    private void Awake()
    {
        if (!isSpring)
        {
            light1.enabled = false;
        }
    }

    void start()
    {
        
        audioSource = gameObject.GetComponent<AudioSource>();
        
    }

     void Update()
    {
        if(transform.position.y < 0 && isBumper)
        {

            gameObject.GetComponent<CircleCollider2D>().enabled = true;

        }
        else if (transform.position.y > 0 && isBumper)
        {


            gameObject.GetComponent<CircleCollider2D>().enabled = false;

        }
        if (isOn)
        {
            
            if (isBumper)
            {
                GetComponent<SpriteRenderer>().sprite = spriteSet[1 + (GameMaster.j * 2)];
                light1.color = GameMaster.colors[GameMaster.j];
                light1.enabled = true;
            }
            else if (isSpring)
            {
                GetComponent<SpriteRenderer>().sprite = spriteSet[1];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = spriteSet[1 + (GameMaster.i * 2)];
                light1.color = GameMaster.colors[GameMaster.i];
                light1.enabled = true;
            }

        }
        else
        {
            
            if (isBumper)
            {
                GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.j * 2)];
                light1.enabled = false;
            }
            else if (isSpring)
            {
                GetComponent<SpriteRenderer>().sprite = spriteSet[0];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
              
                light1.enabled = false;
            }
        }


        if(isSection && GameMaster.sectionLights >= 6)
        {
            isOn = false;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball")
        {
            //Plays bumper collision sound
            audioSource.PlayOneShot(clip, volume);
            audioSource.PlayOneShot(clip2, volume);


            //Changes sprite on collision
            //GetComponent<SpriteRenderer>().sprite = spriteSet[1];
            //Adds points to score
            GameMaster.BumperHit(this);
            if (!isOn)
            {
                isOn = true;
                if (isSection)
                {
                    GameObject.Find("LevelMaster").GetComponent<LevelMaster>().randPowerUp();
                    GameMaster.sectionButtonOn();
                }
            }
            else if (isOn)
            {
                isOn = false;
                if (isSection)
                {
                    GameMaster.sectionButtonOff();
                }
            }
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (turnsOff)
        {
            //Switches sprite back
            StartCoroutine("Off");
        }
    }

    IEnumerator Off()
    {
        yield return new WaitForSeconds(0.08f);
        isOn = false;
    }


    
}
