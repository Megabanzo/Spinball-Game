using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenus : MonoBehaviour
{
    // [SerializeField] private GameObject highscores;
    [SerializeField] private GameObject cover;

    // Start is called before the first frame update
    void Start()
    {
        cover.SetActive(false);
    }

    public void optionScreenOn() {
        cover.SetActive(true);
    }

    public void optionScreenOff() {
        cover.SetActive(false);
    }
}
