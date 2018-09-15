using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private Rigidbody player;

	// Use this for initialization
	void Start ()
    {
        player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if (player.velocity.magnitude > 5)
        {
            kill();
        }
    }

    //Kills the player and loads in death animation.
    private void kill()
    {
        print("Dead");
    }
}
