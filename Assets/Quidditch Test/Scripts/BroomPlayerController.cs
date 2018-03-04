using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomPlayerController : MonoBehaviour {

	public float speed = 40f;
    public float xMin = 0f;
    public float xMax = 800f;
    public float zMin = 0f;
    public float zMax = 800f;
    // height boundry
    public float yMin = 0f;
    public float yMax = 250f;

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
