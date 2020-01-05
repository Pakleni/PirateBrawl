using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour {

    private float wait = 0.8f;
    private CircleCollider2D circleCollider;
    public Sprite tentacle;
    public Sprite hole;
    // Use this for initialization
    void Start () {
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        
        wait -= Time.deltaTime;
        if (wait < 0.3f)
        {
            circleCollider.enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = tentacle;
        }
        if (wait < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = hole;
        }
    }

}
