using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkillTreeEffect : SkillTreeEffect
{
    public float GlobalCurrencyMultiplier = 1.0f;
    public float BoatIncomeMultiplier = 1.0f;
    public float ClickDamageMultiplier = 1.0f;
    public float ClickIncomeMultiplier = 1.0f;
    public float FloraMultiplier = 1.0f;
    public float MonsterDamageMultiplier = 1.0f;
    public float FloraCostMultiplier = 1.0f;
    public bool MonsterCoins = false;
    public bool RareBoats = false;


    protected override void ActivateEffects()
    {
        base.ActivateEffects();
        GlobalGameData.GlobalCurrencyMultiplier *= GlobalCurrencyMultiplier;
        GlobalGameData.BoatIncomeMultiplier *= BoatIncomeMultiplier;
        GlobalGameData.ClickDamageMultiplier *= ClickDamageMultiplier;
        GlobalGameData.ClickIncomeMultiplier *= ClickIncomeMultiplier;
        GlobalGameData.FloraMultiplier *= FloraMultiplier;
        GlobalGameData.MonsterDamageMultiplier *= MonsterDamageMultiplier;

        if (FloraCostMultiplier != 1.0f)
        {
            FloraUpgrader[] floras = FindObjectsOfType<FloraUpgrader>();
            foreach(FloraUpgrader flora in floras)
            {
                if(flora.NumIncrease != 0)
                {
                    flora.ChangeMultiplier(FloraCostMultiplier);
                    flora.FullyRecalculateCost();
                }
            }
        }

        if(MonsterCoins)
        {
            GameObject.Find("SeaMonster").GetComponent<MonsterBehavior>().Income = true;
        }

        if(RareBoats)
        {
            GameObject.Find("BoatSpawner").GetComponent<BoatSpawner>().RareBoats = true;
        }
    }
}
