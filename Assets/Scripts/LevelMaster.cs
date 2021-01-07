//Controls state of the level

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMaster : MonoBehaviour
{
    public float multiTime;
    public float timeLeft;
    public int balls = 3;
    public int activeBalls;
    public int currentPowerUp;
   
    public  GameObject ball;
    public GameObject blockBumpie;
    private GameObject bump;
    public GameObject startGui;
    public Transform n;
    private KeyCode space;

    public GameObject savers;

    public bool feather = false;
    public float featherTime;

    public float bumpieTime;
    public bool bumpie;
    

    public bool freeze = false;
    public float freezeTime;

    public float saveTime;
    public bool save;
    

    public bool mulBall = false;
    public float multTime;
    

    public bool extra = false;
    public float extraTime;
    private int extraMash = 0;
    

    public float powTimeLeft;
    public bool hasPowerUp = false;

   
    private bool lose = false;
    private bool l = false;
    public int randPow;

    public Color32 textColor;
    

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject optionPanel;

  

    public void increaseTimer()
    {
        timeLeft = multiTime;
    }

    public void newBall(GameObject b)
    { 
        n = Instantiate(b).transform;
        activeBalls++;   
    }

    //Random powerup selector
    public void randPowerUp()
    {
        if ((!hasPowerUp) && activeBalls <= 2)
        {
            randPow =  UnityEngine.Random.Range(1, 7);
            hasPowerUp = true;
            if (!(randPow == 6))
            {
                GameObject.Find("SpacebarSmall").GetComponent<SpriteRenderer>().enabled = true;
            }
            switch (randPow)
            {
                case 6:

                    powTimeLeft = saveTime;
                    GameObject.Find("Icons").GetComponent<Icons>().i = 6;
                    textColor = new Color32(0, 148, 255, 255);
                    GameObject.Find("Name").GetComponent<Text>().text = "Ball Saver";
                    break;
                case 5:
                    powTimeLeft = bumpieTime;
                    GameObject.Find("Icons").GetComponent<Icons>().i = 5;
                    textColor = new Color32(230, 0, 240, 255);
                    GameObject.Find("Name").GetComponent<Text>().text = "Bumper";
                    break;
                case 4:
                    powTimeLeft = freezeTime;
                    GameObject.Find("Icons").GetComponent<Icons>().i = 4;
                    textColor = new Color32(0, 248, 255, 255);
                    GameObject.Find("Name").GetComponent<Text>().text = "Time Freeze";
                    break;
                case 3:
                    powTimeLeft = featherTime;
                    GameObject.Find("Icons").GetComponent<Icons>().i = 3;
                    textColor = new Color32(255, 255, 255, 255);
                    GameObject.Find("Name").GetComponent<Text>().text = "Feather";
                    break;
                case 2:
                    powTimeLeft = multTime;
                    GameObject.Find("Icons").GetComponent<Icons>().i = 2;
                    textColor = new Color32(0, 112, 244, 255);
                    GameObject.Find("Name").GetComponent<Text>().text = "MultiBall";
                    GameObject.Find("Mash").GetComponent<Text>().enabled = true;
                    break;
                case 1:
                    powTimeLeft = extraTime;
                    GameObject.Find("Icons").GetComponent<Icons>().i = 1;
                    textColor = new Color32(255, 10, 10, 255);
                    GameObject.Find("Name").GetComponent<Text>().text = "ExtraBall";
                    GameObject.Find("Mash").GetComponent<Text>().enabled = true;
                    break;

            }
        }
    }

    private void Awake()
    {
        StartCoroutine("spaceDelay");
    }
    void Start()
    {
        //newBall(ball);
        pausePanel.SetActive(false);
        optionPanel.SetActive(false);
    }

    void Update()
    {
        if(GameMaster.sectionLights >= 6)
        {
            if(GameMaster.j == 3)
            {
                GameMaster.score += 1000000;
            }
            GameMaster.increaseGlobalMulti();
            GameMaster.sectionLights = 0;
            GameMaster.setColor();
            var buttons = FindObjectsOfType<PointBumpers>();
            foreach (PointBumpers button in buttons)
            {
                button.isOn = false;
            }
        }
        //Pause menu stuff
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab) | Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Return) && optionPanel.activeInHierarchy || Input.GetKeyDown(KeyCode.Space) && optionPanel.activeInHierarchy)
        {
            // Debug.Log("escapetest");
            if (pausePanel.activeInHierarchy == false && optionPanel.activeInHierarchy == false)
            {
                PauseGame();
            } else if (pausePanel.activeInHierarchy == true && optionPanel.activeInHierarchy == false)
            {
                ContinueGame();
            } else {
                optionPanel.SetActive(false);
                pausePanel.SetActive(true);
            }
        }

        //Ball based multiplier
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

        }
        else
        {
            GameMaster.decreaseMulti();
            if (GameMaster.i > 0)
            {
                timeLeft = multiTime;
            }
        }

        
        //Lose conditions
        if (activeBalls <= 0 && l)
        {
            lose = true;
            l = false;
            GameObject.Find("Icons").GetComponent<Icons>().i = 0;
        }

        if (balls <= 1 && lose)
        {
            SceneManager.LoadScene("Enterusername");
        }
        else if (lose)
        {
            balls--;
            lose = false;

        }

        if (activeBalls == 0)
        {
            hasPowerUp = false;
            randPow = 0;
            startGui.SetActive(true);
            if (Input.GetKey(space) && pausePanel.activeInHierarchy == false && optionPanel.activeInHierarchy == false)
            {
                newBall(ball);
                startGui.SetActive(false);
            }
        }


        //PowerUp code
        //feather
        if (randPow == 3 && Input.GetKeyDown(KeyCode.Space))
        {
            feather = true;
            randPow = 0;
            GameObject.Find("SpacebarSmall").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (feather)
        {
            powTimeLeft -= Time.deltaTime;
            if (powTimeLeft < 0)
            {
                hasPowerUp = false;
                feather = false;
                
                GameObject.Find("Icons").GetComponent<Icons>().i = 0;
            }
        }

        //blockBumpie power up
        if (randPow == 5 && Input.GetKeyDown(KeyCode.Space))
        {
            bumpie = true;
            bump = Instantiate(blockBumpie, new Vector3(n.position.x,n.position.y-0.5f,n.position.z), transform.rotation);
            GameObject.Find("SpacebarSmall").GetComponent<SpriteRenderer>().enabled = false;
            randPow = 0;
        }
        if (bumpie)
        {
            powTimeLeft -= Time.deltaTime;
            if (powTimeLeft < 0)
            {
                hasPowerUp = false;
                bumpie = false;
                Destroy(bump);
                
                GameObject.Find("Icons").GetComponent<Icons>().i = 0;
            }
        }



        //freeze
        if ((randPow == 4) && Input.GetKeyDown(KeyCode.Space))
        {
            freeze = true;
            randPow = 0;
            GameObject.Find("SpacebarSmall").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (freeze) {
            powTimeLeft -= Time.deltaTime;
            if (powTimeLeft < 0)
            {
                hasPowerUp = false;
                freeze = false;
                
                GameObject.Find("Icons").GetComponent<Icons>().i = 0;
            }
        }


        //multiball
        if((randPow == 2) && Input.GetKeyDown(KeyCode.Space))
        {
            mulBall = true;
            randPow = 0;
        }
        if (mulBall)
        {
            powTimeLeft -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                newBall(ball);
            }
            if(powTimeLeft < 0)
            {
                hasPowerUp = false;
                mulBall = false;
                GameObject.Find("SpacebarSmall").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Icons").GetComponent<Icons>().i = 0;
                GameObject.Find("Mash").GetComponent<Text>().enabled = false;
            }
        }

        //extraball
        if ((randPow == 1) && Input.GetKeyDown(KeyCode.Space))
        {
            extra = true;
            randPow = 0;
        }
        if (extra)
        {
            powTimeLeft -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                extraMash++;
                if(extraMash >= 2)
                {
                    balls++;
                    extraMash = 0;
                }
                
            }
            if (powTimeLeft < 0)
            {
                hasPowerUp = false;
                extra = false;
                GameObject.Find("SpacebarSmall").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Icons").GetComponent<Icons>().i = 0;
                GameObject.Find("Mash").GetComponent<Text>().enabled = false;
            }
        }
        
        if(randPow == 6)
        {
            save = true;
            randPow = 0;
        }
        if (save)
        {
            savers.SetActive(true);
            powTimeLeft -= Time.deltaTime;
            if(powTimeLeft < 0)
            {
                hasPowerUp = false;
                save = false;
                savers.SetActive(false);
                GameObject.Find("Icons").GetComponent<Icons>().i = 0;

            }

        }
        
    }


    // pause functions
    void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        Cursor.visible = true;
        // Debug.Log("pause");
    }
    void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        Cursor.visible = false;
        // Debug.Log("unpause");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        if ((col.transform == n) && activeBalls < 2)
        {
            GameMaster.decreaseMulti();
        }
        activeBalls--;
        l = true;     
    }

    IEnumerator spaceDelay()
    {
        yield return new WaitForSeconds(0.1f);
        space = KeyCode.Space;
    }
}

