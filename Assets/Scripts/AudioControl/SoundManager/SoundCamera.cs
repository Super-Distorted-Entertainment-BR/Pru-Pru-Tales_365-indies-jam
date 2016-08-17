using UnityEngine;
using System.Collections;

public class SoundCamera : MonoBehaviour {

    private AudioSource audioSource;

    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }


	void Update ()
    {

        if(gameObject.GetComponent<AudioSource>()!=null)
        {
           GameConfig.soundManager.PlayBackgroundMusic(audioSource);
        }
	
	}
}
