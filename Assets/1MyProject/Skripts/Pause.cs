using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausepanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausepanel.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void BTG()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void BTL()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(5);
    }
    
    
    public void Exit()
    {
        Application.Quit();
    }

    
}
