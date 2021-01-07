using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_ball_select : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] skinSet;

    void Start()
    {
        changeSkin(skinSet[GameMaster.skin]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSkin(Sprite skin)
    {
        GetComponent<SpriteRenderer>().sprite = skin;
    }
}
