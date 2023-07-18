using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
namespace Quest
{
    public class TossShield : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Shoot();
            }      
        }

        private void Shoot()
        {
           PhotonNetwork.Instantiate("Shield", spawnPoint.position, spawnPoint.rotation);
        }
    }
}