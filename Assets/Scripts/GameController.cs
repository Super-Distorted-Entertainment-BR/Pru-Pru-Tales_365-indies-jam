using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject control;

	void Awake () {
		if (control == null) {
			DontDestroyOnLoad(gameObject);
			control = gameObject;
		} else if (control != gameObject) {
			Destroy(gameObject);
		}
	}

	void Start () {

	}

	void Update () {
		if (GameConfig.playerIsDead == true)
		{
			GameConfig.playerIsDead = false;
			SceneManager.LoadScene("4 - Game Over");
		}
	}
}
