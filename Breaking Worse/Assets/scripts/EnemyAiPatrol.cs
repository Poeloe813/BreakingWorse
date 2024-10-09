using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiPatrol : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;

    //rond lopen(patrol)
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float walkrange;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("player");
    } void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkpointSet) SearchDest();
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    void SearchDest()
    {
        float z = Random.Range(-walkrange, walkrange);
        float x = Random.Range(-walkrange, walkrange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
