using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    
    public Vector3 dir;
    public float angle;
    float jumpForce = 5;
    
    Vector3 playerPosition, mousePosition, p, v;
    Ray r;

    bool angleRestriction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        playerPosition = GameObject.FindWithTag("p1").transform.position;
        mousePosition = Input.mousePosition;
        p = Camera.main.WorldToScreenPoint(playerPosition);
        angle = getAngle(mousePosition,p);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("PlayerPosition:" + p + ", mousePosition:" + mousePosition);
            Debug.Log("Angle:" + getAngle(mousePosition,p));

        }

        if (angle < 180 && angle > 0)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if (angle >= 180 || angle < -90)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    //Returns the angle between the mouse and the centre of 
    private float getAngle(Vector3 point1, Vector3 point2)
    {
        dir = point1 - point2;
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }
}
