using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private Rigidbody player;
    public GameObject ParticleSys, ParticleClone;

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
        //player.velocity.magnitude > 5
        if (col.gameObject.tag == "spike")
        {
            kill();
        }
    }

    //Kills the player and loads in death animation.
    private void kill()
    {
        print("kill");
        ParticleClone = Instantiate(ParticleSys, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

        Invoke("KillParticle", 1);
    }

    void KillParticle()
    {
        Destroy(ParticleClone);
    }
}
