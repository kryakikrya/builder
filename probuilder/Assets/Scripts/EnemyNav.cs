using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class EnemyAi : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    static Transform player;
    [SerializeField] LayerMask GroundMask, PlayerMask;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePosition;


    // Patrool
    [SerializeField] Vector3 walkPoint;
    [SerializeField] bool walkPointSet;
    [SerializeField] float walkPointRange;

    //Attack
    [SerializeField] float attackCd;
    bool canAttack = true;

    //States
    public float sightRange, attackRange;
    private float originalAttackRange;
    public bool playerInSightRange, playerInAttackRange;

    private float curSightRange;

    private void Awake()
    {
        if (player == null)
        {
            player = FindAnyObjectByType<FirstPersonController>().GetComponent<Transform>();
            agent = GetComponent<NavMeshAgent>();
        }
        originalAttackRange = attackRange;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, PlayerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, PlayerMask);
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        else if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        else if (playerInSightRange && playerInAttackRange) Attack();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) agent.SetDestination(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, GroundMask))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
        attackRange = originalAttackRange;
    }

    private void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (canAttack == true)
        {
            canAttack = false;
            Instantiate(bullet, firePosition.position, transform.rotation);
            StartCoroutine(CD());
        }
    }
    IEnumerator CD()
    {
        yield return new WaitForSeconds(attackCd);
        canAttack = true;
        attackRange = originalAttackRange + 1f;
    }
}
