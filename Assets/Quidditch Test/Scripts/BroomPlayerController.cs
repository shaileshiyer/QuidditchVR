using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BroomPlayerController : MonoBehaviour {

	public float speed = 80f;
	private float timer;
	private bool checkforsnitch;
	Vector2 TouchCoords;
	CharacterController controller;
	Rigidbody rBody;
	GameObject snitch;
	SnitchLogic snitchlog;
	private Text help; 
	private bool snitchCatched;

	private Text snitchCount; 

	//private AudioSource source;
	//public AudioClip SoundClip;
	private TimerLogic timerlog;

	private float dist;
	float smalltime=10f;
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
		snitchCatched = false;
		//source = GetComponent<AudioSource> ();
		//source.PlayOneShot (SoundClip);

		timerlog = GameObject.FindGameObjectWithTag ("Finish").GetComponent<TimerLogic> ();
		help = GameObject.FindGameObjectWithTag("Help").GetComponent<Text>();
		snitchCount = GameObject.FindGameObjectWithTag ("SnitchCount").GetComponent<Text> ();
		help.text = "Find the Rings and the Snitch";
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
					//snitchlog.Destroy ();
					snitchCatched = true;
					//TimerLogic tl = GameObject.FindGameObjectWithTag ("Finish").GetComponent<TimerLogic> ();
					timerlog.SetSnitchValue ();
					snitchlog.Destroy ();
					snitchCount.text = "1";
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
		smalltime -= Time.deltaTime;
		if (smalltime < 0)
			help.text = "";
		GetInput ();

		if (snitchCatched && GameObject.FindGameObjectWithTag ("Ring") == null) {
			help.text = "Congrats! You have passed all rings and catched the snitch";
			Time.timeScale = 0;
			//TimerLogic tl = GameObject.FindGameObjectWithTag ("Finish").GetComponent<TimerLogic> ();
			timerlog.EndGame ();
		}
	}
}
