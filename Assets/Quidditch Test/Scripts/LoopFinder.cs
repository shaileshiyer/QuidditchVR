using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopFinder : MonoBehaviour {
	GameObject ring, snitch, find;
	private Vector3 heading;
	// Use this for initialization
	void Start () {
		ring = GameObject.FindGameObjectWithTag("Ring");
		snitch = GameObject.FindGameObjectWithTag ("Snitch");
	}

	// Update is called once per frame
	void Update () {

		if (ring != null) {
			find = ring;   
		} else {
			find = snitch;
		}
		if (find != null) {
			heading = find.transform.position;
			heading = heading - this.transform.position;
			this.transform.rotation = Quaternion.LookRotation (heading);
		}
	}
}
