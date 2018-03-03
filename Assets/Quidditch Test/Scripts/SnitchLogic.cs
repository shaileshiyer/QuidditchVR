using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnitchLogic : MonoBehaviour {
    bool CanMove = false;

    // Use this for initialization
    void Start () {
		Debug.Log ("hi");
	}

	// Update is called once per frame
	void Update () {
        if (CanMove) {
			// the logic goes here
        }
	}

    public void Init () {
        CanMove = true;
    }
}
