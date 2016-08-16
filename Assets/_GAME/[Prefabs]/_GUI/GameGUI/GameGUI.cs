using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour {

    public GameObject score;
    public GameObject enemiesKills;

    void Start () {
	
	}
	
	void Update () {

          score.GetComponent<Text>().text = ""+GameConfig.score;
          enemiesKills.GetComponent<Text>().text = "" + GameConfig.enemiesKills;

    }
}
