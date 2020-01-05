using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class MenuScreen : MonoBehaviour {

    void Start()
    {

        StartGooglePlay();
        Authenticate();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void StartGooglePlay()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
    }
    void Authenticate()
    {
        // authenticate user:
        Social.localUser.Authenticate((bool success) => {
            // handle success or failure
            if (success)
            {
                //((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.TOP);
                //Welcome the player
                Social.ReportProgress("CgkIlJLPpM8BEAIQAg", 100.0f, (bool val) =>
                {
                    // handle success or failure
                });
            }
        });
    }
    
}
