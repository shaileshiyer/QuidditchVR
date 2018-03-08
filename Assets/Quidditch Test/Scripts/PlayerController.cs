using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 80f;
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
		//source = GetComponent<AudioSource> ();
		//source.PlayOneShot (SoundClip);


	}

	// Get input and move in that direction
	void GetInput () {

		//Debug.Log ("Distance between player and snitch:" + dist);
		if (GvrControllerInput.IsTouching) {
			TouchCoords = GvrControllerInput.TouchPosCentered;
			//Debug.Log (TouchCoords);
			//if (TouchCoords.y > -0.1	) {
				Vector3 Player_forward = Camera.main.transform.forward;
				Vector3 Player_right = Camera.main.transform.right;

				rBody.velocity = TouchCoords.y * Player_forward * speed;
				rBody.velocity += TouchCoords.x * Player_right * speed;
			//}
		}




	}

	void Update () {
		
		GetInput ();


	}
}
