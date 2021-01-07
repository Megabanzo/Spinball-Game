using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour

{
    public Text hudScore;
    public Text balls;
    public Text ballMultiplier;
    public Text globalMultiplier;
    private int currentScore;
    private int currentBalls;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        ballMultiplier.text = GameMaster.multi[GameMaster.i].ToString("n0");
        ballMultiplier.color = GameMaster.colors[GameMaster.i];
        globalMultiplier.text =  GameMaster.multi[GameMaster.j].ToString("n0");
        globalMultiplier.color = GameMaster.colors[GameMaster.j];
        balls.text = "Balls Left: " + GameObject.Find("LevelMaster").GetComponent<LevelMaster>().balls.ToString("n0");
        if (currentScore != GameMaster.score)
        {
            hudScore.color = new Color32(250, 200, 10, 255);
            currentScore = GameMaster.score;
            hudScore.text = "Score: " + currentScore.ToString("n0");
            
            StartCoroutine("delay");
        }
        if (currentBalls != GameObject.Find("LevelMaster").GetComponent<LevelMaster>().balls)
        {
            balls.color = new Color32(250, 200, 10, 255);
            currentBalls = GameObject.Find("LevelMaster").GetComponent<LevelMaster>().balls;
            balls.text = "Balls Left: " + currentBalls.ToString("n0");

            StartCoroutine("delay2");
        }

    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.05f);
        hudScore.color = new Color32(255, 0, 210, 255);

    }

    IEnumerator delay2()
    {
        yield return new WaitForSeconds(0.05f);
        balls.color = new Color32(255, 0, 210, 255);

    }
}
