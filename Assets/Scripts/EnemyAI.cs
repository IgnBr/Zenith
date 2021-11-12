using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private NavMeshAgent agent;

    private bool chasing = false;


    public int health = 100;

    public Transform player;

    public float viewRange = 20f;

    // Wandering

    public float decideTimer = 3f;
    public float decideTimerMin = 3f;
    public float decideTimerMax = 15f;
    public float decideTimerStart;
    public float randomUnityCircleRadius = 10f;

    // Attacking
    public float attackTimer = 2f;
    public float attackTimerStart = 2f;

    public float distanceToPlayer;
    public Transform playerTransformDistance;

    public float distanceToAttack = 2f;
    public bool isAttacking = false;

    public Ray viewRay;
    public RaycastHit viewRayHit;

    private Player playerScript;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        decideTimer = Random.Range(decideTimerMin, decideTimerMax);

        // Attcking
        attackTimer = attackTimerStart;
        playerTransformDistance = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        // Attacking
        distanceToPlayer = Vector3.Distance(transform.position, playerTransformDistance.position);

        if (distanceToPlayer <= distanceToAttack)
        {
            isAttacking = true;
        }

        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;
            chasing = false;
            agent.SetDestination(transform.position);
        }

        if(attackTimer <= 0)
        {
            AttackPlayer();
            attackTimer = attackTimerStart;
        }

        viewRay = new Ray(Vector3.forward, transform.forward);

        decideTimer -= Time.deltaTime;

        if (decideTimer <= 0 && !chasing)
        {
            Vector3 newPosition = transform.position + new Vector3(Random.insideUnitCircle.x * randomUnityCircleRadius, 0, Random.insideUnitCircle.y * randomUnityCircleRadius);
            agent.SetDestination(newPosition);

            decideTimer = Random.Range(decideTimerMin, decideTimerMax);
        }

        if (Physics.Raycast(viewRay, out viewRayHit, viewRange))
        {
            if (viewRayHit.collider.tag == "Player")
            {
                if (!chasing)
                {
                    chasing = true;
                    if (player == null)
                    {
                        player = viewRayHit.collider.GetComponent<Transform>();
                    }
                }
            }
        }

        if (chasing)
        {
            agent.SetDestination(player.transform.position);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AttackPlayer()
    {
        playerScript.AttackPlayer(20);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            chasing = true;
            player = other.GetComponent<Transform>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        chasing = false;
        isAttacking = false;
    }
}
