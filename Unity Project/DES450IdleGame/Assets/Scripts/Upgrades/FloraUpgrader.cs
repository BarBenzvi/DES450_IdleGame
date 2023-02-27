using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraUpgrader : UpgradeButton
{
    public int NumIncrease = 0;
    public BigNumber RateIncrease = BigNumber.Zero();

    public FloraData Flora = null;
    public GameObject ToSpawn = null;

    protected override void UpgradeEffects()
    {
        if(Flora)
        {
            Flora.NumFlora += NumIncrease;
            Flora.EarnRatePerFlora += RateIncrease;

            if(ToSpawn)
            {
                float randX = Random.Range(-6.5f, 6.5f);
                float randY = Random.Range(-4.0f, 4.0f);

                Instantiate(ToSpawn, new Vector3(randX, randY, 0.0f), Quaternion.identity);
            }
        }
    }
}
