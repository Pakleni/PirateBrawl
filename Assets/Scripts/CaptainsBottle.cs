using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainsBottle : MonoBehaviour {

    private GameObject player;
    private Rigidbody2D myRigidBody;
    private float bottleSpeed;
    private Transform captainTransform;

    // Use this for initialization
    void Start () {

        bottleSpeed = gameObject.GetComponentInParent<Captain>().bottleSpeed;
        captainTransform = gameObject.GetComponentInParent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.angularVelocity = 100;
        player = GameObject.Find("Player");

        if (player)
        {
            myRigidBody.velocity = new Vector2((player.transform.position.x - captainTransform.position.x) * bottleSpeed, (player.transform.position.y - captainTransform.position.y) * bottleSpeed);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        FindObjectOfType<AudioManager>().Play("BottleBreak");
        Destroy(gameObject);
    }
}
