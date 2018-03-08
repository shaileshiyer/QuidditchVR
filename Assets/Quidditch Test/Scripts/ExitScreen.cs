using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExitScreen : MonoBehaviour {
	private Text TimeText, SnitchCatchText, SnitchCatchTimeText;
	//private Text[] textarray;
	private TimerLogic tl;
	private bool snitchCaught;
	private float min,sec;

	// Use this for initialization
	void Start () {
		tl = GameObject.FindGameObjectWithTag ("Finish").GetComponent<TimerLogic>();
		GameObject [] garray = GameObject.FindGameObjectsWithTag("Score");

		TimeText = garray[0].GetComponent<Text>();
		SnitchCatchText = garray[1].GetComponent<Text>();
		SnitchCatchTimeText = garray[2].GetComponent<Text>();

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

	}
	
	// Update is called once per frame
	private float getMins(float times){
		return times / 60;
	}

	private float getSecs(float times){
		return times % 60;
	}
	void Update () {
		

	}
}
