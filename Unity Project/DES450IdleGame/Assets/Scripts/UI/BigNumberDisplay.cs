using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BigNumberDisplay : MonoBehaviour
{
    public BigNumber ToDisplay = new BigNumber();
    // Text that will display before the number
    public string PreText = "";

    // Text that will display after the number
    public string PostText = "";

    // If this is true, this component will display GlobalGameData.Coins
    public bool ShowGlobalCoins = false;

    // If this is true, this component will display GlobalGameData.Platinum
    public bool ShowGlobalPlatinum = false;

    TextMeshProUGUI text = null;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (text)
        {
            if (ShowGlobalCoins)
            {
                text.text = PreText + GlobalGameData.Coins.ToString() + PostText;
            }
            else if(ShowGlobalPlatinum)
            {
                text.text = PreText + GlobalGameData.Platinum.ToString() + PostText;
            }
            else
            {
                text.text = PreText + ToDisplay.ToString() + PostText;
            }
        }
    }
}
