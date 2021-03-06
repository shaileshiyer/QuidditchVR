using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
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

	void Update () {
		Vector3 Player_forward = Camera.main.transform.forward;

		rBody.velocity =  Time.deltaTime*50*Player_forward * speed;

		//transform.position += Camera.main.transform.forward * speed * Time.deltaTime;
	}
}
