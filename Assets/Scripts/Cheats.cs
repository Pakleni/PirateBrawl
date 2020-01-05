using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour {

    public GameObject player;
    public GameObject cheatMenu;

    public void ActivateCheatMenu()
    {
        cheatMenu.SetActive(!cheatMenu.activeSelf);
    }



    public void InfiniteBottles()
    {
        if (player.GetComponent<PlayerController>().fireWaitTime == 1f)
        {
            player.GetComponent<PlayerController>().fireWaitTime = 0;
        }
        else { player.GetComponent<PlayerController>().fireWaitTime = 1f; }

        player.GetComponent<PlayerController>().weapon.GetComponent<Bottle>().destroyable = !player.GetComponent<PlayerController>().weapon.GetComponent<Bottle>().destroyable;
    }

    public void InfiniteLives()
    {
        player.GetComponent<PlayerController>().killable = !player.GetComponent<PlayerController>().killable;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
