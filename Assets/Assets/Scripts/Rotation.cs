using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    
    public Vector3 dir;
    public float angle;
    float jumpForce = 5;
    
    Vector3 playerPosition, mousePosition, p, force;
    Ray r;
    

    bool angleRestriction;

    // Use this for initialization
    void Start ()
    {

    }

    private Vector3 ip, cp;

	// Update is called once per frame
	void Update ()
    {
        playerPosition = transform.position;
        mousePosition = (Vector3) GetCurrentMousePosition();
        p = Camera.main.WorldToScreenPoint(playerPosition);
        angle = getAngle(mousePosition,p);
        force = mousePosition - playerPosition;

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

        //Debugging code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Applying " + force + " force.");
            GetComponent<Rigidbody>().AddForce(force * jumpForce, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("PlayerPosition:" + playerPosition + ", mousePosition:" + mousePosition);
            Debug.Log("Angle:" + getAngle(mousePosition,p));

            float i = Mathf.Abs(mousePosition.x - p.x);

            Debug.Log("Difference in X : " + i);

        }

    }

    //Returns the angle between the mouse and the centre of 
    private float getAngle(Vector3 point1, Vector3 point2)
    {
        dir = point1 - point2;
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    private Vector3? GetCurrentMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var plane = new Plane(Vector3.forward, Vector3.zero);

        float rayDistance;
        if (plane.Raycast(ray, out rayDistance))
        {
            return ray.GetPoint(rayDistance);
        }
        return null;
    }
}
