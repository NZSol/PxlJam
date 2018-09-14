using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public float jumpMultiplier;
    public float jumpForce;

    GameObject angleMarker;

	// Use this for initialization
	void Start ()
    {
        angleMarker = GameObject.FindWithTag("angleMarker");
    }
	
	// Update is called once per frame
	void Update () {

        jumpMultiplier = angleMarker.transform.localScale.z;
        jumpForce = 5 * angleMarker.transform.localScale.z;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
	}
}
