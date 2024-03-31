    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> targetPoint;
    public PlayerTPSController Player;
    public float viewAngle = 90;
    public int DeadInt = 0;
    public float damage = 30;

    private NavMeshAgent _navMeshAgent;
    private bool isPlayerNoticed;
    [SerializeField] private PlayerHealth PLHPComp;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        pickNewPoint();
    }

    void Update()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
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
            if ((_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) && (DeadInt == 0))
            {
                PLHPComp.DamagePlayer(damage * Time.deltaTime);
            }
        }

        if (DeadInt == 1)
        {
            _navMeshAgent.destination = transform.position;
        }
    }

    private void pickNewPoint()
    {

        _navMeshAgent.destination = targetPoint[Random.Range(0, targetPoint.Count)].position;

    }
}
