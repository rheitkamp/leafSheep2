using UnityEngine;
using System.Collections;

public class buttonAction : MonoBehaviour {
		
	public void StartGame(string levelName)
	{
		Application.LoadLevel(levelName);
	}

	public void RestartLevelButton() {
	//reload the same level
	}
}
