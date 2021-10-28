using UnityEngine;
using UnityEngine.AI;

public class Animals : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject player;
    public float EnemyDistanceRun = 6f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            _agent.SetDestination(newPos);
        }
    }
}
