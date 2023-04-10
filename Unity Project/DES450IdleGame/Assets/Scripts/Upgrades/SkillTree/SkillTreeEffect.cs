using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeEffect : MonoBehaviour
{
    public List<Image> Connectors = new List<Image>();
    public Color ConnectorEnabledColor = Color.white;
    public Button MyButton = null;
    public Color PurchasedColor = Color.white;

    public List<SkillTreeEffect> Prereqs = new List<SkillTreeEffect>();

    public bool Purchased = false;

    // Update is called once per frame
    void Update()
    {
        if (Purchased)
        {
            ColorBlock cb = MyButton.colors;
            cb.disabledColor = PurchasedColor;
            MyButton.colors = cb;
            MyButton.interactable = false;

            foreach(Image connector in Connectors)
            {
                connector.color = ConnectorEnabledColor;
            }
        }
        else
        {
            MyButton.interactable = PrereqsMet();
        }
    }

    bool PrereqsMet()
    {
        if(GlobalGameData.SkillTreePoints < 1)
        {
            return false;
        }

        foreach(SkillTreeEffect ste in Prereqs)
        {
            if(!ste.Purchased)
            {
                return false;
            }
        }

        return true;
    }

    protected virtual void ActivateEffects()
    {
    }

    public void TryPurchase()
    {
        if(MyButton.interactable)
        {
            GlobalGameData.SkillTreePoints -= 1;
            ActivateEffects();
            Purchased = true;
        }
    }
}
