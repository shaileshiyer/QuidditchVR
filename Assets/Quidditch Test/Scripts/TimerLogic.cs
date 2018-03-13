using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerLogic : MonoBehaviour {
	public float LevelTime = 480f;
	private float timer = 0f;
	private float SnitchTime = 0f;
	private bool SnitchCatched = false;
	private bool CountTime;
	private Text showText;
	private int ringCount;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		CountTime = true;
		SnitchTime = 0f;
		showText = GameObject.FindGameObjectWithTag("Help").GetComponent<Text> ();
		timer = LevelTime;
	}

	public bool GetSnitchValue () {
		return SnitchCatched;
	}

	public float getSnitchCatchTime () {
		return SnitchTime;
	}

	public float getLevelTime () {
		return LevelTime - timer;
	}

	public void SetSnitchValue () {
		SnitchCatched = true;
		SnitchTime = LevelTime - timer;
	}

	public float GetTime () {
		return LevelTime - timer;
	}

	public void setRingCount (int currentoCount) {
		ringCount = currentoCount;
	}

	public int getRingCount(){
		return ringCount;
	}
	public void EndGame () {
		Time.timeScale = 1;
		StartCoroutine (LoadExitScreen ());
	}

	IEnumerator LoadExitScreen () {
		yield return new WaitForSeconds(5);
		Debug.Log ("LOAD EXIT");
		SceneManager.LoadScene ("ExitScreen");
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer<0f) {
			showText.text = "Time Over!";
			EndGame ();
		}
	}
}
