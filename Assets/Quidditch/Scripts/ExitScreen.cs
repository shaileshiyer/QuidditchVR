using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScreen : MonoBehaviour {
	private Text TimeText, SnitchInfoText;

	private TimerLogic tl;
	private bool snitchCaught;
	private float min, sec;
	private float smalltime = 600f;
	int ringcount;

	// Use this for initialization
	void Start () {
		GameObject T1Obj = GameObject.FindGameObjectWithTag ("Finish");
		tl = T1Obj.GetComponent<TimerLogic>();
		TimeText = GameObject.FindGameObjectWithTag("GameTime").GetComponent<Text>();
		SnitchInfoText = GameObject.FindGameObjectWithTag("SnitchInfo").GetComponent<Text>();
		ringcount = tl.getRingCount();
		if ( ringcount== 11) {
			
			sec = tl.getLevelTime ();
			min = Mathf.Floor (getMins (sec));
			sec = Mathf.Floor (getSecs (sec));

			TimeText.text = "Your Time: " + min.ToString () + ":" + sec.ToString ();
			snitchCaught = tl.GetSnitchValue ();

			if (snitchCaught) {
				sec = tl.getSnitchCatchTime ();
				min = Mathf.Floor (getMins (sec));
				sec = Mathf.Floor (getSecs (sec));

				SnitchInfoText.text = "Caught Snitch at: " + min.ToString () + ":" + sec.ToString ();		
			} else {
				SnitchInfoText.text = "You didn't catch the Snitch!";
			}
		} else {
			TimeText.text = "You have caught "+ringcount+" out of 11 rings";
			SnitchInfoText.text = "";
		}
		Destroy (T1Obj);
		StartCoroutine (LoadMenu ());
	}
	
	// Update is called once per frame
	private float getMins(float times){
		return times / 60;
	}

	private float getSecs(float times){
		return times % 60;
	}

	void Update () {}
	/*void Update () {
		smalltime = smalltime - Time.deltaTime;
		Debug.Log (smalltime);
		if (smalltime < 0) {
			SceneManager.LoadScene ("MenuLevel");
		}
	}*/

	IEnumerator LoadMenu () {
		Debug.Log ("i am here");
		yield return new WaitForSeconds (30);
		SceneManager.LoadScene ("MenuLevel");
	}
}
