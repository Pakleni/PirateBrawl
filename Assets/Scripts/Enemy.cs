using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;

    private GameObject player;    
    private SpriteRenderer sR;
    private Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        sR = gameObject.GetComponent<SpriteRenderer>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        myRigidBody.velocity = new Vector2(0, 0);

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        if (player.transform.position.x < transform.position.x) { sR.flipX = true; }
        else { sR.flipX = false; }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Destroy(gameObject);


        }
    }
}

