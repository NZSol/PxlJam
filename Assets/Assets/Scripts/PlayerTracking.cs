using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("p1");
	}
	
	// Update is called once per frame
	void Update ()
    {

        float z = transform.position.z;
        var d = Input.GetAxis("Mouse ScrollWheel");

        if (d > 0f && z < -5)
        {
            z++;
        }
        else if (d < 0f && z > -10)
        {
            z--;
        }

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, z);
    }
}
