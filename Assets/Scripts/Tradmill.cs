using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tradmill : MonoBehaviour
{
    private bool bounceTriggered;
    public float bounceDelay = 0.05f;
    private float timeLeft = 0f;
    public float rotation;
    public int forceVariance;
    public Sprite[] spriteSet;
    public float wait;
    public bool rotates;
    public int points = 50;
    public AudioClip clip;
    public AudioSource audioSource;
    public bool isSaver;
 

    private GameObject mainPivot;


    public int force = 450;

    private int realForce;

    // Start is called before the first frame update
    void Start()
    {
        mainPivot = GameObject.Find("MainPivot");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotates)
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = 3 * -mainPivot.transform.eulerAngles.z -180;
            gameObject.transform.eulerAngles = tmp;
        }
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            bounceTriggered = false;
        }
        rotation = gameObject.transform.eulerAngles.z;

        if (transform.position.y < 0)
        {
            
            gameObject.GetComponent<EdgeCollider2D>().enabled = true;

        }
        else if (transform.position.y > 0)
        {
            

            gameObject.GetComponent<EdgeCollider2D>().enabled = false;

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball")
        {
            if (isSaver)
            {
                col.transform.position = new Vector3(transform.position.x, transform.position.y, col.transform.position.z);


            }
            else
            {
                GameMaster.TradHit(this);
            }
            audioSource.PlayOneShot(clip);
            Rigidbody2D ball = col.attachedRigidbody;
            
            realForce = force + Random.Range(-forceVariance, forceVariance);
            var direction = new Vector3(-Mathf.Sin(Mathf.Deg2Rad * rotation), Mathf.Cos(Mathf.Deg2Rad * rotation), 0);
            if (bounceTriggered == false)
            {
                ball.velocity = Vector3.zero;
                ball.AddForceAtPosition(direction * realForce, ball.position);
            }
            bounceTriggered = true;
            timeLeft = bounceDelay;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
       if(col.tag == "Ball")
            //Switches sprite back
            StartCoroutine("Anim");
        
    }

    IEnumerator Anim()
    {
        GetComponent<SpriteRenderer>().sprite = spriteSet[1];
        yield return new WaitForSeconds(wait);
        GetComponent<SpriteRenderer>().sprite = spriteSet[2];
        yield return new WaitForSeconds(wait);
        GetComponent<SpriteRenderer>().sprite = spriteSet[3];
        yield return new WaitForSeconds(wait);
        GetComponent<SpriteRenderer>().sprite = spriteSet[0];
    }
}
