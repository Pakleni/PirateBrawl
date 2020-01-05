using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransportTentacle : MonoBehaviour {
    private float wait = 0.1f;
    private CircleCollider2D circleCollider;
    public Sprite tentacle;

    void Start()
    {
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    void Update()
    {

        wait -= Time.deltaTime;
        if (wait < 0)
        {
            circleCollider.enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = tentacle;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
}
