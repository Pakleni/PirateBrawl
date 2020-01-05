using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    private bool paused = false;
    public bool cheats;

    public void ChangeState() {
        paused = !paused;
        leftController.SetActive(!leftController.activeSelf);
        rightController.SetActive(!rightController.activeSelf);
        PauseOverlay.SetActive(!PauseOverlay.activeSelf);
        menuButton.SetActive(!menuButton.activeSelf);
        if (cheats)
        {
            CheatsButton.SetActive(!CheatsButton.activeSelf);
        }
    }

    public GameObject leftController;
    public GameObject rightController;
    public GameObject pauseButton;
    public Sprite playImage;
    public Sprite pauseImage;
    public GameObject PauseOverlay;
    public GameObject CheatsButton;
    public GameObject menuButton;

    // Update is called once per frame
    void Update () {
		if (paused)
        {
            Time.timeScale = 0;          
            pauseButton.GetComponent<Image>().sprite = playImage;
            
        }
        else
        {
            Time.timeScale = 1;
            pauseButton.GetComponent<Image>().sprite = pauseImage;
        }
	}
}
