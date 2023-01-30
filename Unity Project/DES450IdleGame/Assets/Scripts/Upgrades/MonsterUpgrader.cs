using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterUpgrader : MonoBehaviour
{
    public BigNumber BaseCost = new BigNumber(2.5f, 2);
    public float CostMultiplier = 1.5f;

    public float DamageMultiplier = 1.0f;
    public float AttackSpeedMultiplier = 1.0f;

    public TextMeshProUGUI CostText = null;

    BigNumber currCost;

    void Start()
    {
        currCost = new BigNumber(BaseCost);
    }

    void Update()
    {
        CostText.text = currCost.ToString();
        //Gray out button?
    }

    public void PurchaseUpgrade()
    {
        if (currCost <= GlobalGameData.Coins)
        {
            GlobalGameData.Coins -= currCost;

            currCost *= CostMultiplier;

            MonsterBehavior m = GameObject.Find("SeaMonster").GetComponent<MonsterBehavior>();
            m.BaseDamage *= DamageMultiplier;
            m.AttackCooldown *= AttackSpeedMultiplier;
        }
        else
        {
            // Play Sound?
        }
    }
}
