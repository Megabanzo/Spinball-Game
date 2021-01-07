using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject continuePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject optionPanel;
    public AudioSource sound;

    void Start()
    {
        Cursor.visible = true;
        continuePanel.SetActive(true);
        optionsPanel.SetActive(false);
        exitPanel.SetActive(false);
        optionPanel.SetActive(false);
    }


    void Update()
    {
        // when up or down arrow is pressed
        if (Input.GetKeyDown (KeyCode.DownArrow) && optionPanel.activeInHierarchy == false)
        {
            if (continuePanel.activeInHierarchy)
            {
                continuePanel.SetActive(false);
                optionsPanel.SetActive(true);
                sound.Play();
            } else if (optionsPanel.activeInHierarchy)
            {
                optionsPanel.SetActive(false);
                exitPanel.SetActive(true);
                sound.Play();
            }
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && optionPanel.activeInHierarchy == false)
        {
            if (optionsPanel.activeInHierarchy)
            {
                optionsPanel.SetActive(false);
                continuePanel.SetActive(true);
                sound.Play();
            } else if (exitPanel.activeInHierarchy)
            {
                exitPanel.SetActive(false);
                optionsPanel.SetActive(true);
                sound.Play();
            }
        }

        // when enter key is pressed is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (optionPanel.activeInHierarchy) {
                gameObject.SetActive(false);
                optionPanel.SetActive(true);
            }
            // check if continue is active
            else if (continuePanel.activeInHierarchy)
            {
                continuebutton();
            }
            // check if option is active
            else if (optionsPanel.activeInHierarchy)
            {
                optionsButton();
            }
            // check if exit is active
            else
            {
                exitButton();
            }
        }
    }

    public void continuebutton() {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void optionsButton() {
        optionPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void exitButton() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = false;
    }
}