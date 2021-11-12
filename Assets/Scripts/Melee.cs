using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public int damage = 25;

    public Camera FPSCamera;

    public float hitRange = 2.5f;

    private Tree Tree;

    private EnemyAI enemyAI;

    void Update()
    {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hitInfo, hitRange))
            {
                if (hitInfo.collider.tag == "tree")
                {
                    Tree = hitInfo.collider.GetComponentInParent<Tree>();
                    DamageTree();
                }

                if (hitInfo.collider.tag == "Enemy")
                {
                    enemyAI = hitInfo.collider.GetComponent<EnemyAI>();
                    DamageEnemy(25);
                }
            }
        }


    }

    void DamageTree()
    {
        Tree.health -= damage;
    }

    public void DamageEnemy(int damage)
    {
        enemyAI.health -= damage;
    }
}