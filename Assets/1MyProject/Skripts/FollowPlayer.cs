using UnityEngine;
using UnityEngine.AI;

namespace Quest
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class FollowPlayer : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private PlayerController _player;

        [SerializeField] private int damage = 10;
        


        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _player = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            if(_player.gameObject != null) 
                _agent.SetDestination(_player.transform.position); 
            else
                Destroy(gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out PlayerController health))
            {
                health.Hit(damage);
            }
            if(collision.gameObject.TryGetComponent(out Health healthEnemy))
            {
                healthEnemy.Hit(damage);
            }
            
            Destroy(gameObject);
        }
    }
}
