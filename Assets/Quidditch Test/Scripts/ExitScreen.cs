using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScreen : MonoBehaviour {
	private Text TimeText, SnitchCatchText, SnitchCatchTimeText;
	//private Text[] textarray;
	private TimerLogic tl;
	private bool snitchCaught;
	private float min,sec;
	private float smalltime;
	private GameObject [] garray ;
	// Use this for initialization
	void Start () {
		
		tl = GameObject.FindGameObjectWithTag("Finish").GetComponent<TimerLogic>();
		//GameObject [] garray = GameObject.FindGameObjectsWithTag("Score");
		//garray = GameObject.FindGameObjectsWithTag("Finish"); 

		TimeText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
		SnitchCatchText = GameObject.FindGameObjectWithTag("Score2").GetComponent<Text>();
		SnitchCatchTimeText = GameObject.FindGameObjectWithTag("Score3").GetComponent<Text>();

		sec = tl.getLevelTime ();
		min = Mathf.Floor(getMins (sec));
		sec = Mathf.Floor(getSecs (sec));
		TimeText.text = min.ToString()+":"+sec.ToString();
		snitchCaught = tl.GetSnitchValue ();
		SnitchCatchText.text = tl.GetSnitchValue().ToString();
		if (snitchCaught == true) {
			sec = tl.getSnitchCatchTIme();
			min = Mathf.Floor(getMins(sec));
			sec = Mathf.Floor(getSecs(sec));

			SnitchCatchTimeText.text = min.ToString()+":"+sec.ToString();		
		} 
		else {
			
			SnitchCatchTimeText.text = "--:--";
		}
		smalltime = 60f;


	}
	
	// Update is called once per frame
	private float getMins(float times){
		return times / 60;
	}

	private float getSecs(float times){
		return times % 60;
	}
	void Update () {
		smalltime -= Time.deltaTime;
		if (smalltime < 0) {
			//Destroy (garray[0]);
			//Destroy (garray[1]);
			SceneManager.LoadScene ("MenuLevel");
		}
	}
}
