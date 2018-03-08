using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScreen : MonoBehaviour {
	private Text TimeText, SnitchInfoText;

	private TimerLogic tl;
	private bool snitchCaught;
	private float min, sec;
	private float smalltime;

	// Use this for initialization
	void Start () {
		tl = GameObject.FindGameObjectWithTag("Finish").GetComponent<TimerLogic>();
		TimeText = GameObject.FindGameObjectWithTag("GameTime").GetComponent<Text>();
		SnitchInfoText = GameObject.FindGameObjectWithTag("SnitchInfo").GetComponent<Text>();

		sec = tl.getLevelTime ();
		min = Mathf.Floor(getMins (sec));
		sec = Mathf.Floor(getSecs (sec));
		TimeText.text = "Your Time: " + min.ToString()+":"+sec.ToString();
		snitchCaught = tl.GetSnitchValue ();

		if (snitchCaught) {
			sec = tl.getSnitchCatchTime();
			min = Mathf.Floor(getMins(sec));
			sec = Mathf.Floor(getSecs(sec));

			SnitchInfoText.text = "You Caught Snitch at: " + min.ToString()+":"+sec.ToString();		
		} else {
			SnitchInfoText.text = "You didn't catch the Snitch!";
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
			SceneManager.LoadScene ("MenuLevel");
		}
	}
}
