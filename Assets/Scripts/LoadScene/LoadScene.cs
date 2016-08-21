using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string scene;

    InputConfig inputConfig= new InputConfig();

    void Start () {
	
	}
	
	void Update () {

        if (inputConfig.action())
        {
            SceneManager.LoadScene(scene);
        }
       
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(scene);
    }
}
