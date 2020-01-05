using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            return;
        }
        CmdSpawnMyUnit();
        //playerMP.leftController = GameObject.FindGameObjectWithTag("Left Controller").GetComponent<SimpleTouchController>();
        //playerMP.rightController = GameObject.FindGameObjectWithTag("Right Controller").GetComponent<SimpleTouchController>();
    }
    

	// Update is called once per frame
	void Update () {
		
	}

    public GameObject player;
    //PlayerMP playerMP;
    [Command]
    void CmdSpawnMyUnit()
    {

        GameObject go = Instantiate(player);


        //playerMP = go.GetComponent<PlayerMP>();

        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }
}
