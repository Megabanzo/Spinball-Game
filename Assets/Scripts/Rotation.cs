using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotation : MonoBehaviour
{

    //Public variable used to adjust speed on the fly
    public float maxSpeed = 0.5f;
    
    public float acceleration = 1f;
    public float deceleration = 1f;
    
    //Sets the maximum rotation
    public float maximumAngle = 30.0f;


    public bool invertRot;

    public float currentAngle;

    public float mouseSpeed;

    public float rotation;

    public float realSpeed = 0f;
    public AudioSource audioSource;
    public AudioClip clip;
    private float soundAngle;
    public float volume = 0.1f;

    public KeyCode right = KeyCode.RightArrow;
   // private KeyCode d = KeyCode.D;
    public KeyCode left = KeyCode.LeftArrow;
    //private KeyCode a = KeyCode.A;



    private void Start()
    {
        Cursor.visible = false;
        Debug.Log("Rotation" + invertRot);

        if (GameMaster.invertRotation)
        {
            right = KeyCode.LeftArrow;
            left = KeyCode.RightArrow;
            //a = KeyCode.D;
            //d = KeyCode.A;          
        }
    }

    public void invertroation() 
    {
        if (right == KeyCode.RightArrow)
        {
            right = KeyCode.LeftArrow;
            left = KeyCode.RightArrow;
        } else {
            right = KeyCode.RightArrow;
            left = KeyCode.LeftArrow;
        }
    }
    void Update()
    {
        if(Math.Abs(soundAngle - currentAngle) > 4)
        {
            audioSource.PlayOneShot(clip, volume);
            soundAngle = currentAngle;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        currentAngle = transform.localEulerAngles.z;
        currentAngle = (currentAngle > 180) ? currentAngle - 360 : currentAngle;

        //rotation = Input.GetAxis("Mouse X");


        //realSpeed = startSpeed * Time.deltaTime;

        transform.Rotate(0, 0, realSpeed);

        //Key rotatiob

        if (Input.GetKey(right) /*|| Input.GetKey(d)*/ && (MainMenu2.tutorialIndex == 0 || MainMenu2.tutorialIndex == 3)) 
        {
            
            if (currentAngle > -maximumAngle)
            {
                if (realSpeed > -maxSpeed * Time.deltaTime)
                {
                    realSpeed -= acceleration * Time.deltaTime;
                }
                
            }

        }
        else if (Input.GetKey(left) /*|| Input.GetKey(a)*/ && (MainMenu2.tutorialIndex == 0 || MainMenu2.tutorialIndex == 3)) 
        {
            
            if (currentAngle < maximumAngle)
            {
                if (realSpeed < maxSpeed * Time.deltaTime)
                {
                    realSpeed += acceleration * Time.deltaTime;
                }
                
            }
        }
        else
        {
            if(Math.Abs(realSpeed) < 0.2)
            {
                realSpeed = 0;
            }
            else if(realSpeed < 0)
            {
                realSpeed += deceleration * Time.deltaTime;
            }
            else if(realSpeed > 0)
            {
                realSpeed -= deceleration * Time.deltaTime;
            }
        }

        

        //Mouse Movement Deprecated
        //if (rotation > 0)
        //{
        //    if (currentAngle > -maximumAngle)
        //    {
        //        transform.Rotate(0, 0, -realSpeed * Math.Abs(rotation));
        //    }
        //}
        //if (rotation < 0)
        //{
        //    if (currentAngle < maximumAngle)
        //    {
        //        transform.Rotate(0, 0, realSpeed * Math.Abs(rotation));
        //    }
        //}



    }
}
