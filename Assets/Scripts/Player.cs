using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaserate;
    public float health, thirst, hunger;

    public int damage = 25;
    public Camera FPSCamera;
    public float hitRange = 2.5f;

    public float attackTimer = 2f;



    public void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Physics.Raycast(ray, out hitInfo, hitRange))
            {
                if (hitInfo.collider.tag == "Enemy")
                {
                    if (attackTimer <= 0)
                    {
                        attackTimer = 2f;
                        EnemyAI enemy = hitInfo.collider.GetComponentInParent<EnemyAI>();
                        enemy.AttackMob(damage);
                    }
                }

                if (hitInfo.collider.tag == "Animal")
                {
                    if (attackTimer <= 0)
                    {
                        attackTimer = 2f;
                        Animals animal = hitInfo.collider.GetComponentInParent<Animals>();
                        animal.AttackMob(damage);
                    }
                }
            }
        }

        attackTimer -= Time.deltaTime;


        if (thirst < maxThirst)
        {
            thirst += thirstIncreaseRate * Time.deltaTime;
        }

        if(hunger < maxHunger)
        {
            hunger += hungerIncreaserate * Time.deltaTime;
        }


        if (health<=0 ||thirst >= maxThirst || hunger >= maxHunger)
        {
            Die();
        }
    }

    public void Die()
    {
        transform.position = new Vector3(450, 120, 549);
        health = 100;
    }

    public void AttackPlayer(float damage)
    {
        health -= damage;
    }
}
