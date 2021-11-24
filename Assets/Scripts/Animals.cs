using UnityEngine;
using UnityEngine.AI;

public class Animals : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject player;
    public float EnemyDistanceRun = 6f;
    public int health = 100;

    public float decideTimer = 3f;
    public float decideTimerMin = 3f;
    public float decideTimerMax = 15f;
    public float randomUnityCircleRadius = 10f;

    public GameObject bread;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        decideTimer -= Time.deltaTime;

        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            _agent.SetDestination(newPos);
        }

        else if (decideTimer <= 0)
        {
            Vector3 newPosition = transform.position + new Vector3(Random.insideUnitCircle.x * randomUnityCircleRadius, 0, Random.insideUnitCircle.y * randomUnityCircleRadius);
            _agent.SetDestination(newPosition);

            decideTimer = Random.Range(decideTimerMin, decideTimerMax);
        }

        if (health <= 0)
        {
            Vector3 newpos = transform.position;
            newpos.y += 3;
            Instantiate(bread, newpos, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void AttackMob(int damage)
    {
        health -= damage;
    }
}
