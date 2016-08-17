using UnityEngine;
using System.Collections;

public class Achievements : MonoBehaviour
{
    //SD - Platina Trophie
    public void SD()
    {
        int trophyID = 64433; //SD (API - Teste)

        GameJolt.API.Trophies.Unlock(trophyID, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Success!");
            }
            else
            {
                Debug.Log("Something went wrong");
            }
        });
    }
}
