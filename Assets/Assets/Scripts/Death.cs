using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private Rigidbody player;
    public GameObject ParticleSys, ParticleClone;
    public float timer = 60;

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
            timer--;
        }
        if (timer < 0.05f)
        {
            KillParticle();
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if (player.velocity.magnitude > 5 || col.gameObject.tag == "spike")
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

    }

    void KillParticle()
    {
        Destroy(ParticleClone);
    }
}
