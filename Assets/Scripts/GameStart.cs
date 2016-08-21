using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene("5 - Game");
		}
	}
}
