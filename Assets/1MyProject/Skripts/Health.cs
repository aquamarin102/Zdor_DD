using UnityEngine;

namespace Quest
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 10f;
        public float curHealth;

        private void Awake()
        {
            curHealth = maxHealth;
        }
        public void Hit(float damage)
        {
            curHealth -= damage;
            if (curHealth <= 0)
            {
                Die();
            }
        }
        public void Heal(float hp)
        {
            curHealth += hp;
            if (curHealth <= 0)
            {
                return;
            }
        }
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
