using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class BearAI : MonoBehaviour
{
    public List<Transform> Waypoints;
    public float VisionRange = 5f;
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
        if (angleToPlayer > VisionAngle / 2) return false;

        Ray ray = new Ray(player.position, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, VisionRange) && hit.collider.tag == "player")
        {
            return false;
        }

        

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
