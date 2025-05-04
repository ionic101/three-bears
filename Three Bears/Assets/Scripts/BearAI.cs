using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class BearAI : MonoBehaviour
{
    public List<Transform> Waypoints;
    public float VisionRange = 10f;
    public float VisionAngle = 120f;
    public float ChaseSpeed = 5f;
    public float PatrolSpeed = 2f;
    public Transform player;
    public float TimeToStopFollow = 1f;

    private const float DistanceToFinish = 3f;
    private NavMeshAgent navMeshAgent;
    private int curWaypointIndex = 0;
    private bool isChasing = false;

    private float curTimeToStopFollow = 0f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = PatrolSpeed;
    }

    private void Update()
    {
        if (IsCanSeePlayer())
        {
            curTimeToStopFollow = 0f;
            StartFollowPlayer();
        }
        else
        {
            curTimeToStopFollow += Time.deltaTime;
            if (curTimeToStopFollow >= TimeToStopFollow)
            {
                curTimeToStopFollow = 0f;
                StopFollowPlayer();
            }
        }
            
        if (!isChasing)
        {
            Patrol();
        }
    }

    private bool IsCanSeePlayer()
    {
        if (player == null) return false;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > VisionRange) return false;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        Debug.Log(angleToPlayer);
        if (angleToPlayer > VisionAngle / 2) return false;
        return true;
    }

    private void StartFollowPlayer()
    {
        isChasing = true;
        navMeshAgent.speed = ChaseSpeed;
        navMeshAgent.SetDestination(player.position);
    }

    private void StopFollowPlayer()
    {
        isChasing = false;
        navMeshAgent.speed = PatrolSpeed;
    }

    private void Patrol()
    {
        if (Waypoints.Count == 0) return;

        float distance = Vector3.Distance(transform.position, Waypoints[curWaypointIndex].position);
        if (distance < DistanceToFinish)
        {
            curWaypointIndex = (curWaypointIndex + 1) % Waypoints.Count;
        }

        navMeshAgent.SetDestination(Waypoints[curWaypointIndex].position);
    }
}