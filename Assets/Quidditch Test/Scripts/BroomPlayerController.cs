using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomPlayerController : MonoBehaviour {

	public float speed = 80f;
	private float timer;

	Vector2 TouchCoords;
	CharacterController controller;
	Rigidbody rBody;

    // Use this for initialization
	void Start () {
		if (GetComponent<Rigidbody> ()) {
			rBody = GetComponent <Rigidbody> ();
		} else {
			Debug.LogError ("Object needs to have RigidBody Attached with all the rotation constraints enabled");
		}
	}

    // Get input and move in that direction
    void GetInput () {
		if (GvrControllerInput.IsTouching) {
			TouchCoords = GvrControllerInput.TouchPosCentered;
            Vector3 Player_forward = Camera.main.transform.forward;
			Vector3 Player_right = Camera.main.transform.right;
			rBody.velocity = TouchCoords.y * Player_forward * speed;
			rBody.velocity += TouchCoords.x * Player_right * speed;
		}
	}

	// Update is called once per frame
	void Update () {
		GetInput ();
	}
}
