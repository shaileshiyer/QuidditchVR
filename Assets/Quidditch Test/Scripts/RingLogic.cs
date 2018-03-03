using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingLogic : MonoBehaviour {
    GameObject ring;
	GameObject snitch;
	SnitchLogic snitchController;
    byte counter = 1;
    Vector3[] positions = new Vector3[10];

    // Use this for initialization
    void Start () {
        // get ring object
        ring = GameObject.FindGameObjectWithTag("Ring");

        // initiate all 10 (remainig 9) ring location here
        positions[1] = new Vector3(1f, 1f, -1f);
        positions[2] = new Vector3(1f, 1f, -2f);
        positions[3] = new Vector3(1f, 1f, -3f);
        positions[4] = new Vector3(1f, 1f, -4f);
        positions[5] = new Vector3(1f, 1f, -5f);
        positions[6] = new Vector3(1f, 1f, -6f);
        positions[7] = new Vector3(1f, 1f, -7f);
        positions[8] = new Vector3(1f, 1f, -8f);
        positions[9] = new Vector3(1f, 1f, -9f);

		snitch = GameObject.FindGameObjectWithTag ("Snitch");
		snitch.AddComponent<SnitchLogic>();
		snitch.transform.localScale = new Vector3 (3, 3, 3);
		snitch.transform.position = new Vector3 (2, 2, -15);
    }

    // Update is called once per frame
    void Update () {
    }

	void OnTriggerExit (Collider other) {
		snitchController = snitch.GetComponent<SnitchLogic> ();
		snitchController.Init ();

        if (other.gameObject == GameObject.FindGameObjectWithTag("Player")) {
            ring.transform.position = positions[counter];
            counter++;
        }

		if (counter == 5) {
			snitchController.Init ();
		}

        if (counter == 10) {
            Destroy(ring);
        }
    }
}
