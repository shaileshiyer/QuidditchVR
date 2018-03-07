using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class BroomPlayerController : MonoBehaviour {

	public float speed = 80f;
	private float timer;
	private bool checkforsnitch;
	Vector2 TouchCoords;
	CharacterController controller;
	Rigidbody rBody;
	GameObject snitch;
	SnitchLogic snitchlog;

	float dist;
    // Use this for initialization
	void Start () {
		
		if (GetComponent<Rigidbody> ()) {
			rBody = GetComponent <Rigidbody> ();
		} else {
			Debug.LogError ("Object needs to have RigidBody Attached with all the rotation constraints enabled");
		}
		snitch = GameObject.FindGameObjectWithTag("Snitch");
		snitchlog = snitch.GetComponent<SnitchLogic>();
		checkforsnitch = false;

	}

    // Get input and move in that direction
    void GetInput () {
		
		//Debug.Log ("Distance between player and snitch:" + dist);
		if (GvrControllerInput.IsTouching) {
			TouchCoords = GvrControllerInput.TouchPosCentered;
			//Debug.Log (TouchCoords);
			if (TouchCoords.y > -0.1	) {
				Vector3 Player_forward = Camera.main.transform.forward;
				Vector3 Player_right = Camera.main.transform.right;

				rBody.velocity = TouchCoords.y * Player_forward * speed;
				rBody.velocity += TouchCoords.x * Player_right * speed;
			}
		}


	

	}

	public void CatchSnitch(){
		Debug.Log ("Click HOraha hai");

		if (checkforsnitch) {
				if (dist < 20) {
					Debug.Log ("Snitch is caught");
					snitchlog.Destroy ();
				}


		}

	}

	public void AllowSnitchCatch(){
		checkforsnitch = true;
	}
	// Update is called once per frame
	void Update () {
		if (snitch != null) {	
			dist = Vector3.Distance (gameObject.transform.position, snitch.transform.position);
		}
		GetInput ();
	}
}
