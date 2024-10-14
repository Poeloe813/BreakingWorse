using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiPatrol : MonoBehaviour, ITakeDamageM
{
    GameObject player;

    public PlayerHp playerHp;

    //player
    NavMeshAgent agent;

    // navmesh
    [SerializeField] LayerMask groundLayer, playerLayer;
    // layers

    //patrol
    Vector3 destPoint;

    // waar de enemy heen gaat
    bool walkpointSet;

    // of de walkpoint is gezet
    [SerializeField] float walkrange;

    // hoe ver de enemy kan lopen
    //state change
    [SerializeField] private float sightRange, attackRange;
    bool playerInSight, playerInAttackRange;
    // of de player in zicht is en of de player in aanvals range is
    [SerializeField] private float cooldownTime;
    // cooldown tijd

    private float nextAttackTime;

    private bool isCoolingDown() => Time.time < nextAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // navmesh
        player = GameObject.Find("player");
        // player vinden
    }

    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        // kijkt of de player in zicht is in een cirkel
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        // kijkt of de player in aanvals range is in een cirkel
        if (!playerInAttackRange && !playerInSight) Patrol();
        // als de player niet in aanvals range is en niet in zicht is gaat de enemy patrollen
        if (!playerInAttackRange && playerInSight) Chase();
        // als de player niet in aanvals range is en wel in zicht is gaat de enemy de player achterna
        if (playerInAttackRange && playerInSight) Attack();
        // als de player in aanvals range is en in zicht is gaat de enemy de player aanvallen
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position);
        // als de player in zicht is gaat de enemy de player achterna
    }

    void Attack()
    {
        if (isCoolingDown())
        {
            return;
        }

        TakeDamageM(1);


        StartCooldown();
    }
    private void StartCooldown()
    {
        nextAttackTime = Time.time + cooldownTime;
    }

    void Patrol()
    {
        if (!walkpointSet) SearchDest();
        //functie hier onder
        if (walkpointSet) agent.SetDestination(destPoint);
        // als de walkpoint is gezet gaat de enemy naar de walkpoint
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    void SearchDest()
    {
        float z = Random.Range(-walkrange, walkrange);
        float x = Random.Range(-walkrange, walkrange);
        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        // hoe ver de enemy kan lopen vanaf huidige locatie op z as

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
            // als ie op de plek is kijkt ie of hij op de grond staat en of het een ground layer is
        {
            walkpointSet = true;
        }
    }

    public void TakeDamageM(int damage)
    {
        playerHp.Health -= damage;
    }
}
