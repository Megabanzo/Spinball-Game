
// Class for controlling right flipper

using UnityEngine;
using System.Collections;

public class FlipControlRight : MonoBehaviour
{

    //controll variables
    public bool isKeyPress = false;
    public bool isTouched = false;

    //sound variables

    public AudioClip clip;
    public AudioSource audioSource;
    public float volume = 0.5f;

    public float speed;
    private HingeJoint2D myHingeJoint;
    private JointMotor2D motor2D;

    private ParticleSystem particle;
    public GameObject pSystem;




    void Start()
    {
        
        myHingeJoint = GetComponent<HingeJoint2D>();
        motor2D = myHingeJoint.motor;
        particle = pSystem.GetComponent<ParticleSystem>();
    }
	
    // Update is called once per frame
    //sets isKeyPress used for FixedUpdate()
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (MainMenu2.tutorialIndex == 0 || MainMenu2.tutorialIndex == 2))
        {

            particle.Play();
            if (clip != null)
            {
                audioSource.PlayOneShot(clip, volume);
            }
            isKeyPress = true;
            if (MainMenu2.tutorialIndex != 0)
            {
                FindObjectOfType<MainMenu2>().tutNext(3);
            }
        }
				
        if (Input.GetKeyUp(KeyCode.E))
        {		
            isKeyPress = false;
        }
    }


    void FixedUpdate()
    {
        // On Press keyboard, activates hingemotors for Right Flipper
        if (isKeyPress == true && isTouched == false || isKeyPress == false && isTouched == true)
        {
                       
            motor2D.motorSpeed = -speed;
            myHingeJoint.motor = motor2D;
        }
        else
        {
            
            motor2D.motorSpeed = speed;
            myHingeJoint.motor = motor2D;
        }
    }
	
}
