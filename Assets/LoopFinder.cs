using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopFinder : MonoBehaviour {
	GameObject ring;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ring = GameObject.FindGameObjectWithTag ("Ring");
		Vector3 heading = ring.transform.position;
		Debug.Log ("Current Location: " + this.transform.localPosition);
		heading = heading - this.transform.position;
		this.transform.rotation = Quaternion.LookRotation(heading);

	}
}
