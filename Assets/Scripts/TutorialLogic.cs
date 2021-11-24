using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLogic : MonoBehaviour
{
    public bool hasWalked;
    public bool hasRan;
    public bool hasJumped;
    public bool wasNearWater;
    public bool hitTree;
    public bool hasOpenedInv;
    public bool hasFought;
    public bool hasEaten;
    public bool hasDrank;

    public Text nextObjective;
    public Text alternativeObjective;

    public Player player;
    //public GameObject water;

    private float prevHunger;
    private float prevThirst;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        //water = FindObjectOfType<Water>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        UpdateThingsDone();
        if(hasWalked && hasRan && hasJumped && wasNearWater && hitTree && hasOpenedInv && hasFought && hasEaten && hasDrank)
        {
            Destroy(this.gameObject);
        }
    }

    void UpdateText()
    {
        if(!hasWalked)
        {
            nextObjective.text = "Use WASD to around!";
        }
        else if(!hasJumped)
        {
            nextObjective.text = "Use Space to jump!";
        }
        else if (!hasRan)
        {
            nextObjective.text = "Use Left Shift to run!";
        }
        //else if(!hitTree) //Need to find a way to detect when a player has hit sth
        //{
        //    nextObjective.text = "Use Left Click to hit trees!";
        //}
        else if(!hasOpenedInv)
        {
            nextObjective.text = "Use <key> to open your inventory!";
        }
        //else if(!hasFought)
        //{
        //    nextObjective.text = "Left Click can also be used to fight enemies!";
        //}
        else
        {
            nextObjective.text = "";
        }
        
        if(player.hunger > 60 && !hasEaten)
        {
            alternativeObjective.text = "You're getting hungry! Better find something to eat.";
        }
        if(player.thirst > 60 && !hasDrank)
        {
            alternativeObjective.text = "You're getting thirsty! You really should find a drink.";
        }
        if(player.transform.position.y <= 97f && !wasNearWater)
        {
            alternativeObjective.text = "Careful! You're near water and it's pretty toxic...";
        }
        if(wasNearWater)
        {
            alternativeObjective.text = "";
        }
    }

    void UpdateThingsDone()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) && !hasWalked)
        {
            hasWalked = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            hasJumped = true;
        }
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && !hasRan)
        {
            hasRan = true;
        }
        if(Input.GetKeyDown(KeyCode.E) && !hasOpenedInv)
        {
            hasOpenedInv = true;
        }

        //Need logic for detecting tree hit, enemy hit, can also be done externally

        
        if(prevHunger > player.hunger && !hasEaten)
        {
            hasEaten = true;
        }
        if(!hasEaten)
        {
            prevHunger = player.hunger;
        }
        if(prevThirst > player.thirst && !hasDrank)
        {
            hasDrank = true;
        }
        if(!hasDrank)
        {
            prevThirst = player.thirst;
        }

        if(player.transform.position.y <= 97f && !wasNearWater)
        {
            Debug.Log("should start");
            StartCoroutine("waitForWater");
        }
        if(wasNearWater)
        {
            StopCoroutine("waitForWater");
        }

    }
    IEnumerator waitForWater()
    {
        yield return new WaitForSeconds(10);
        wasNearWater = true;
        yield return null;
    }
}

