﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine : MonoBehaviour {

    private LineRenderer lineRenderer;
    private float counter;
    private float dist;

    public Transform origin;

    public float lineDrawspeed = 6f;

	// Use this for initialization
	void Start ()
    {
        origin = GameObject.FindWithTag("p1").transform;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, playerPosition());
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (origin == null)
        {
            origin = GameObject.FindWithTag("p1").transform;
        }
        var mouse = GetCurrentMousePosition().GetValueOrDefault();
        lineRenderer.SetPosition(0, playerPosition());
        lineRenderer.SetPosition(1, mouse);
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

    private Vector3 playerPosition()
    {
        return new Vector3(origin.position.x,origin.position.y  - 0.3f,origin.position.z);
    }
}
