using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpellEffect : SpellEffect
{
    public float GlobalIncomeMulitplier = 1.0f;
    public float BoatSpawnrateMultiplier = 1.0f;
    public float FloraMultiplier = 1.0f;

    public override void ActivateEffects()
    {
        base.ActivateEffects();

        GlobalGameData.GlobalCurrencyMultiplier *= GlobalIncomeMulitplier;
        GlobalGameData.BoatSpawnrateMultiplier *= BoatSpawnrateMultiplier;
        GlobalGameData.FloraMultiplier *= FloraMultiplier;
    }

    public override void DeactivateEffects()
    {
        base.DeactivateEffects();

        GlobalGameData.GlobalCurrencyMultiplier /= GlobalIncomeMulitplier;
        GlobalGameData.BoatSpawnrateMultiplier /= BoatSpawnrateMultiplier;
        GlobalGameData.FloraMultiplier /= FloraMultiplier;
    }
}
