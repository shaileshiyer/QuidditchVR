using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomPlayerController : MonoBehaviour {

	public float speed= 40;
	Vector2 TouchCoords;
	CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> (); 		
	
	}

	void GetInput(){

		//heightInput = Input.GetAxis ("Vertical");
		//turnInput = Input.GetAxis ("Horizontal");
		//forwardInput = Input.GetKey (KeyCode.LeftShift);
		if (GvrControllerInput.IsTouching) {
			TouchCoords = GvrControllerInput.TouchPosCentered;

			//transform.forward = Camera.main.transform.forward;
			//transform.right = Camera.main.transform.right;
			Vector3 Player_forward = Camera.main.transform.forward;
			Vector3 Player_right = Camera.main.transform.right;

			controller.Move (TouchCoords.y * Player_forward * speed*Time.deltaTime);
			controller.Move (TouchCoords.x * Player_right * speed*Time.deltaTime);

	//		rBody.velocity = TouchCoords.y * Player_forward * speed;
	//		rBody.velocity += TouchCoords.x * Player_right * speed; 

		} else {
			//TouchCoords = new Vector2();
		}

		Debug.Log ("Tranform.forward" + transform.forward+"Transform.right"+transform.right);

		//Debug.Log(TouchCoords+" velocity = "+rBody.velocity);
	}
	// Update is called once per frame
	void Update () {
		GetInput ();
		//Turn();
	}

	void FixedUpdate(){
		//Moveforward ();
	}

}
