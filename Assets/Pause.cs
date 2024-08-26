using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    bool paused = false;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] Ball ball;
    [SerializeField] GameObject wins;
    [SerializeField] GameObject lose;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            paused = togglePause();
        if(ball.win == 1)
        {
            Time.timeScale = 0f;
            wins.SetActive(true);
        }
        else if (ball.win == -1)
        {
            Time.timeScale = 0f;
            lose.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("game");
        }
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            return (true);
        }
    }
}
