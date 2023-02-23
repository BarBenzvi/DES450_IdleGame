using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public BigNumber BaseCost = new BigNumber(2.5f, 2);
    public float CostMultiplier = 1.5f;

    public string LevelPreText = "";

    public TextMeshProUGUI CostText = null;
    public TextMeshProUGUI LevelText = null;

    BigNumber currCost;
    
    protected int timesPurchased = 0;

    protected virtual void Start()
    {
        currCost = new BigNumber(BaseCost);
        timesPurchased = 0;
    }

    private void Update()
    {
        UpdateText();
    }

    protected virtual void UpdateText()
    {
        if(CostText)
        {
            CostText.text = currCost.ToString() + " Coins";
        }
        if(LevelText)
        {
            LevelText.text = LevelPreText + (timesPurchased + 1).ToString();
        }
    }

    virtual protected void UpgradeEffects()
    {}

    public void PurchaseUpgrade()
    {
        if (currCost <= GlobalGameData.Coins)
        {
            GlobalGameData.Coins -= currCost;

            currCost *= CostMultiplier;
            timesPurchased += 1;

            UpgradeEffects();
        }
        else
        {
            // Play Sound?
        }
    }
}
