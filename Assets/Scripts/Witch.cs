using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Witch : MonoBehaviour {

    private GameObject player;
    private Animator anim;
    public GameObject skelleton;
    public GameObject witchSkelleton;
    public GameObject healthBar;
    public int startHealth;
    private float waitToDeploy = 2f;
    private float waitToAttack = 2f;
    private float health;
    public GameObject potion;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        health = startHealth;
    }
	
	// Update is called once per frame
	void Update () {

        waitToDeploy -= Time.deltaTime;
        waitToAttack -= Time.deltaTime;

        if (waitToAttack < 1f) { anim.PlayInFixedTime("Default"); }
        if (waitToDeploy < 0)
        {
            Instantiate(skelleton, new Vector3(-9.6f, 3.2f, 0), transform.rotation, transform);
            Instantiate(skelleton, new Vector3(-6.4f, 0, 0), transform.rotation, transform);
            Instantiate(skelleton, new Vector3(-9.6f, -3.2f, 0), transform.rotation, transform);

            
            waitToDeploy = 8f;
        }

        if (waitToAttack < 0)
        {
            Instantiate(witchSkelleton, player.transform.position, transform.rotation, transform);

            anim.PlayInFixedTime("Attack");

            waitToAttack = 2f;
        }

        if (health < 1)
        {
            Instantiate(potion);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            health -= 1;
            healthBar.GetComponent<Image>().fillAmount = health / startHealth;

        }
    }


}
