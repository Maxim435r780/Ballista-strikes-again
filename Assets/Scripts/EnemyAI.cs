    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> targetPoint;
    public PlayerTPSController Player;
    public float viewAngle = 90;

    private NavMeshAgent _navMeshAgent;
    private bool isPlayerNoticed;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        pickNewPoint();
    }

    void Update()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            if (!isPlayerNoticed)
            {
                pickNewPoint();
            }
        }

        var direction = Player.transform.position - transform.position;
        isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    isPlayerNoticed = true;
                }
            }
        }

        if (isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
    }

    private void pickNewPoint()
    {

        _navMeshAgent.destination = targetPoint[Random.Range(0, targetPoint.Count)].position;

    }
}
