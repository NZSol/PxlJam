using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    Vector3 spawnSite;
    public GameObject player;
    GameObject playerClone;
    bool spawning = false;


	// Use this for initialization
	void Start () {
        spawnSite = new Vector3(0, 1.5f, 0);
        playerClone = Instantiate(player, spawnSite, Quaternion.identity);
        playerClone.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (playerClone == null && !spawning)
        {
            spawning = true;
            Invoke("respawn", 3);

        }
	}

    void respawn()
    {
        playerClone = Instantiate(player, spawnSite, Quaternion.identity);
        playerClone.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        spawning = false;
    }
}
