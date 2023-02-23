using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterUpgrader : UpgradeButton
{
    public float DamageMultiplier = 1.0f;
    public float AttackSpeedMultiplier = 1.0f;

    public TextMeshProUGUI DamageText = null;
    public TextMeshProUGUI AttackSpeedText = null;

    MonsterBehavior m = null;

    protected override void Start()
    {
        base.Start();

        m = GameObject.Find("SeaMonster").GetComponent<MonsterBehavior>();
    }

    protected override void UpgradeEffects()
    {
        m.BaseDamage *= DamageMultiplier;
        m.AttackCooldown *= AttackSpeedMultiplier;
    }

    protected override void UpdateText()
    {
        base.UpdateText();

        if(DamageText)
        {
            DamageText.text = "Damage: " + m.BaseDamage.ToString();
        }
        if(AttackSpeedText)
        {
            AttackSpeedText.text = "Attack Speed: " + string.Format("{0:F1}", 1.0f / m.AttackCooldown) + "/s";
        }
    }
}
