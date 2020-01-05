using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelleton : MonoBehaviour {


    public float moveSpeed;

    private float waitToMove = 0f;
    private bool hit = false;

    private GameObject player;
    private SpriteRenderer sR;
    private Rigidbody2D myRigidBody;
    private Animator anim;    
    private CapsuleCollider2D capsuleCollider;

    // Use this for initialization
    void Start () {


        player = GameObject.Find("Player");
        sR = gameObject.GetComponent<SpriteRenderer>();
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();              
        capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();

    }
	
	// Update is called once per frame
	void Update () {

        myRigidBody.velocity = new Vector2(0, 0);

        waitToMove -= Time.deltaTime;

        if (waitToMove < 0)
        {
            if (player.transform.position.x < transform.position.x) { sR.flipX = true; }
            else { sR.flipX = false; }
            gameObject.GetComponent<AudioSource>().mute = false;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            anim.PlayInFixedTime("Skell Default");
            capsuleCollider.enabled = true;
        }
        



    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {

            if (hit == false)
            {
                gameObject.GetComponent<AudioSource>().mute = true;
                FindObjectOfType<AudioManager>().Play("SkelletonDrop");
                hit = true;
                anim.PlayInFixedTime("Skelle Hit");
                waitToMove = 2;
                capsuleCollider.enabled = false;

            }
            else { Destroy(gameObject); FindObjectOfType<AudioManager>().Play("SkelletonDrop"); }
        }


    }
}
