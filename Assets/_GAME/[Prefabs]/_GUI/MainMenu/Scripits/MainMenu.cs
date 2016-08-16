using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

    public GameObject loginButton;

    public InputConfig inputConfig;

    public int position;

    public AudioClip movClip;
    public AudioClip selectClip;

    public GameObject soundButton;
    public Sprite soundButton_ON;
    public Sprite soundButton_OFF;

    public GameObject languageButton;
    public Sprite languageButton_EN;
    public Sprite languageButton_PT;

    public GameObject INSERT_COIN;
    public GameObject COMUNITY_SCORE;
    public GameObject CREDITS;

    public bool audioState;

    public string gameScene;
    public string creditsScene;
    public string openingScene;

  //  public GameObject GJ_Panel;

    void Start ()
    {
        inputConfig = new InputConfig();

        position = 0;

        GameConfig.isInternetConnection = GameConfig.checkForInternetConnection();

       if (GameConfig.isSignedIn == true)
        {
            loginButton.SetActive(false);
        }

    }
	

	void Update ()
    {
        GameConfig.isPaused = GameObject.Find("GameJoltAPI/UI/Modal").activeSelf;

        if (GameConfig.isPaused==false)
        {

            // Gerenciamento do login no  GameJolt
            GameConfig.isSignedIn = GameJolt.API.Manager.Instance.CurrentUser != null;

            if (GameConfig.isInternetConnection == true && GameConfig.isSignedIn == false)
            {
                loginButton.SetActive(true);
            }
            else
            {
                loginButton.SetActive(false);
            }
            
            // Menu ======================================================================

            INSERT_COIN.GetComponent<Text>().color = Color.white;
            INSERT_COIN.transform.localScale = new Vector3(0.8f, 0.8f, 1);

            COMUNITY_SCORE.GetComponent<Text>().color = Color.white;
            COMUNITY_SCORE.transform.localScale = new Vector3(0.8f, 0.8f, 1);
            COMUNITY_SCORE.SetActive(GameConfig.isSignedIn);

            CREDITS.GetComponent<Text>().color = Color.white;
            CREDITS.transform.localScale = new Vector3(0.8f, 0.8f, 1);

            switch (position)
            {
                case 0:

                    INSERT_COIN.GetComponent<Text>().color = Color.yellow;

                    INSERT_COIN.transform.localScale = new Vector3(1, 1, 1);

                    if (inputConfig.action())
                    {
                        GameConfig.soundManager.PlaySound(selectClip, Camera.main.transform.position);

                        if (gameScene != "")
                        {
                            SceneManager.LoadScene(gameScene);
                        }
                    }

                    break;

                case 1:
                    
                    if (GameConfig.isSignedIn == true)
                    {
                        COMUNITY_SCORE.GetComponent<Text>().color = Color.yellow;

                        COMUNITY_SCORE.transform.localScale = new Vector3(1, 1, 1);

                        if (inputConfig.action())
                        {
                            GameConfig.soundManager.PlaySound(selectClip, Camera.main.transform.position);

                            GameJolt.UI.Manager.Instance.ShowLeaderboards();
                        }
                    }

                    break;

                case 2:

                    CREDITS.GetComponent<Text>().color = Color.yellow;

                    CREDITS.transform.localScale = new Vector3(1, 1, 1);

                    if (inputConfig.action())
                    {
                        GameConfig.soundManager.PlaySound(selectClip, Camera.main.transform.position);

                        if (creditsScene != "")
                        {
                            SceneManager.LoadScene(creditsScene);
                        }
                    }

                    break;
                    
            }

            if (inputConfig.Up() && position > 0)
            {
                position--;

                GameConfig.soundManager.PlaySound(movClip, Camera.main.transform.position);
            }

            if (inputConfig.Down() && position < 2)
            {
                position++;

                GameConfig.soundManager.PlaySound(movClip, Camera.main.transform.position);
            }
            
        }

    }

    // Abre o menu de ligin do GameJolt
    public void GJ_Login()
    {
         GameJolt.UI.Manager.Instance.ShowSignIn();
    }

    public void changeLanguage()
    {
        GameConfig.soundManager.PlaySound(selectClip, Camera.main.transform.position);

        switch (GameConfig.Language)
        {
            case LanguageUID.ENGLISH:
                GameConfig.Language = LanguageUID.PORTUGUESE;
                languageButton.GetComponent<Image>().sprite = languageButton_PT;
                break;

            case LanguageUID.PORTUGUESE:
                GameConfig.Language = LanguageUID.ENGLISH;
                languageButton.GetComponent<Image>().sprite = languageButton_EN;
                break;
        }

    }

    public void changeSound()
    {
        GameConfig.soundManager.PlaySound(selectClip, Camera.main.transform.position);

        switch (audioState)
        {
            case true:
                audioState = false;
                soundButton.GetComponent<Image>().sprite = soundButton_OFF;
                GameConfig.soundManager.MusicOn = false;
                GameConfig.soundManager.SfxOn = false;
                break;

            case false:
                audioState = true;
                soundButton.GetComponent<Image>().sprite = soundButton_ON;
                GameConfig.soundManager.MusicOn = true;
                GameConfig.soundManager.SfxOn = true;
                break;
        }
        
    }

}
