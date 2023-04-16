using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSkillTreeEffect : SkillTreeEffect
{
    public SpellEffect ToUnlock = null;
    public SpellManager SManager = null;

    protected override void ActivateEffects()
    {
        base.ActivateEffects();

        SManager.ActiveSpells.Add(ToUnlock);
    }
}
