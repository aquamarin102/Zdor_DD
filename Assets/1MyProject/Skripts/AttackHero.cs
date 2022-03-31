using UnityEngine;

namespace Quest
{
    public class AttackHero : MonoBehaviour
    {
        private float timeBtwAttack;
        [SerializeField] private float startTimeBtwAtack;

        private string animAttack = "attack";

        [SerializeField] private Transform attackPos;
        [SerializeField] private LayerMask enemy;
        [SerializeField] private float attackRange;
        [SerializeField] private int damage;
        [SerializeField] private Animator anim;

        private void Update()
        {
            if (timeBtwAttack <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    anim.SetTrigger(animAttack);
                    Collider[] enemies = Physics.OverlapSphere(attackPos.position, attackRange, enemy);
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<Health>().Hit(damage);
                    }
                }
                timeBtwAttack = startTimeBtwAtack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
    }
}