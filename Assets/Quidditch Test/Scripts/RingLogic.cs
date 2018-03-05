﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingLogic : MonoBehaviour {
    GameObject ring;
	GameObject snitch;
	SnitchLogic snitchController;
    byte counter = 1;
    Vector3[] positions = new Vector3[11];
    Vector3[] rotations = new Vector3[11];

    // Use this for initialization
    void Start () {
        // get ring object
        ring = GameObject.FindGameObjectWithTag("Ring");

        positions[0] = new Vector3(1684.4f, 140.41f, 1347.7f);
        rotations[0] = new Vector3(0f, 99f, 0f);

        // initiate all 10 (remainig 9) ring location and rtation here
        positions[1] = new Vector3(1621.8f, 581f, 1016f);
        rotations[1] = new Vector3(0f, 84.191f, 0f);

        positions[2] = new Vector3(390.9f, 161.6f, 383f);
        rotations[2] = new Vector3(0f, 84.191f, 0f);

        positions[3] = new Vector3(2301f, 422f, 327f);
        rotations[3] = new Vector3(0f, 84.191f, 0f);

        positions[4] = new Vector3(2672.3f, 31.7f, 1041.4f);
        rotations[4] = new Vector3(0f, 174.936f, 0f);

        positions[5] = new Vector3(2723.8f, 269.8f, 1697.8f);
        rotations[5] = new Vector3(-33.166f, 174.936f, 0f);

        positions[6] = new Vector3(2661.5f, 45.1f, 2615.4f);
        rotations[6] = new Vector3(-29.05f, -40.761f, 6.827f);

        positions[7] = new Vector3(1856.8f, 371f, 2655f);
        rotations[7] = new Vector3(0f, 90f, 0f);

        positions[8] = new Vector3(758.5f, 34.5f, 2147.8f);
        rotations[8] = new Vector3(0f, 73.984f, 0f);

        positions[9] = new Vector3(965.03f, 291.72f, 1650.07f);
        rotations[9] = new Vector3(0f, -63.424f, 0f);

        positions[10] = new Vector3(581.8f, 131.45f, 2600.8f);
        rotations[10] = new Vector3(0f, 0f, 0f);

        snitch = GameObject.FindGameObjectWithTag ("Snitch");
		snitch.AddComponent<SnitchLogic>();
    }

	void OnTriggerExit (Collider other) {
		snitchController = snitch.GetComponent<SnitchLogic> ();

        if (other.gameObject == GameObject.FindGameObjectWithTag ("Player")) {
            ring.transform.position = positions[counter]/2;
            ring.transform.eulerAngles = rotations[counter];
            counter++;
        }

		if (counter == 5) {
			snitchController.Init ();
		} else if (counter == 11) {
            Destroy(this);
            Destroy(ring);
        }
    }
}
