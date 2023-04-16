using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public List<SpellEffect> SpellList = new List<SpellEffect>();
    public List<SpellEffect> ActiveSpells = new List<SpellEffect>();

    // Update is called once per frame
    void Update()
    {
        foreach(SpellEffect spell in ActiveSpells)
        {
            // reduce cooldown or active time
            if(spell.Active)
            {
                spell.Timer -= Time.deltaTime;
                if(spell.Timer <= 0.0f)
                {
                    spell.Active = false;
                    spell.DeactivateEffects();
                    spell.Timer = spell.Cooldown;
                }
            }
            else if(spell.Timer > 0.0f)
            {
                spell.Timer = Mathf.Max(spell.Timer - Time.deltaTime, 0);
            }
        }
    }
}
