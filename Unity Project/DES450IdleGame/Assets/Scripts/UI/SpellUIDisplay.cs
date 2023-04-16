using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellUIDisplay : MonoBehaviour
{
    public SpellManager SManager = null;
    public int SpellIndex = 0;

    public Image SpellIcon = null;
    public RectTransform CooldownTransform = null;
    public float CooldownMaxY = 100.0f;
    public Image CooldownImage = null;
    public Color ActiveColor = Color.green;
    public Color CooldownColor = Color.gray;
    public float IndicatorAlpha = 0.7f;


    TooltipSpawner ts = null;

    // Start is called before the first frame update
    void Start()
    {
        ActiveColor.a = IndicatorAlpha;
        CooldownColor.a = IndicatorAlpha;
        Vector2 s = CooldownTransform.sizeDelta;
        s.y = 0;
        CooldownTransform.sizeDelta = s;
        SpellIcon.enabled = false;

        ts = GetComponent<TooltipSpawner>();
        if(ts != null)
        {
            ts.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SManager.ActiveSpells.Count > SpellIndex)
        {
            SpellEffect spell = SManager.ActiveSpells[SpellIndex];
            ts.enabled = true;
            ts.DisplayName = spell.GetComponent<TooltipSpawner>().DisplayName;
            ts.DisplayTooltip = spell.GetComponent<TooltipSpawner>().DisplayTooltip;

            SpellIcon.sprite = spell.Icon;
            SpellIcon.enabled = true;

            if (spell.Active && spell.ActiveTime != 0)
            {
                CooldownImage.color = ActiveColor;
                Vector2 s = CooldownTransform.sizeDelta;
                s.y = Mathf.Lerp(0, CooldownMaxY, spell.Timer / spell.ActiveTime);
                CooldownTransform.sizeDelta = s;
            }
            else
            {
                CooldownImage.color = CooldownColor;
                Vector2 s = CooldownTransform.sizeDelta;
                s.y = Mathf.Lerp(0, CooldownMaxY, spell.Timer / spell.Cooldown);
                CooldownTransform.sizeDelta = s;
            }
        }
    }

    public void ActivateMySpell()
    {
        if (SManager.ActiveSpells.Count > SpellIndex)
        {
            SManager.ActiveSpells[SpellIndex].ActivateSpell();
        }
    }
}
