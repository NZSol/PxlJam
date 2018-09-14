using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    
    public Vector3 dir;
    public float angle;

    float jumpForce;

    bool angleRestriction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        jumpForce = Random.Range(0, 10);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector2.up * 3, ForceMode.Impulse);
        }


        if (angle <= 180 && angle >= 0)
        {
            angleRestriction = false;
        }
        else
        {
            angleRestriction = true;
        }

        if (angleRestriction == false)
        {
            dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            print("test");
        }
        else
        {
            dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (transform.rotation.z < 0 && transform.rotation.z > -90)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (angle < - 90 || transform.rotation.z > 180)
            {
                transform.eulerAngles = new Vector3(0,0, 180);
            }
        }
    }
}
