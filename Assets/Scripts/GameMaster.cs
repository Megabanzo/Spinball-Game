//Class for tracking and controlling game state


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //players score
    public static int score;
    public static int sectionLights = 0;
    public static int[] multi = { 1, 2, 3, 5 };
    public static int i;
    public static Color32[] colors = { new Color32(10, 10, 250, 255), new Color32(10, 230, 0, 255),
            new Color32(250, 210, 8, 255),new Color32(210, 10, 0, 255) };
    public static bool brickReset;

    public static bool firstoption = true;

    public static int j =1;

    public static int skin = 0;

    public static bool invertRotation = false;

    public static void BumperHit(PointBumpers bumper)
    {
        // Add enemy points to player's score
        score += bumper.points *  multi[i] * multi[j];
       
    }

    public static void TradHit(Tradmill trad)
    {
        score += trad.points * multi[i];
    }

    public static void BouncyHit(Bouncy bounce)
    {
        score += bounce.points * multi[i];
    }

    public static void BrickHit(Brick brick, bool broke)
    {
        // Add enemy points to player's score
        if (broke)
        {
            score += brick.points * multi[i] * brick.colour;
        }
        else
        {
            score += brick.points * multi[i] * brick.colour/2;
        }

    }

    public static void LightBumperHit(LightPointBumper bumper)
    {
        // Add enemy points to player's score
        score += bumper.points;

    }

    public static void sectionButtonOn()
    {
        sectionLights++;
    }

    public static void sectionButtonOff()
    {
        sectionLights--;
    }

    public static void increaseMulti()
    {
        if (i < 3)
        { 
            i++;
            GameObject.Find("LevelMaster").GetComponent<LevelMaster>().increaseTimer(); 

        }
    }

    public static void increaseGlobalMulti()
    {
        if (j < 3)
        {
            j++;           
        }
    }

    public static void decreaseMulti()
    {
        if (i > 0)
        {
            i--;
        }
    }

    public static void setColor()
    {
        GameObject.Find("splash_nilfgaard").GetComponent<SpriteRenderer>().color = colors[j];
    }

    public static void InvertR()
    {
        
        if (invertRotation == false)
        {
            invertRotation = true;
        }
        else if (invertRotation == true)
        {
            invertRotation = false;
        }
    }
}

