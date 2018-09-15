using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Vector3 dir;
    public float angle;

    private Rigidbody player;
    private float jumpForce = 10f, maxSpeed = 20f;
    private Vector3 playerPosition, mousePosition, p, force;
    private Ray r;


    bool angleRestriction;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private Vector3 ip, cp;

    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.position;
        mousePosition = (Vector3)GetCurrentMousePosition();
        p = Camera.main.WorldToScreenPoint(playerPosition);
        angle = getAngle(mousePosition, p);
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

        if (player.velocity.magnitude > maxSpeed)
        {
            player.velocity = player.velocity.normalized * maxSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(force * jumpForce, ForceMode.Impulse);

            
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
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
