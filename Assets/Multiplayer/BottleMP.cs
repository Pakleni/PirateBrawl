using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleMP : MonoBehaviour {
    
    public Rigidbody2D myRigidBody;



    // Use this for initialization
    void Start()
    {
        myRigidBody.angularVelocity = 100;
    }



    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {    
        FindObjectOfType<AudioManager>().Play("BottleBreak");
        Destroy(gameObject);
    }
}
