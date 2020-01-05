using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class HCCaptain : MonoBehaviour {

    //float enemySpawn = 5;
    public GameObject player;
    //public GameObject enemy;
    public GameObject eventSystem;
    public GameObject pauseButton;
    public GameObject bossText;
    public float waitToReload;
    private bool gameFinished = false;
    //System.Random random = new System.Random();

    void Start()
    {


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(5);
        }

        /* enemySpawn -= Time.deltaTime;

         if (enemySpawn < 0 && player.activeSelf)
        {
            enemySpawn = 5;
            switch (random.Next(0, 4))
            {
                case 0:
                    Instantiate(enemy, new Vector3(-9.6f, random.Next(-3, 4) * 3.2f, 0), transform.rotation);
                    break;
                case 1:
                    Instantiate(enemy, new Vector3(9.6f, random.Next(-3, 4) * 3.2f, 0), transform.rotation);
                    break;
                case 2:
                    Instantiate(enemy, new Vector3(random.Next(-3, 4) * 3.2f, -9.6f, 0), transform.rotation);
                    break;
                case 3:
                    Instantiate(enemy, new Vector3(random.Next(-3, 4) * 3.2f, 9.6f, 0), transform.rotation);
                    break;

            }
        } */

            

        if (player.activeSelf == false)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
                SceneManager.LoadScene(3);
            }
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !gameFinished)
        {

            Social.ReportProgress("CgkIlJLPpM8BEAIQAQ", 100.0f, (bool val) =>
            {
                // handle success or failure
            });


            eventSystem.GetComponent<Pause>().ChangeState();
            pauseButton.SetActive(false);
            bossText.SetActive(false);
            gameFinished = true;
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(5);
    }

}
