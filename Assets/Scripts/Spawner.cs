using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Tree treeScript;
    public GameObject golem;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        treeScript = FindObjectOfType<Tree>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!treeScript.lightOfTree)
        {
            spawned = false;
        }

        if (treeScript.lightOfTree && !spawned)
        {
            spawned = true;
            Vector3 vector = treeScript.transform.position;
            vector.x += 20;
            vector.z += 20;
            vector.y += 20;
            Instantiate(golem, vector, Quaternion.identity);
        }
    }
}
