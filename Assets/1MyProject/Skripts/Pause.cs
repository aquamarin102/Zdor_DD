using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausepanel;

    public void Play(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }
    public void BTG()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }

}
