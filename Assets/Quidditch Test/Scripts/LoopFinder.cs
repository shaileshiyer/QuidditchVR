using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopFinder : MonoBehaviour {
	GameObject ring;
	// Use this for initialization
	void Start () {
        ring = GameObject.FindGameObjectWithTag("Ring");
    }
	
	// Update is called once per frame
	void Update () {
        if (ring != null)
        {
		    Vector3 heading = ring.transform.position;
		    // Debug.Log ("Current Location: " + this.transform.localPosition);
		    heading = heading - this.transform.position;
		    this.transform.rotation = Quaternion.LookRotation(heading);
        } else
        {
            Destroy(this);
        }
	}
}
