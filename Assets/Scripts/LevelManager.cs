using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    
    public int current_level = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    public void PlayGame(int level)
    {
        SceneManager.LoadScene(1);
        current_level = level;
    }
    public void Kraken()
    {
        SceneManager.LoadScene(2);
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(6);
        Destroy(gameObject);
    }
    public void HARDCORE()
    {
        SceneManager.LoadScene(7);
        Destroy(gameObject);
    }
    public void Multiplayer()
    {
        SceneManager.LoadScene(8);
        Destroy(gameObject);
    }
}
