using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject globalLight;
    public int health = 100;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (globalLight.transform.rotation.x > 0.96f)
        {
            gameObject.GetComponentInChildren<Light>().enabled = true;
        }
        if (globalLight.transform.rotation.x < 0)
        {
            gameObject.GetComponentInChildren<Light>().enabled = false;
        }
    }
}