using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Phases : MonoBehaviour {

    bool buildingPhase, slimePhase;

    public GameObject canvas;

	// Use this for initialization
	void Start () {
        buildingPhase = true;
        slimePhase = false;
	}
	
	// Update is called once per frame
	void Update () {
		 if (buildingPhase == true)
        {
            canvas.SetActive(true);
        }
         else
        {
            canvas.SetActive(false);
        }
	}
}
