using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu2 : MonoBehaviour
{
    // Start is called before the first frame update
    private float angle;
    public Button play;
    public Button options;
    public Button credits;
    public Button nothing;
    public GameObject[] tut1;
    public GameObject[] tut2;
    public GameObject[] tut3;
    public bool wayneFix;
    public static int tutorialIndex = 0;

    void Start()
    {
        if (wayneFix)
        {
            tutorialIndex = 0;
        }

        GameMaster.score = 0;
        GameMaster.i = 0;
        GameMaster.j = 0;
        GameMaster.sectionLights = 0;
        Debug.Log(GameMaster.invertRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialIndex == 1)
        {
            foreach(GameObject obj in tut1)
            {
                obj.GetComponent<SpriteRenderer>().enabled = true;
            }

            foreach (GameObject obj in tut2)
            {
                obj.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (GameObject obj in tut3)
            {
                obj.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (tutorialIndex == 2)
        {
            foreach (GameObject obj in tut1)
            {
                obj.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (GameObject obj in tut2)
            {
                obj.GetComponent<SpriteRenderer>().enabled = true;
            }

            foreach (GameObject obj in tut3)
            {
                obj.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (tutorialIndex == 3)
        {
            foreach (GameObject obj in tut1)
            {
                obj.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (GameObject obj in tut2)
            {
                obj.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (GameObject obj in tut3)
            {
                obj.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        angle = transform.GetComponent<Rotation>().currentAngle;
        if ((-30f < angle) && (angle < 30f))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MainMenu2.tutorialIndex = 0;
                SceneManager.LoadScene("CirclePrototype");

            }
            play.Select();
            




        }
        else if ((90 < angle) && (angle < 150f))
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                SceneManager.LoadScene("Credits");

            }
            credits.Select();
            


            
        }
        else if ((-150 < angle) && (angle < -90f))
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                SceneManager.LoadScene("Options");

            }
            options.Select();

            


        }
        else
        {
            nothing.Select();
        }
    }

    public void tutNext(int index)
    {
        if (!wayneFix) { 
            if (index == 2)
            {
                StartCoroutine("Next1");
            }
            else
            {
                StartCoroutine("Next2");
            }
        }
    }

    IEnumerator Next1()
    {
        yield return new WaitForSeconds(2f);
        if (2 > tutorialIndex)
        {
            tutorialIndex = 2;
        }
    }
    IEnumerator Next2()
    {
        yield return new WaitForSeconds(2f);
        if (3 > tutorialIndex)
        {
            tutorialIndex = 3;
        }
    }
}
