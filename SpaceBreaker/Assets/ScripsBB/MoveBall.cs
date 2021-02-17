using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{

    [SerializeField] private float force = 150f; //force applied in ball.
    private Rigidbody2D ball;// ExposedReference to the component rigidbody 2D
    private bool onlyOnce = false; //service only once

    private Transform myParent;// link to the original parent (player)
    private Vector3 iniPos; //local coordinate fron the ball relative to its parent


    private GameManager code; //reference to game manager
    public AudioSource bounce;
    [SerializeField] private float blindSpot = 0.2f; //half of the blind spot

    [SerializeField] private float vforceMin = 0.6f;
    [SerializeField] private float vforceMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        code = GameManager.instance; //recovers game manager (singleton)
        ball = GetComponent<Rigidbody2D>();//recober component rigid body 2D from the ball
        ball.simulated = false; //stop simulation 
        iniPos = transform.localPosition; //will memorize the position of the ball relative to the parent 
        myParent = transform.parent;
    }

    public void init()
    {
        transform.parent = myParent;//meat the parent 
        transform.localPosition = iniPos; // Go back where the parent is now 
        ball.simulated = false;
        ball.velocity = new Vector2(0, 0); //reduce force
        onlyOnce = false; //ready for new service
    }
    // Update is called once per frame
    void Update()
    {   //if button and only once = true
        if (Input.GetButtonUp("Service") && (!onlyOnce))
        {
            onlyOnce = true;    //freeze the service
            ball.simulated = true; //deactivate simulation
            ball.transform.parent = null; // remove ball from it's parent class
            ball.AddForce(new Vector2(force, force)); // Add Force (right, up)
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
            code.Death(); //callfunction death from the game manager 
        }
        else if (collision.gameObject.tag == "Player")
        {
            bounce.Play();
            float diffX = transform.position.x - collision.transform.position.x; //position of ball - position of paddle = re;ative posiotion
            if (diffX < -blindSpot)
            {
                ball.velocity = new Vector2(0, 0);
                ball.AddForce(new Vector2(-force, force)); //left, up
            }
            else if (diffX > blindSpot)
            {
                ball.velocity = new Vector2(0, 0);
                ball.AddForce(new Vector2(force, force)); //right, up
            }
        }

      
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //prevent the ball from moving horizontally
        if (Mathf.Abs(ball.velocity.y) < vforceMin) // check if we are below vforceMin
        {
            float vecX = ball.velocity.x; // save the existing x force
            if (ball.velocity.y < 0) // going down
            {
                ball.velocity = new Vector2(vecX, -vforceMin * vforceMultiplier);
            }
            else // going up
            {
                ball.velocity = new Vector2(vecX, vforceMin * vforceMultiplier);
            }
        }
    }


}
