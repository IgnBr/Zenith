using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject golem;
    private bool spawned = false;
    private Tree[] treeList;
    private List<GameObject> golems;

    private System.Random rand;

    // Start is called before the first frame update
    void Start()
    {
        golems = new List<GameObject>();
        treeList = FindObjectsOfType<Tree>();
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned && treeList[0].lightOfTree)
        {
            foreach (var tree in treeList)
            {
                if (rand.Next(1, 11) == 1)
                {
                    Vector3 randomPosition = tree.transform.position;
                    randomPosition.x += rand.Next(-16, 16);
                    randomPosition.z += rand.Next(-16, 16);
                    //vector.y += 20;

                    NavMeshHit hit;
                    NavMesh.SamplePosition(randomPosition, out hit, 10, 1);

                    golems.Add(Instantiate(golem, hit.position, Quaternion.identity));
                }
            }

            spawned = true;
        }

        if (!treeList[0].lightOfTree)
        {
            //GameObject tempGolem;
            foreach(var g in golems)
            {
                Destroy(g);
            }
            golems = new List<GameObject>();
            spawned = false;
        }
    }
}
