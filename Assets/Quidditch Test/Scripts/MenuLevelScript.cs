using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelScript : MonoBehaviour {

	//Scene DestroyThisLevel;


	//Makes this Object Eternal unless it is poisoned and destroyed on the inside.
	public void Awake(){
		DontDestroyOnLoad (this);
	}

	public void LoadLevel ( string LevelName )
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
