using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Username : MonoBehaviour {

    public GameObject textDisplay;
    public InputField inputField;
    public GameObject usernameText;
    public string username;
    public GameObject spacebar;

    private string tempName;

    private void Awake() {
        usernameText.SetActive(false);
        gameObject.SetActive(true);
        inputField.Select();
        spacebar.SetActive(false);
    }

    void FixedUpdate() {
        // Allows the user to press enter instead of the button
        if (Input.GetKey(KeyCode.Return) && gameObject.active) {
            setName();
        }
        // Allows the user to close the input username panel
        if (Input.GetKeyDown("escape") && gameObject.active) {
            closePanel();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void setName() {
        if (inputField.text.ToString() != "") {
            usernameText.SetActive(true);
            username = inputField.text.ToString();
            textDisplay.GetComponent<Text>().text = username + " - " + GameMaster.score;
            gameObject.SetActive(false);
            inputField.text = "";
            // Add score
            if (GameMaster.score != 0)
            {
                Highscores.AddNewHighscore(username, GameMaster.score);
            }
            spacebar.SetActive(true);
        } else {
            closePanel();
        }
    }

    // This is used for username reset button
    // public void resetName() {
    //     usernameText.SetActive(true);
    //     gameObject.SetActive(true);
    //     tempName = textDisplay.GetComponent<Text>().text;
    //     textDisplay.GetComponent<Text>().text = "";
    //     inputField.Select();
    // }

    public void closePanel() {
        textDisplay.GetComponent<Text>().text = tempName;
        gameObject.SetActive(false);
        spacebar.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
    /**
    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.skin.label.alignment = TextAnchor.UpperLeft;
        GUI.skin.label.fontSize = 20;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(400, 400, 500, 100), "Press Space to return to main menu");

    }*/
}
