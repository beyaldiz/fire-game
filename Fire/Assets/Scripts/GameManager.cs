using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey("escape"))
            resetgame();
        if (Input.GetKey("p"))
            exitgame();
    }
    public void resetgame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    void exitgame()
    {
        Application.Quit();
    }
}
