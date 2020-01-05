using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour {


    private Joystick rightController;
    public Rigidbody2D myRigidBody;
    public float bottleSpeed;
    public bool destroyable = true;



    // Use this for initialization
    void Start()
    {

        //myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.angularVelocity = 100;
        rightController = GetComponentInParent<PlayerController>().rightController;
        //GameObject.FindGameObjectWithTag("Right Controller").GetComponent<SimpleTouchController>();
        myRigidBody.velocity = new Vector2(rightController.Horizontal * bottleSpeed, rightController.Vertical * bottleSpeed);

    }

    
        
	// Update is called once per frame
	void Update () {
        //if (myRigidBody.velocity == new Vector2(0, 0)) { Destroy(gameObject); }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (destroyable)
        {
            FindObjectOfType<AudioManager>().Play("BottleBreak");
            Destroy(gameObject);
        }
    }
}
