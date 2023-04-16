using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoughSeasSpellEffect : SpellEffect
{
    public override void ActivateEffects()
    {
        base.ActivateEffects();

        Health[] boats = FindObjectsOfType<Health>();
        foreach(Health boat in boats)
        {
            boat.ApplyDamage(boat.StartHealth);
        }
    }
}
