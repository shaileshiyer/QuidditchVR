using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnitchLogic : MonoBehaviour {
    bool CanMove;

	[SerializeField]
	private Vector3[] positions = new Vector3[10];

	[SerializeField]
	private UnityEngine.AI.NavMeshAgent agent;
    // Use this for initialization
    
	[SerializeField]
	private Transform player;

	public float timerinterval = 5;
	private float timer =0f;


	void Start () {

		if (agent == null)
			agent = GetComponent <UnityEngine.AI.NavMeshAgent> ();

        player = GameObject.FindGameObjectWithTag ("Player").transform;

		positions[0] = new Vector3(1684.4f, 140.41f, 1347.7f);
		// initiate all 10 (remainig 9) ring location and rtation here
		positions[1] = new Vector3(1621.8f, 581f, 1016f);
		positions[2] = new Vector3(390.9f, 161.6f, 383f);
		positions[3] = new Vector3(1960f, 216f, 488f);
		positions[4] = new Vector3(2672.3f, 216f, 950f);
		positions[5] = new Vector3(2723.8f, 269.8f, 1697.8f);
		positions[6] = new Vector3(2661.5f, 45.1f, 2615.4f);
		positions[7] = new Vector3(1856.8f, 371f, 2655f);
		positions[8] = new Vector3(758.5f, 34.5f, 2147.8f);
		positions[9] = new Vector3(965.03f, 291.72f, 1650.07f);
		//positions[10] = new Vector3(581.8f, 131.45f, 2600.8f);

		CanMove = false;
	}

	// Update is called once per frame
	void Update () {
        
		if (CanMove) {
			// the logic goes here
			timer -=Time.deltaTime;
			if (timer <= 0) {
				RunawayFromPlayer ();
				timer = timerinterval;
				Debug.Log ("Every 10s initialize position");
			}
        }
	}

    public void Init () { 
        CanMove = true;
		agent.Warp (transform.position);
		Debug.Log ("Snitch INitialized");
    }

	public void Destroy(){
		Destroy (gameObject);
	}
	private void RunawayFromPlayer(){
		float furtherDistanceSofar = 0;
		Vector3 runPosition = Vector3.zero;

		//Check Each Point
		/*
		foreach(Vector3 point in positions){
			float CurrentCheckDistance = Vector3.Distance (player.position, point/2);

			if (CurrentCheckDistance > furtherDistanceSofar) {
				furtherDistanceSofar = CurrentCheckDistance;
				runPosition = point;
			
			}
		}*/

		int chance = Random.Range (0, 10);
		runPosition = positions [chance];
		Debug.Log ("Set Destination:" + runPosition/2);

		agent.SetDestination (runPosition/2);
	}
}
