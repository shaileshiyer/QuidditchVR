using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelScript : MonoBehaviour {

	public string LevelName;

	//Makes this Object Eternal unless it is poisoned and destroyed on the inside.
	public void Awake(){
		DontDestroyOnLoad (this);
	}

	void LoadLevel ()
	{
		SceneManager.LoadScene ("LoadScreen");
		StartCoroutine (LoadNewScene(LevelName));
	}

	void OnTriggerEnter(Collider other) {
		LoadLevel ();
	}

	//Co Routine for loading a new scene
	IEnumerator LoadNewScene(string Level){
		yield return new WaitForSeconds (3);
		Debug.Log("Loading Scene async");
		AsyncOperation load = SceneManager.LoadSceneAsync (Level);

		load.allowSceneActivation = false;
		while (load.progress < 0.9f)
		{
			Debug.Log("Progress: " + load.progress);
			yield return null;
		}
		load.allowSceneActivation = true;
	}
}
