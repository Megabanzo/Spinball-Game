using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiButton : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).GetComponent<PointBumpers>().isOn && transform.GetChild(1).GetComponent<PointBumpers>().isOn)
        {
            GameMaster.increaseMulti();
            transform.GetChild(0).GetComponent<PointBumpers>().isOn = false;
            transform.GetChild(1).GetComponent<PointBumpers>().isOn = false;
        }
        
    }
}
