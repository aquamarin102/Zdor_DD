using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    [SerializeField] private GameObject pausepanel;
    
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