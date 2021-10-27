using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTree : MonoBehaviour
{
    public int damage = 25;

    public Camera FPSCamera;

    public float hitRange = 2.5f;

    private Tree Tree;

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
            }
        }


    }

    void DamageTree()
    {
        Tree.health -= damage;
    }
}