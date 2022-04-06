using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Quest
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class FollowPlayer : MonoBehaviour
    {
        private NavMeshAgent agent;
        private HeroMove player;



        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            player = FindObjectOfType<HeroMove>();
        }

        private void Update()
        {
                agent.SetDestination(player.transform.position); 
        }
    }
}
