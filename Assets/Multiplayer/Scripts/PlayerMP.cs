using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMP : NetworkBehaviour {

    public float moveSpeed;
    public GameObject weapon;
    private float waitToFire = 0f;
    public float bottleSpeed;

    public SimpleTouchController leftController;
    public SimpleTouchController rightController;

    public Animator anim;
    public Rigidbody2D myRigidBody;
    public SpriteRenderer sR;
    private float fireWaitTime = 1f;


    // Use this for initialization
    void Start () {
        anim.SetBool("Standing", true);
    }
	
	// Update is called once per frame
	void Update () {
		
        if(hasAuthority)
        {

            if (!leftController && !rightController)
            {

                leftController = GameObject.FindGameObjectWithTag("Left Controller").GetComponent<SimpleTouchController>();
                rightController = GameObject.FindGameObjectWithTag("Right Controller").GetComponent<SimpleTouchController>();
            }
            myRigidBody.MovePosition(transform.position + (transform.up * leftController.GetTouchPosition.y * Time.deltaTime * moveSpeed) +
            (transform.right * leftController.GetTouchPosition.x * Time.deltaTime * moveSpeed));

            waitToFire -= Time.deltaTime;
            if (waitToFire < 0)
            {

                if (rightController.GetTouchPosition.x > 0.9f || rightController.GetTouchPosition.y > 0.9f || rightController.GetTouchPosition.x < -0.9f || rightController.GetTouchPosition.y < -0.9f)
                {

                    CmdAttack(rightController.GetTouchPosition,bottleSpeed);

                    waitToFire = fireWaitTime;
                }

            }

            if (leftController.GetTouchPosition.x > 0f) { CmdFlipMe(true); }
            else { CmdFlipMe(false); }

            if (leftController.GetTouchPosition == new Vector2(0, 0)) { CmdStanding(true); }
            else if (anim.GetBool("Standing") == true) { CmdStanding(false); }
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Enemy" || other.gameObject.tag == "Weapon"))
        {
            gameObject.SetActive(false);

        }
    }

    [Command]
    void CmdAttack(Vector2 touch, float speed)
    {
        anim.PlayInFixedTime("Attack Animation");
        RpcAttackAnim();
        GameObject go = Instantiate(weapon,transform);
        go.GetComponent<BottleMP>().myRigidBody.velocity = new Vector2(touch.x * speed, touch.y * speed);
        NetworkServer.Spawn(go);
    }
    [ClientRpc]
    void RpcAttackAnim()
    {
        anim.PlayInFixedTime("Attack Animation");
    }

    [Command]
    void CmdFlipMe(bool val)
    {
        sR.flipX = val;
        RpcFlipMe(val);
    }
    [ClientRpc]
    void RpcFlipMe(bool val)
    {
        sR.flipX = val;
    }
    [Command]
    void CmdStanding(bool val)
    {
        anim.SetBool("Standing", val);
        RpcStanding(val);
    }
    [ClientRpc]
    void RpcStanding(bool val)
    {
        anim.SetBool("Standing", val);
    }
}
