using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public GameObject weapon;
    private float waitToFire = 0f;
    
    public Joystick leftController;
    public Joystick rightController;
    public Animator anim;
    public Rigidbody2D myRigidBody;
    public SpriteRenderer sR;
    public float fireWaitTime = 1f;
    public bool killable = true;


    // Use this for initialization
    void Start () {
        
        anim.SetBool("Standing", true);
    }
	
	// Update is called once per frame
	void Update () {

        myRigidBody.MovePosition(transform.position + (transform.up * leftController.Vertical * Time.deltaTime * moveSpeed) +
            (transform.right * leftController.Horizontal * Time.deltaTime * moveSpeed));

        
        waitToFire -= Time.deltaTime;
        if (waitToFire < 0)
        {
            
            if (rightController.Horizontal* rightController.Horizontal + rightController.Vertical*rightController.Vertical > 0.9f)
            {
                anim.PlayInFixedTime ("Attack Animation");

                Instantiate(weapon, transform);

                waitToFire = fireWaitTime;
            }

        }
        if ( leftController.Horizontal > 0f ) { sR.flipX = true; }
        else { sR.flipX = false; }

        if ((leftController.Horizontal == 0) && (leftController.Vertical == 0) ) { anim.SetBool("Standing", true); }
        else if (anim.GetBool("Standing") == true) { anim.SetBool("Standing", false); }
        
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Enemy" || other.gameObject.tag == "Weapon") && killable)
        {
            gameObject.SetActive(false);
            
        }
        if (other.gameObject.tag == "END")
        {
            SceneManager.LoadScene(4);

        }
    }
}
