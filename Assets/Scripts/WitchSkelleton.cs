using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSkelleton : MonoBehaviour
{       
    private Animator anim;
    private float wait = 1.1f;
    private CapsuleCollider2D capsuleCollider;

    // Use this for initialization
    void Start()
    {
        capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
        
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        wait -= Time.deltaTime;
        if (wait < 0.1f)
        {
            anim.PlayInFixedTime("Risen");
            capsuleCollider.enabled = true;
            
        }
        if (wait < 0)
        {
            Destroy(gameObject);
        }
    }

}

