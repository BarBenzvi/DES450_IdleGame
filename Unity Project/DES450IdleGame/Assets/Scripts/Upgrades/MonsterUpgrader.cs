using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUpgrader : UpgradeButton
{
    public float DamageMultiplier = 1.0f;
    public float AttackSpeedMultiplier = 1.0f;

    protected override void UpgradeEffects()
    {
        MonsterBehavior m = GameObject.Find("SeaMonster").GetComponent<MonsterBehavior>();
        m.BaseDamage *= DamageMultiplier;
        m.AttackCooldown *= AttackSpeedMultiplier;
    }
}
