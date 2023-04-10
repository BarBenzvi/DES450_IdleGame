using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CursorUpgrader : UpgradeButton
{
    public int LinearClickIncrease = 1;

    public TextMeshProUGUI DamageText = null;
    public TextMeshProUGUI IncomeText = null;

    CursorBehavior c = null;

    protected override void Start()
    {
        base.Start();

        c = GameObject.Find("Cursor").GetComponent<CursorBehavior>();
    }

    protected override void UpgradeEffects()
    {
        c.DamagePerClick += LinearClickIncrease;
        c.CoinsPerClick += LinearClickIncrease;
    }

    protected override void UpdateText()
    {
        base.UpdateText();

        if(DamageText)
        {
            DamageText.text = "Damage: " + (c.DamagePerClick * GlobalGameData.ClickDamageMultiplier).ToString();
        }
        if (IncomeText)
        {
            IncomeText.text = "Click Income: " + (c.CoinsPerClick * GlobalGameData.ClickIncomeMultiplier * GlobalGameData.GlobalCurrencyMultiplier).ToString();
        }
    }
}
