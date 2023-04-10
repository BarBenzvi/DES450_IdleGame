using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloraData : MonoBehaviour
{
    public int NumFlora = 0;
    public BigNumber EarnRatePerFlora = new BigNumber(1, 0);

    public float TimeBetweenIncome = 0.5f;

    public TextMeshProUGUI NumText = null;
    public TextMeshProUGUI IncomeText = null;

    float incomeTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        incomeTimer = TimeBetweenIncome;
    }

    // Update is called once per frame
    void Update()
    {
        incomeTimer -= Time.deltaTime;

        if(incomeTimer <= 0.0f)
        {
            GlobalGameData.Coins += EarnRatePerFlora * NumFlora * TimeBetweenIncome;

            incomeTimer = TimeBetweenIncome;
        }

        UpdateText();
    }

    void UpdateText()
    {
        if(NumText)
        {
            NumText.text = "Amount Owned: " + NumFlora.ToString();
        }
        if(IncomeText)
        {
            IncomeText.text = "Passive Income: " + (EarnRatePerFlora  * GlobalGameData.GlobalCurrencyMultiplier * GlobalGameData.FloraMultiplier * NumFlora).ToString();
        }
    }
}
