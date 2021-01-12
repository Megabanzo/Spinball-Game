using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinkies : MonoBehaviour
{

    public GameObject[] circles;
    public Sprite[] spriteSet;
    public float timer;
    public float interval = 0.5f;
    public bool inverted = false;



    // Start is called before the first frame update
    void Start()
    {
        if (inverted)
        {
            Array.Reverse(circles);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        circles[0].GetComponent<Light>().color = GameMaster.colors[GameMaster.i];
        circles[1].GetComponent<Light>().color = GameMaster.colors[GameMaster.i];
        circles[2].GetComponent<Light>().color = GameMaster.colors[GameMaster.i];
        circles[3].GetComponent<Light>().color = GameMaster.colors[GameMaster.i];

        if (timer > 4 * interval)
        {
            timer = 0;
        }
        if (timer <= interval)
        {
            circles[0].GetComponent<SpriteRenderer>().sprite = spriteSet[1 + (GameMaster.i * 2)];
            circles[1].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
            circles[2].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
            circles[3].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];

            circles[0].GetComponent<Light>().enabled = true;
            circles[1].GetComponent<Light>().enabled = false;
            circles[2].GetComponent<Light>().enabled = false;
            circles[3].GetComponent<Light>().enabled = false;

        }
        else if(interval < timer && timer <= interval * 2 )
        {
            circles[0].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
            circles[1].GetComponent<SpriteRenderer>().sprite = spriteSet[1 + (GameMaster.i * 2)];
            circles[2].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
            circles[3].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];

            circles[0].GetComponent<Light>().enabled = false;
            circles[1].GetComponent<Light>().enabled = true;
            circles[2].GetComponent<Light>().enabled = false;
            circles[3].GetComponent<Light>().enabled = false;
        }
        else if (interval * 2 < timer && timer <= interval * 3)
        {
            circles[0].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
            circles[1].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
            circles[2].GetComponent<SpriteRenderer>().sprite = spriteSet[1 + (GameMaster.i * 2)];
            circles[3].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
            
            circles[0].GetComponent<Light>().enabled = false;
            circles[1].GetComponent<Light>().enabled = false;
            circles[2].GetComponent<Light>().enabled = true;
            circles[3].GetComponent<Light>().enabled = false;


        }
        else if (interval * 3 < timer && timer <= interval * 4)
        {
            circles[0].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
            circles[1].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
            circles[2].GetComponent<SpriteRenderer>().sprite = spriteSet[0 + (GameMaster.i * 2)];
            circles[3].GetComponent<SpriteRenderer>().sprite = spriteSet[1 + (GameMaster.i * 2)];

            circles[0].GetComponent<Light>().enabled = false;
            circles[1].GetComponent<Light>().enabled = false;
            circles[2].GetComponent<Light>().enabled = false;
            circles[3].GetComponent<Light>().enabled = true;
        }
    }
}
