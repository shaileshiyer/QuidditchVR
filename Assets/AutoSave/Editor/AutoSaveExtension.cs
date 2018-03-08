using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

namespace EckTechGames
{
	[InitializeOnLoad]
	public class AutoSaveExtension
	{
		// Static constructor that gets called when unity fires up.
		static AutoSaveExtension()
		{
			EditorApplication.playmodeStateChanged += AutoSaveWhenPlaymodeStarts;
		}

		private static void AutoSaveWhenPlaymodeStarts()
		{
			// If we're about to run the scene...
			if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
			{
				// Save the scene and the assets.
				//EditorSceneManager.SaveScene();
				EditorSceneManager.SaveScene (EditorSceneManager.GetActiveScene ());
				AssetDatabase.SaveAssets();
			}
		}
	}
}