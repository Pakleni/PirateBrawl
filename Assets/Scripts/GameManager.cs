using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System;
using System.IO;

public class GameManager : MonoBehaviour {


    public GameObject player;
    public GameObject enemy;
    public GameObject captain;
    public GameObject skelleton;
    public GameObject witch;
    public GameObject textMesh;
    GameObject levelManager;
    public float waitToReload;
    public int level;
    private float waitToLevel = 1f;
    private bool gameStarted = false;
    private bool gameFinished = false;
    System.Random random = new System.Random();

    // Use this for initialization
    void Start() {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        level = levelManager.GetComponent<LevelManager>().current_level;


        if (level < 14)
        {
            textMesh.SetActive(true);
            textMesh.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("Level {0}", level);
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(5);
            Destroy(levelManager);
        }
        waitToLevel -= Time.deltaTime;

        if (waitToLevel < 0 && !gameStarted)
        {

            gameStarted = true;
            textMesh.SetActive(false);

            if (level < 7)
            {
                for (int i = 0; i < level; i++)
                {
                    switch (random.Next(0, 4))
                    {
                        case 0:
                            Instantiate(enemy, new Vector3(-9.6f, random.Next(-2, 3) * 3.2f, 0), transform.rotation);
                            break;
                        case 1:
                            Instantiate(enemy, new Vector3(9.6f, random.Next(-2, 3) * 3.2f, 0), transform.rotation);
                            break;
                        case 2:
                            Instantiate(enemy, new Vector3(random.Next(-3, 4) * 3.2f, -6.4f, 0), transform.rotation);
                            break;
                        case 3:
                            Instantiate(enemy, new Vector3(random.Next(-3, 4) * 3.2f, 6.4f, 0), transform.rotation);
                            break;

                    }
                }
            }
            else if (level == 7) { Instantiate(captain); }
            else if (level < 13)
            {
                for (int i = 0; i < level - 7 && i < 3; i++)
                {
                    switch (random.Next(0, 4))
                    {
                        case 0:
                            Instantiate(skelleton, new Vector3(-9.6f, random.Next(-2, 3) * 3.2f, 0), transform.rotation);
                            break;
                        case 1:
                            Instantiate(skelleton, new Vector3(9.6f, random.Next(-2, 3) * 3.2f, 0), transform.rotation);
                            break;
                        case 2:
                            Instantiate(skelleton, new Vector3(random.Next(-3, 4) * 3.2f, -6.4f, 0), transform.rotation);
                            break;
                        case 3:
                            Instantiate(skelleton, new Vector3(random.Next(-3, 4) * 3.2f, 6.4f, 0), transform.rotation);
                            break;

                    }
                }
                for (int i = 0; i < level - 7 - 2; i++)
                {
                    switch (random.Next(0, 4))
                    {
                        case 0:
                            Instantiate(enemy, new Vector3(-9.6f, random.Next(-2, 3) * 3.2f, 0), transform.rotation);
                            break;
                        case 1:
                            Instantiate(enemy, new Vector3(9.6f, random.Next(-2, 3) * 3.2f, 0), transform.rotation);
                            break;
                        case 2:
                            Instantiate(enemy, new Vector3(random.Next(-3, 4) * 3.2f, -6.4f, 0), transform.rotation);
                            break;
                        case 3:
                            Instantiate(enemy, new Vector3(random.Next(-3, 4) * 3.2f, 6.4f, 0), transform.rotation);
                            break;

                    }
                }

            }

            else if (level == 13) { Instantiate(witch); }

        }

        if (player.activeSelf == false)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
                Destroy(levelManager);
                SceneManager.LoadScene(3);
            }
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && gameStarted && !gameFinished)
        {

            gameFinished = true;
            int last_level = 0;
            Int32.TryParse(File.ReadAllText(Application.persistentDataPath + "/level.pb"), out last_level);

            if (last_level==level)
            {
                last_level++;
                File.WriteAllText(Application.persistentDataPath + "/level.pb", last_level.ToString());
            }
            if (level == 7)
            {
                Social.ReportProgress("CgkIlJLPpM8BEAIQAw", 100.0f, (bool val) =>
                {
                    // handle success or failure
                });
            }
            else if (level == 13)
            {
                Social.ReportProgress("CgkIlJLPpM8BEAIQBA", 100.0f, (bool val) =>
                {
                    // handle success or failure
                });
            }
            if (level < 13)
            {
                levelManager.GetComponent<LevelManager>().PlayGame(level + 1);
            }
        }
    }

    public void GoToMenu()
    {
        Destroy(levelManager);
        SceneManager.LoadScene(5);
    }
}
