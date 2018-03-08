using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerLogic : MonoBehaviour {
	public float LevelTime;
	private float timer;
	private float SnitchTime;
	private bool SnitchCatched;
	private bool CountTime;
	private Text showText;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		CountTime = true;
		SnitchTime = 0f;
		showText = GameObject.FindGameObjectWithTag("Help").GetComponent<Text> ();
	}

	public bool GetSnitchValue () {
		return SnitchCatched;
	}

	public float getSnitchCatchTIme () {
		return SnitchTime;
	}

	public float getLevelTime () {
		return timer;
	}

	public void SetSnitchValue () {
		SnitchCatched = true;
		SnitchTime = timer;

	}

	public float GetTime () {
		return timer;
	}

	public void EndGame () {
		CountTime = false;
		//yield return new WaitForSeconds (5);
		SceneManager.LoadScene ("ExitScreen");
	}

	// Update is called once per frame
	void Update () {
		if (CountTime) {
			if (timer > LevelTime) {
				CountTime = false;
				showText.text = "Time Over!";
				EndGame ();
			} else {
				timer += Time.deltaTime;
			}
		}
	}
}
