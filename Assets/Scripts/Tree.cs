using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public int health = 100;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
