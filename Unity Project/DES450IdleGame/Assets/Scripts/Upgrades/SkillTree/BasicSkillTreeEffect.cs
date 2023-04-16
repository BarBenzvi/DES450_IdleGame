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
    public bool MonsterAOE = false;
    public bool RareBoats = false;
    public bool InstakillClick = false;
    public bool SpellClick = false;
    public bool MonsterBuff = false;
    public bool FloraDamageBuff = false;


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
            FloraData[] floras = FindObjectsOfType<FloraData>();
            Debug.Log(floras.Length);
            foreach(FloraData flora in floras)
            {
                flora.MyMultiplier *= FloraCostMultiplier;
            }
        }

        if(MonsterCoins)
        {
            GameObject.Find("SeaMonster").GetComponent<MonsterBehavior>().Income = true;
        }

        if(MonsterAOE)
        {
            GameObject m = GameObject.Find("SeaMonster");
            m.GetComponent<MonsterBehavior>().AOEAttack = true;
            m.GetComponent<BoxCollider2D>().size *= 3; // Triple collider size so AOE is more impactful
        }

        if(FloraDamageBuff)
        {
            GameObject.Find("SeaMonster").GetComponent<MonsterBehavior>().FloraBuff = true;
        }

        if(RareBoats)
        {
            GameObject.Find("BoatSpawner").GetComponent<BoatSpawner>().RareBoats = true;
        }

        if(InstakillClick)
        {
            GameObject.Find("Cursor").GetComponent<CursorBehavior>().Instakill = true;
        }

        if (SpellClick)
        {
            GameObject.Find("Cursor").GetComponent<CursorBehavior>().SpellClick = true;
        }

        if(MonsterBuff)
        {
            GameObject.Find("Cursor").GetComponent<CursorBehavior>().MonsterBuff = true;
        }
    }
}
