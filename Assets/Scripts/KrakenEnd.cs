using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class KrakenEnd : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {

            int last_level = 0;
            Int32.TryParse(File.ReadAllText(Application.persistentDataPath + "/level.pb"), out last_level);

            if (last_level == 14)
            {
                last_level++;
                File.WriteAllText(Application.persistentDataPath + "/level.pb", last_level.ToString());
            }

            Social.ReportProgress("CgkIlJLPpM8BEAIQBQ", 100.0f, (bool val) =>
            {
                // handle success or failure
            });

            SceneManager.LoadScene(4);
        }
}
}
