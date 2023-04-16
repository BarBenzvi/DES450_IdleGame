using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffect : MonoBehaviour
{
    // Cooldown in seconds
    public float Cooldown = 30.0f;
    // Amount of time the effect is active in seconds
    public float ActiveTime = 0.0f;
    // Just used for display purposes
    public Sprite Icon;

    [HideInInspector]
    public bool Active = false;
    [HideInInspector]
    public float Timer = 0.0f;

    public void ActivateSpell()
    {
        if(Active == false && Timer <= 0.0f)
        {
            Active = true;
            Timer = ActiveTime;
            ActivateEffects();
        }
    }

    public virtual void ActivateEffects()
    {

    }

    public virtual void DeactivateEffects()
    {

    }
}
