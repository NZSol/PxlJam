using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticle : MonoBehaviour {

    GameObject particles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        particles = GameObject.FindWithTag("particles");

        if (particles != null)
        {
            Invoke("KillParticles", 2);
        }

	}

    void KillParticles()
    {

        Destroy(particles);
    }


}
