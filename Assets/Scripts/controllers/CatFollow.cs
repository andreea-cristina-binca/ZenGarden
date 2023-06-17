using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatFollow : MonoBehaviour
{
    [SerializeField] private Transform followPoint;

    public Animator animator;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.destination = followPoint.position;

        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance && navMeshAgent.path.status == NavMeshPathStatus.PathComplete)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
