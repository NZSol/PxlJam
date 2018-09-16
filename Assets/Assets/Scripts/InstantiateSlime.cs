using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSlime : MonoBehaviour {
    public GameObject smallSlime;
    GameObject slimeClone1, slimeClone2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "point")
        {
            Destroy(gameObject);
            slimeClone1 = Instantiate(smallSlime, new Vector3(-19.43f, 1.9f, 0), Quaternion.identity);
            slimeClone2 = Instantiate(smallSlime, new Vector3(-17.95f, 1.9f, 0), Quaternion.identity);
        }
    }
}
