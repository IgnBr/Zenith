using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Tree treeScript;
    // Start is called before the first frame update
    void Start()
    {
        treeScript = GetComponent<Tree>();
    }

    // Update is called once per frame
    void Update()
    {
        if (treeScript.lightOfTree)
        {
        }
    }
}
