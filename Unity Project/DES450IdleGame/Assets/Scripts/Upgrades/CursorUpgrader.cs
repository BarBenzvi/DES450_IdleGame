using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUpgrader : UpgradeButton
{
    public int LinearClickIncrease = 1;

    protected override void UpgradeEffects()
    {
        CursorBehavior c = GameObject.Find("Cursor").GetComponent<CursorBehavior>();
        c.DamagePerClick += LinearClickIncrease;
        c.CoinsPerClick += LinearClickIncrease;
    }
}
