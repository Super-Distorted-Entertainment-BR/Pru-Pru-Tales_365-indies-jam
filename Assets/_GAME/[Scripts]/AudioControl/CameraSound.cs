using UnityEngine;
using System.Collections;

public class CameraSound : MonoBehaviour {

	void Start () {
	
	}


	void Update () {

        if(gameObject.GetComponent<AudioSource>()!=null)
        {
            gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().volume = GameConfig.soundManager.MusicVolume;
        }
	
	}
}
