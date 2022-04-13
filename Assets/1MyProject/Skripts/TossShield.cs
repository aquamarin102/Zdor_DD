using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Quest
{
    public class TossShield : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Shield heroShield;

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Shoot();
            }      
        }

        private void Shoot()
        {
            var shit = Instantiate(heroShield, spawnPoint.position, spawnPoint.rotation);
        }
    }
}