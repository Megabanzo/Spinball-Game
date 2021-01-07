using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUi : MonoBehaviour
{
    // Start is called before the first frame update
    public Text powerUpTime;
    public Text name;
    public Text mash;
    public GameObject space;
    public GameObject powBox;

    // Update is called once per frame
    void Update()
    {
        
        if (GameObject.Find("LevelMaster").GetComponent<LevelMaster>().hasPowerUp)
        {
            powerUpTime.GetComponent<Text>().enabled = true;
            name.GetComponent<Text>().enabled = true;
            powerUpTime.GetComponent<Text>().color = GameObject.Find("LevelMaster").GetComponent<LevelMaster>().textColor;
            name.GetComponent<Text>().color = GameObject.Find("LevelMaster").GetComponent<LevelMaster>().textColor;
            powerUpTime.text = GameObject.Find("LevelMaster").GetComponent<LevelMaster>().powTimeLeft.ToString("n1");
            space.GetComponent<SpriteRenderer>().enabled = true;
            powBox.GetComponent<SpriteRenderer>().enabled = true;

        }
        else
        {
            mash.GetComponent<Text>().enabled = false;
            powerUpTime.GetComponent<Text>().enabled = false;
            name.GetComponent<Text>().enabled = false;
            space.GetComponent<SpriteRenderer>().enabled = false;
            powBox.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
