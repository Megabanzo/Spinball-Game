using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 org; //Variable used to store original
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    private Transform lt;
    private int i;
    public  Sprite[] skinSet;



    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        org = this.transform.position;
        lt = transform.GetChild(0);
        changeSkin(skinSet[GameMaster.skin]);
        
    }

    public void changeSkin(Sprite skin)
    {
        GetComponent<SpriteRenderer>().sprite = skin;
    }

    void Update()
    {
        if (GameMaster.i != i)
        {
            switchMultiLight();
            i = GameMaster.i;
        }
        if (GameObject.Find("LevelMaster") != null)
        {
            if (GameObject.Find("LevelMaster").GetComponent<LevelMaster>().feather)
            {
                transform.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
            }
            else
            {
                transform.GetComponent<Rigidbody2D>().gravityScale = 1f;
            }

            if (GameObject.Find("LevelMaster").GetComponent<LevelMaster>().freeze)
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                transform.GetComponent<Rigidbody2D>().isKinematic = true;
                transform.GetComponent<Rigidbody2D>().simulated = false;
            }
            else
            {
                transform.GetComponent<Rigidbody2D>().isKinematic = false;
                transform.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
    }

    public void switchMultiLight()
    {
        switch (GameMaster.i)
        {
            case 3:
                lt.GetComponent<Light>().color = new Color32(255, 10, 5, 255);
                break;
            case 2:
                lt.GetComponent<Light>().color = new Color32(245, 240, 5, 255);
                break;
            case 1:
                lt.GetComponent<Light>().color = new Color32(25, 255, 5, 255);
                break;
            case 0:
                lt.GetComponent<Light>().color = new Color32(0, 157, 255, 255);
                break;
        }

    }

    //Collision detector to play ball sound
    void OnCollisionEnter2D(Collision2D evt)
    {
            audioSource.PlayOneShot(clip, volume);
        if (GameObject.Find("LevelMaster") != null)
        {
            GameObject.Find("LevelMaster").GetComponent<LevelMaster>().n = transform;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        audioSource.PlayOneShot(clip, volume);
        Debug.Log("Does this ever happen?");
        if (GameObject.Find("LevelMaster") != null)
        {
            GameObject.Find("LevelMaster").GetComponent<LevelMaster>().n = transform;
        }
    }



    // Update is called once per frame
    /* void Update()
     {
         //Resets ball if lost(testing purposes only)
         if (Input.GetKeyDown(KeyCode.R))
         {
             transform.position = new Vector3(1,2,0);
         }
     }*/
}
