using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kraken : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    public float moveSpeed;
    public float waitToAttack;
    public GameObject tentacle;
    public GameObject player;


    void Start () {

        Destroy(GameObject.FindGameObjectWithTag("LevelManager"));

        myRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        myRigidBody.MovePosition(transform.position + (transform.right * Time.deltaTime * moveSpeed));

        waitToAttack -= Time.deltaTime;

        if (waitToAttack < 0)
        {
            Instantiate(tentacle, player.transform.position + new Vector3(5,0,0),player.transform.rotation);
            waitToAttack = 2f;

        }

        if (player.activeSelf == false)
        {
            SceneManager.LoadScene(3);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(5);
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(5);
    }
}

