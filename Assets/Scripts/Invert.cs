using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invert : MonoBehaviour
{
    public Toggle toggle;
    GameObject myEventSystem;
    void Start()
    {
        
        toggle.isOn = GameMaster.invertRotation;
        toggle.onValueChanged.AddListener(delegate
        {
            ToggleValueChanged(toggle);
        });

        myEventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    
    void ToggleValueChanged(Toggle change)
    {
        
        GameMaster.invertRotation = !GameMaster.invertRotation;
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

    }
}
