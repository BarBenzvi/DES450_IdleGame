using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public BigNumber BaseCost = new BigNumber(2.5f, 2);
    public float CostMultiplier = 1.5f;

    public TextMeshProUGUI CostText = null;

    BigNumber currCost;

    private void Start()
    {
        currCost = new BigNumber(BaseCost);
    }

    private void Update()
    {
        CostText.text = currCost.ToString();
    }

    virtual protected void UpgradeEffects()
    {}

    public void PurchaseUpgrade()
    {
        if (currCost <= GlobalGameData.Coins)
        {
            GlobalGameData.Coins -= currCost;

            currCost *= CostMultiplier;

            UpgradeEffects();
        }
        else
        {
            // Play Sound?
        }
    }
}
