using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string scene;

    InputConfig inputConfig= new InputConfig();

    void Start () {
	
	}
	
	void Update () {
       
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(scene);
    }
}
