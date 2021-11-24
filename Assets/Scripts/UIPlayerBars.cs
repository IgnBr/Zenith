using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerBars : MonoBehaviour
{
    public GameObject healthBarInner;
    public GameObject hungerBarInner;
    public GameObject thirstBarInner;
    public Player player;

    private float percentageHealth;
    private float percentageHunger;
    private float percentageThirst;

    private float healthBarInnerMaxWidth;
    private float hungerBarInnerMaxWidth;
    private float thirstBarInnerMaxWidth;

    private RectTransform healthRect;
    private RectTransform hungerRect;
    private RectTransform thirstRect;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        healthRect = healthBarInner.GetComponent<RectTransform>();
        hungerRect = hungerBarInner.GetComponent<RectTransform>();
        thirstRect = thirstBarInner.GetComponent<RectTransform>();

        healthBarInnerMaxWidth = healthRect.rect.width;
        hungerBarInnerMaxWidth = hungerRect.rect.width;
        thirstBarInnerMaxWidth = thirstRect.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        percentageHealth = player.health / player.maxHealth;
        percentageHunger = 1 - player.hunger / player.maxHunger;
        percentageThirst = 1 - player.thirst / player.maxThirst;

        healthRect.sizeDelta = new Vector2(healthBarInnerMaxWidth * percentageHealth, healthRect.rect.height);
        hungerRect.sizeDelta = new Vector2(hungerBarInnerMaxWidth * percentageHunger, hungerRect.rect.height);
        thirstRect.sizeDelta = new Vector2(thirstBarInnerMaxWidth * percentageThirst, thirstRect.rect.height);
    }
}
