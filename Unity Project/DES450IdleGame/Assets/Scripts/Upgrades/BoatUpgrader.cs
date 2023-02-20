using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatUpgrader : UpgradeButton
{
    public float IncomeMultiplier = 1.0f;
    public float HealthMultiplier = 1.0f;
    public float SpawnRateIncrease = 0;

    protected override void UpgradeEffects()
    {
        GlobalGameData.BoatHealthMultiplier *= HealthMultiplier;
        GlobalGameData.BoatIncomeMultiplier *= IncomeMultiplier;
        GlobalGameData.BoatSpawnrateMultiplier += SpawnRateIncrease;
    }
}
