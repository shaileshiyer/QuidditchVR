using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelScript : MonoBehaviour {
	public void LoadLevel ( string LevelName )
    {
        SceneManager.LoadScene(LevelName);
    }
}
