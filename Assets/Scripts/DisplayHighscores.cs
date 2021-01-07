using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour {

	public Text[] highscoreFields;
	Highscores highscoresManager;

	void Start() {
		for (int i = 0; i < highscoreFields.Length; i ++) {
            if (i + 1 < 10)
            {
                highscoreFields[i].text = "  " + (i + 1) + ". Fetching...";
            } else
            {
                highscoreFields[i].text = i + 1 + ". Fetching...";
            }

		}

				
		highscoresManager = GetComponent<Highscores>();
		StartCoroutine("RefreshHighscores");
	}
	
	public void OnHighscoresDownloaded(Highscore[] highscoreList) {
        int maxlength = 0;
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            if (i < highscoreList.Length && highscoreList[i].username.Length > maxlength)
            {
                maxlength = highscoreList[i].username.Length;
            }
        }
		for (int i = 0; i < highscoreFields.Length; i++) {
            if (i + 1 < 10)
            {
                highscoreFields[i].text = "  " + (i + 1) + ". ";
            }
            else
            {
                highscoreFields[i].text = i + 1 + ". ";
            }
            if (i < highscoreList.Length) {
                highscoreFields[i].text += string.Format(highscoreList[i].username + " - " + highscoreList[i].score);
			}
		}
	}
	
	IEnumerator RefreshHighscores() {
		while (true) {
			highscoresManager.DownloadHighscores();
			yield return new WaitForSeconds(30);
		}
	}
}