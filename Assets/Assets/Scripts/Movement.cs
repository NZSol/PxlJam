﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    private Rigidbody player;
    private float jumpForce = 5f, maxSpeed = 10f, timer;
    private Vector3 playerPosition, mousePosition, force;
    private Ray r;
    private bool canMove = true, stationary = true;

    public Slider forceBar;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody>();
        forceBar.value = calculateForce();
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
                print("Became stationary");
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
        

        forceBar.value = calculateForce();
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
}
