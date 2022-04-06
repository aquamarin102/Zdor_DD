using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Quest
{
    public class Patrol : MonoBehaviour
    {
        private NavMeshAgent agent;
        private HeroMove player;

        [SerializeField] private Transform[] waypoints;
        private int m_CurrentWaypointIndex;
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();

        }
        void Start()
        {
            agent.SetDestination(waypoints[0].position);
        }

        // Update is called once per frame
        void Update()
        {
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                agent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
        }
    }
}