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

			SnitchInfoText.text = "Caught Snitch at: " + min.ToString()+":"+sec.ToString();		
		} else {
			SnitchInfoText.text = "You didn't catch the Snitch!";
		}

		Destroy (tl);
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
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene ("MenuLevel");
	}
}
