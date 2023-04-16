using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoppelgangerSpellEffect : SpellEffect
{
    public Color DoppelTint = Color.red;
    GameObject doppelMonster = null;

    public override void ActivateEffects()
    {
        base.ActivateEffects();

        doppelMonster = Instantiate(GameObject.Find("SeaMonster"));
        Vector3 p = doppelMonster.transform.position;
        p.x = -p.x;
        doppelMonster.transform.position = p;
        doppelMonster.transform.Find("SerpentSprite").GetComponent<SpriteRenderer>().color = DoppelTint;
    }

    public override void DeactivateEffects()
    {
        base.DeactivateEffects();

        Destroy(doppelMonster);
        doppelMonster = null;
    }
}
