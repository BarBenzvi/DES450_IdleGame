using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraUpgrader : UpgradeButton
{
    public int NumIncrease = 0;
    public BigNumber RateIncrease = BigNumber.Zero();

    public FloraData Flora = null;

    protected override void UpgradeEffects()
    {
        if(Flora)
        {
            Flora.NumFlora += NumIncrease;
            Flora.EarnRatePerFlora += RateIncrease;
        }
    }
}
