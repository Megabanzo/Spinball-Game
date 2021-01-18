// Class for controlling left flipper

using UnityEngine;
using System.Collections;

public class FlipControlLeft : MonoBehaviour
{
   //control variables 
    public bool isKeyPress = false;
    public bool isTouched = false;

    //sound variables
    public AudioClip clip;
    public AudioSource audioSource;
    public float volume = 0.5f;

    
    public float speed;// controls flipper speed
    private HingeJoint2D myHingeJoint;
    private JointMotor2D motor2D;
    private SpriteRenderer renderer;


    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        myHingeJoint = GetComponent<HingeJoint2D>();
        motor2D = myHingeJoint.motor;
    }

    // sets isKeyPress used for fixed update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && (MainMenu2.tutorialIndex == 0 || MainMenu2.tutorialIndex == 1))
        {
            if (clip != null)
            {
                audioSource.PlayOneShot(clip, volume);
            }
            //renderer.color = new Color(0f, 255f, 0f, 1f);
            isKeyPress = true;
            if(MainMenu2.tutorialIndex != 0)
            {
                FindObjectOfType<MainMenu2>().tutNext(2);
            }
        }		
        if (Input.GetKeyUp(KeyCode.Q))
        {
            isKeyPress = false;
            //renderer.color = new Color(255f, 100f, 0f, 1f);
        }		
    }

   
    void FixedUpdate()
    {
        // on press keyboard, activates hinge motor for left flipper
        if (isKeyPress == true && isTouched == false || isKeyPress == false && isTouched == true)
        {				
            
            motor2D.motorSpeed = speed;
            myHingeJoint.motor = motor2D;
        }
        else
        {
            
            motor2D.motorSpeed = -speed;
            myHingeJoint.motor = motor2D;		
        }

    }
}


