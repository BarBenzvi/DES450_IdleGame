using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoatUpgrader : UpgradeButton
{
    public float IncomeMultiplier = 1.0f;
    public float HealthMultiplier = 1.0f;
    public float SpawnRateIncrease = 0;

    public TextMeshProUGUI IncomeText = null;
    public TextMeshProUGUI HealthText = null;
    public TextMeshProUGUI SpawnrateText = null;

    // Only used for referencing base health and base income
    public GameObject BoatPrefab = null;

    BoatSpawner bs = null;

    protected override void Start()
    {
        base.Start();

        bs = GameObject.Find("BoatSpawner").GetComponent<BoatSpawner>();
    }

    protected override void UpgradeEffects()
    {
        GlobalGameData.BoatHealthMultiplier *= HealthMultiplier;
        GlobalGameData.BoatIncomeMultiplier *= IncomeMultiplier;
        GlobalGameData.BoatSpawnrateMultiplier += SpawnRateIncrease;
    }

    protected override void UpdateText()
    {
        base.UpdateText();
        
        if(BoatPrefab)
        {
            BoatBehavior bb = BoatPrefab.GetComponent<BoatBehavior>();

            if (IncomeText)
            {
                BigNumber medianIncome = (bb.MinCoins + bb.MaxCoins) * GlobalGameData.BoatIncomeMultiplier / 2.0f;
                IncomeText.text = "Income: " + medianIncome.ToString();
            }
            if(HealthText)
            {
                HealthText.text = "Health: " + bb.GetComponent<Health>().StartHealth * GlobalGameData.BoatHealthMultiplier;
            }
        }

        if(bs)
        {
            if(SpawnrateText)
            {
                float rate = ((bs.SpawnTimeRange.x + bs.SpawnTimeRange.y) / GlobalGameData.BoatSpawnrateMultiplier) / 2.0f;
                SpawnrateText.text = string.Format("{0:F1} Per Second", 1.0f / rate);
            }
        }
        
    }
}
