using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class LevelScreen : MonoBehaviour {


    public Button[] buttons;



    void Start () {
        if (!File.Exists(Application.persistentDataPath + "/level.pb"))
        {
            File.WriteAllText(Application.persistentDataPath + "/level.pb", "1");
        }

        int level = 0;

        Int32.TryParse(File.ReadAllText(Application.persistentDataPath + "/level.pb"), out level);
        for (int i = 0; i < level; i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Destroy(GameObject.FindGameObjectWithTag("LevelManager"));
            Application.Quit();
        }
    }
    public void ShowAchievements()
    {
        Social.ShowAchievementsUI();
    }
}
