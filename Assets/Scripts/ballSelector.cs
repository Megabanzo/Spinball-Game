using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSelector : MonoBehaviour
{
    // ball images


    [SerializeField] private GameObject[] skinSet;
    public AudioSource sound;


    // Start is called before the first frame update
    void Start()
    {

        /**if (GameMaster.skin == skinSet.Length)
        {
            GameMaster.skin = 0;
        }
        else
        {
            GameMaster.skin++;
        }*/
        changeSkin(skinSet[GameMaster.skin]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right();
            sound.Play();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left();
            sound.Play();
        }
    }

    public void changeSkin(GameObject skin)
    {
        skin.SetActive(true);
    }

    public void hideSkin(GameObject skin)
    {
        skin.SetActive(false);
    }

    public void right()
    {
        hideSkin(skinSet[GameMaster.skin]);
        if (GameMaster.skin == skinSet.Length-1)
        {
            GameMaster.skin = 0;
        } else
        {
            GameMaster.skin++;
        }
        changeSkin(skinSet[GameMaster.skin]);
    }

    public void left()
    {
        hideSkin(skinSet[GameMaster.skin]);
        if (GameMaster.skin == 0)
        {
            GameMaster.skin = skinSet.Length-1;
        }
        else
        {
            GameMaster.skin--;
        }
        changeSkin(skinSet[GameMaster.skin]);
    }
}
