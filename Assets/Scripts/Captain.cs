using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Captain : MonoBehaviour {

    public GameObject weapon;
    public int startHealth;
    public GameObject healthBar;
    public float bottleSpeed;

    private Animator anim;    
    private float waitToFire = 1f;
    private float health;

    // Use this for initialization
    void Start () {
        health = startHealth;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        
        if (waitToFire < 0.5f) { anim.PlayInFixedTime("Default"); }


        waitToFire -= Time.deltaTime;
        if (waitToFire < 0)
        {   Instantiate(weapon, transform);
            anim.PlayInFixedTime("Attack");
            waitToFire = 1f;            
        }

        if (health < 1)
        {
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
