using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour {
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void TrackLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void TrackLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void TrackLevel3()
    {
        SceneManager.LoadScene(4);
    }
}
