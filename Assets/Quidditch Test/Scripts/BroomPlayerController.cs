using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BroomPlayerController : MonoBehaviour {

	public float speed;
	private float timer = 0f;
	private bool checkforsnitch;
	private Vector2 TouchCoords;
	private CharacterController controller;
	private Rigidbody rBody;
	private GameObject snitch;
	private SnitchLogic snitchlog;
	private bool snitchCatched;
	private bool snitchTimerBool = true;
	private float snitchTimer = 0f;
	private Text help; 
	private Text snitchCount; 
	private GameObject finish;
	private TimerLogic timerlog;
	private float dist = 0f;
	float smalltime = 10f;

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

		finish = GameObject.FindGameObjectWithTag ("Finish");
		timerlog = finish.GetComponent<TimerLogic> ();
		help = GameObject.FindGameObjectWithTag("Help").GetComponent<Text>();
		snitchCount = GameObject.FindGameObjectWithTag ("SnitchCount").GetComponent<Text> ();
		help.text = "Find the Rings and the Snitch";
	}

	public void AllowSnitchCatch() {
		checkforsnitch = true;
	}

	// Update is called once per frame
	void Update () {
		if (snitch != null) {	
			dist = Vector3.Distance (gameObject.transform.position, snitch.transform.position);
			if (dist < 20) {
				if (snitchTimerBool) {
					snitchTimer += Time.deltaTime;
				} else {
					snitchTimerBool = true;					
				}
			} else {
				snitchTimerBool = false;
				snitchTimer = 0f;
			}

			if (snitchTimer > 1) {
				snitchCatched = true;
				snitch = null;
				timerlog.SetSnitchValue ();
				snitchlog.Destroy ();
				snitchCount.text = "1";
			}
		}
		smalltime -= Time.deltaTime;
		if (smalltime < 0)
			help.text = "";

		transform.position += Camera.main.transform.forward * speed * Time.deltaTime;

		if (snitchCatched && GameObject.FindGameObjectWithTag ("Ring") == null) {
			help.text = "Congrats! You have passed all rings and catched the snitch";
			Time.timeScale = 0;
			timerlog.EndGame ();
		}
	}
}
