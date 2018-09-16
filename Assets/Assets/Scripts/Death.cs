using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private Rigidbody player;
    public GameObject ParticleSys, ParticleClone;
    private float killSpeed = 8f, lastSpeed = 0f;

	// Use this for initialization
	void Start ()
    {
        player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ParticleClone != null)
        {

        }

        lastSpeed = player.velocity.magnitude;
	}

    void OnCollisionEnter(Collision col)
    {
        print(lastSpeed + " : " + player.velocity.magnitude);

        if (lastSpeed > killSpeed || col.gameObject.tag == "spike")
        {
            print(lastSpeed);
            kill();
        }
    }

    //Kills the player and loads in death animation.
    private void kill()
    {
        print("kill");
        ParticleClone = Instantiate(ParticleSys, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }

    void KillParticle()
    {
        Destroy(ParticleClone);
    }
}
