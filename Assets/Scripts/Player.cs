using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth, maxThirst, maxHunger;
    public float thirstIncreaseRate, hungerIncreaserate;
    public float health, thirst, hunger;




    public void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {
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
    }

    public void AttackPlayer(float damage)
    {
        health -= damage;
    }
}
