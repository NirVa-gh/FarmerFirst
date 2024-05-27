using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSettings : MonoBehaviour
{
    public GameObject panel;
    private PauseEsc pauseEsc;
    private playercontroller playercontroller_r;

    private int TestValue = 34;


    void Start()
    {
        pauseEsc = gameObject.GetComponent<PauseEsc>();
        panel.SetActive(false);
        playercontroller_r = GameObject.Find("player").GetComponent<playercontroller>();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Prototype 2");
        Time.timeScale = 1;
        playercontroller_r.isAlive = true;
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Pause()
    {
        if (!pauseEsc.paused)
        {
            Time.timeScale = 0;
            pauseEsc.paused = true;
            panel.SetActive(true);
        }  
    }
    public void Continue()
    {
        if (pauseEsc.paused)
        {
            Time.timeScale = 1;
            pauseEsc.paused = false;
            panel.SetActive(false);
        }
    }
}
