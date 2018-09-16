using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    private Rigidbody player;
    private float jumpForce = 5f, maxSpeed = 12f, timer;
    private Vector3 playerPosition, mousePosition, force;
    private Ray r;
    private bool canMove = true, stationary = true;

    public Slider forceBarGreen, forceBarYellow, forceBarRed;

    // Use this for initialization
    void Start()
    {
        forceBarGreen = GameObject.Find("ForceBarGreen").GetComponent<Slider>();
        forceBarYellow = GameObject.Find("ForceBarYellow").GetComponent<Slider>();
        forceBarRed = GameObject.Find("ForceBarRed").GetComponent<Slider>();
        player = GetComponent<Rigidbody>();
        setForceBar(calculateForce());
    }
    

    private Vector3 ip, cp;

    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.position;
        mousePosition = (Vector3)GetCurrentMousePosition();
        force = mousePosition - playerPosition;

        if (player.velocity.magnitude > maxSpeed)
        {
            player.velocity = player.velocity.normalized * maxSpeed;
        }

        if (player.velocity.magnitude == 0)
        {
            if (stationary)
            {
                if (Time.time > timer)
                {
                    canMove = true;
                }
                
            }
            else
            {
                stationary = true;
                timer = Time.time + 0.2f;
            }
        }
        else
        {
            stationary = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            GetComponent<Rigidbody>().AddForce(force * jumpForce, ForceMode.Impulse);
            canMove = false;
            stationary = false;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            
        }

        if (canMove)
        {
            setForceBar((force.magnitude/maxSpeed) * jumpForce);
        }
        else
        {
            setForceBar(calculateForce());
        }
        
    }

    //Returns the angle between the mouse and the centre of 
    private float getAngle(Vector3 point1, Vector3 point2)
    {
        Vector3 dir = point1 - point2;
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

    private float calculateForce()
    {
        if(player.velocity.magnitude == 0)
        {
            return 0;
        }
        else
        {
            return player.velocity.magnitude / maxSpeed;
        }
    }

    private void setForceBar(float force)
    {
        float split = 1f / 3f;

        if(force < split)
        {
            setForceBarValue(forceBarGreen, force * 3f);
            setForceBarValue(forceBarYellow, 0);
            setForceBarValue(forceBarRed, 0);
        }
        else if (force < (split * 2))
        {
            setForceBarValue(forceBarGreen, 1f);
            setForceBarValue(forceBarYellow, (force - split) * 3f);
            setForceBarValue(forceBarRed, 0);
        }
        else
        {
            setForceBarValue(forceBarGreen, 1f);
            setForceBarValue(forceBarYellow, 1f);
            setForceBarValue(forceBarRed, (force - (split * 2)) * 3f);
        }
    }

    private void setForceBarValue(Slider slider, float force)
    {
        if (force < 0.006f)
        {
            force = 0.006f;
        }

        slider.value = force;
    }
}
