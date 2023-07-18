using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;

namespace Quest
{
    
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 10;
        [SerializeField] private CoinForJuj _coin;
        
        private int curHealth;
        private void Awake()
        {
            
            curHealth = maxHealth;
        }
        public void Hit(int damage)
        {
            curHealth -= damage;
            if (curHealth <= 0)
            {
                Die();
            }
        }
 
        private void Die()
        {
            _coin.MoneyForKill();
            PhotonNetwork.Destroy(gameObject);
            
        }
        
       
    }
}
