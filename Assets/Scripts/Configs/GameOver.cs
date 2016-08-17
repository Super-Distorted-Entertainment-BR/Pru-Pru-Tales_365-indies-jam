using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    
    void Start () {
    
    }
	
	void Update () {

	}

    //Game Jolt API
    public void setScore()
    {
        int scoreValue = GameConfig.score; // The actual score.
        string scoreText = scoreValue + " points"; // A string representing the score to be shown on the website.
        int tableID = GameConfig.highScore_id; // Set it to 0 for main highscore table.
        string extraData = ""; // This will not be shown on the website. You can store any information.

        GameJolt.API.Scores.Add(scoreValue, scoreText, tableID, extraData, (bool success) => {
            Debug.Log(string.Format("Score Add {0}.", success ? "Successful" : "Failed"));
        });
    }
}
