using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AudioControl : MonoBehaviour
{

    public bool gui = false;

    void Start()
    {

    }

    void Update()
    {

        if (gameObject.GetComponent<AudioSource>() != null)
        {
            gameObject.GetComponent<AudioSource>().volume = GameConfig.soundManager.MusicVolume;
        }

    }


    void OnGUI()
    {
        if (gui)
        {

            GUI.Box(new Rect(20, 20, 120, 90), "AUDIO OPTIONS");

            GUI.Label(new Rect(30, 40, 120, 90), "Music Volume:");
            GameConfig.soundManager.MusicVolume = GUI.HorizontalSlider(new Rect(30, 60, 100, 30), GameConfig.soundManager.MusicVolume, 0.0f, 1.0f);

            GUI.Label(new Rect(30, 70, 120, 90), "Sfx Volume:");
            GameConfig.soundManager.SfxVolume = GUI.HorizontalSlider(new Rect(30, 90, 100, 30), GameConfig.soundManager.SfxVolume, 0.0f, 1.0f);

        }


    }

}
