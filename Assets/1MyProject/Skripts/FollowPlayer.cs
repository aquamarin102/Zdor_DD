using UnityEngine;
using UnityEngine.AI;

namespace Quest
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class FollowPlayer : MonoBehaviour
    {
        private NavMeshAgent agent;
        private HeroMove player;

        [SerializeField] private float damage = 1f;


        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            player = FindObjectOfType<HeroMove>();
        }

        private void Update()
        {
                agent.SetDestination(player.transform.position); 
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Health health))
            {
                health.Hit(damage);
            }
            Destroy(gameObject);
        }
    }
}
