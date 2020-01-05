using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{


    public GameObject player;
    public GameObject eventSystem;
    public GameObject pauseButton;
    public GameObject tutorial1;
    public GameObject tutorial2;

    public float waitToReload;
    private bool gameFinished = false;

    public void toggletutorial()
    {
        tutorial2.SetActive(!tutorial2.activeSelf);
        tutorial1.SetActive(!tutorial1.activeSelf);
    }

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(5);
        }


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
            toggletutorial();
            eventSystem.GetComponent<Pause>().ChangeState();
            pauseButton.SetActive(false);
            gameFinished = true;
        }
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(5);
    }
}
