using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoatUpgrader : MonoBehaviour
{
    public BigNumber BaseCost = new BigNumber(2.5f, 2);
    public float CostMultiplier = 1.5f;

    public float IncomeMultiplier = 1.0f;
    public float HealthMultiplier = 1.0f;
    public float SpawnRateIncrease = 0;

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
        if(currCost <= GlobalGameData.Coins)
        {
            GlobalGameData.Coins -= currCost;

            currCost *= CostMultiplier;

            GlobalGameData.BoatHealthMultiplier *= HealthMultiplier;
            GlobalGameData.BoatIncomeMultiplier *= IncomeMultiplier;
            GlobalGameData.BoatSpawnrateMultiplier += SpawnRateIncrease;
        }
        else
        {
            // Play Sound?
        }
    }
}
