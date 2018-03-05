using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelScript : MonoBehaviour {

	//Scene DestroyThisLevel;
	public string LevelName;

	//Makes this Object Eternal unless it is poisoned and destroyed on the inside.
	public void Awake(){
		DontDestroyOnLoad (this);
	}

	void LoadLevel ()
    {
		//DestroyThisLevel = SceneManager.GetActiveScene ();
		SceneManager.LoadScene ("LoadScreen");
		StartCoroutine (LoadNewScene(LevelName));
		//StartCoroutine (UnloadPreviousScene ("MenuLevel"));
    }

	/*
	IEnumerator UnloadPreviousScene(string scenename){
		Debug.Log ("Active Scene :" + scenename);
		AsyncOperation unload = SceneManager.UnloadSceneAsync (scenename);
		while (!unload.isDone) {
			yield return null;
		}
		Debug.Log ("Previous Scene Unloaded");
	
	}
	*/

	void OnTriggerEnter(Collider other) {
		LoadLevel ();
	}

	//Co Routine for loading a new scene
	IEnumerator LoadNewScene(string Level){

		yield return new WaitForSeconds (3);
		//DestroyThisLevel = SceneManager.GetActiveScene ();
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
