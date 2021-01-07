using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    private bool bounceTriggered;
    public float bounceDelay = 0.05f;
    private float timeLeft = 0f;
    public float rotation;
    public int forceVariance;
    public AudioClip clip, clip1;
    public AudioSource audioSource;
    public int points = 50;

    public Sprite[] spriteSet;
    
    
    public int force = 450;

    private int realForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        GameMaster.BouncyHit(this);
        StartCoroutine("Blink");
        Rigidbody2D ball = col.attachedRigidbody;
        audioSource.PlayOneShot(clip ,0.5f);
        audioSource.PlayOneShot(clip1, 0.15f);

        realForce = force + Random.Range(-forceVariance, forceVariance);
        var direction = new Vector3(-Mathf.Sin(Mathf.Deg2Rad * rotation), Mathf.Cos(Mathf.Deg2Rad * rotation), 0);
        if (bounceTriggered == false)
        {
               
                ball.AddForceAtPosition(direction * realForce, ball.position);
        }
        bounceTriggered = true;
        timeLeft = bounceDelay;
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().sprite = spriteSet[1];
        yield return new WaitForSeconds(0.08f);
        GetComponent<SpriteRenderer>().sprite = spriteSet[0];
    }
}
