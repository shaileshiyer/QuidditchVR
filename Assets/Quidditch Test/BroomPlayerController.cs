using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomPlayerController : MonoBehaviour {

	public float inputDelay = 0.1f;
	public float upwardVel = 12;
	public float rotateVel = 100;
	public float speed= 40;
	Quaternion targetRotation ;
	Rigidbody rBody;
	float heightInput,turnInput;
	bool forwardInput;
	Vector2 TouchCoords;

	public Quaternion TargetRotation{
		get{ return targetRotation;}
	}

	// Use this for initialization
	void Start () {
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody> ())
			rBody = GetComponent<Rigidbody> ();
		else
			Debug.LogError ("This character needs a rigid body");
	
		//heightInput = turnInput = 0;
		//forwardInput = false;
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


			rBody.velocity = TouchCoords.y * Player_forward * speed;
			rBody.velocity += TouchCoords.x * Player_right * speed; 

		} else {
			//TouchCoords = new Vector2();
		}

		Debug.Log ("Tranform.forward" + transform.forward+"Transform.right"+transform.right);

		Debug.Log(TouchCoords+" velocity = "+rBody.velocity);
	}
	// Update is called once per frame
	void Update () {
		GetInput ();
		//Turn();
	}

	void FixedUpdate(){
		//Moveforward ();
	}

	/*
	void Moveforward(){
	
		if ((Mathf.Abs (heightInput) > inputDelay ) || forwardInput ) {
			//move
			//rBody.velocity = transform.up*heightInput*upwardVel;

			if (forwardInput) {
				rBody.velocity = transform.up*heightInput*upwardVel;
				rBody.velocity += transform.forward * forwardVel;
			} 
			else {
				rBody.velocity=Vector3.zero;
				rBody.velocity = transform.up*heightInput*upwardVel;
			}

		} else {
			//zeroVel
			rBody.velocity=Vector3.zero;
		}

		if (forwardInput) {
			rBody.velocity = transform.forward * forwardVel;
		} 
		else {
			rBody.velocity = Vector3.zero;
		}

	}

	void Turn(){
		targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}

	*/
}
