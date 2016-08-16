using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;



public class Teste : MonoBehaviour {

    public bool isSignedIn;
    
    public Text signedIn;

    public GameObject buttons;

    public Sprite notificationSprite;

    // verifica se o site "http://gamejolt.com" esta disponivel para conexão
    bool CheckForInternetConnection()
    {
        System.Net.WebClient client;
        System.IO.Stream stream;
        try
        {
            client = new System.Net.WebClient();
            stream = client.OpenRead("http://gamejolt.com");
            return true;
        }
        catch (WebException e)
        {
            return false;
        }
    }

    void Start () {

        Debug.Log("Internet Esta ativa: "+CheckForInternetConnection());

        if (CheckForInternetConnection())
        {
            GameJolt.UI.Manager.Instance.ShowSignIn();
        }
    }

	void Update () {
        isSignedIn = GameJolt.API.Manager.Instance.CurrentUser != null;

        signedIn.text = "SignedIn: " + isSignedIn;

        if (isSignedIn== true)
        {
            buttons.SetActive(true);
        }

      //  GameJolt.UI.Manager.Instance.

    }


    public void unlockTrophie()
    {
        int trophyID = 64433;//trofel de teste

        GameJolt.API.Trophies.Unlock(trophyID, (bool success) => {
        if (success)
           {
              Debug.Log("Success!");
           }
            else
           {
               Debug.Log("Something went wrong");
             }
            });

        //exibe trofel
        //GameJolt.UI.Manager.Instance.ShowTrophies();
    }


    public void score()
    {
        int scoreValue = Random.Range(1,3000); // The actual score.
         string scoreText = scoreValue + " points"; // A string representing the score to be shown on the website.
         int tableID = 90910; // Set it to 0 for main highscore table.
         string extraData = ""; // This will not be shown on the website. You can store any information.
        
     GameJolt.API.Scores.Add(scoreValue, scoreText, tableID, extraData, (bool success) => {
         Debug.Log(string.Format("Score Add {0}.", success ? "Successful" : "Failed"));
     });
    }

    public void showLeaderboards()
    {
        GameJolt.UI.Manager.Instance.ShowLeaderboards();

        buttons.SetActive(false);
    }

    public void notification()
    {
        // Text only
         //GameJolt.UI.Manager.Instance.QueueNotification("GameJolt is awesome!");
    
     // Text & Image (UnityEngine.Sprite)
     GameJolt.UI.Manager.Instance.QueueNotification("Bem vindo, esse e um teste.", notificationSprite);
    }

    //Custom UI
    //var user = new GameJolt.API.Objects.User(userName, userToken);
    //user.SignIn((bool success) => {
    //    if (success)
    //    {
    //        Debug.Log("Success!");
    //    }
    //    else
    //    {
    //        Debug.Log("The user failed to signed in :(");
    //   }
    //});


    //Sign Out
    //var isSignedIn = GameJolt.API.Manager.Instance.CurrentUser != null;
    //if (isSignedIn)
    //{
    //    GameJolt.API.Manager.Instance.CurrentUser.SignOut();
    //}




}
