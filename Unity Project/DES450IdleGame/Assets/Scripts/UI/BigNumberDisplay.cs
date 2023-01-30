using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BigNumberDisplay : MonoBehaviour
{
    public BigNumber ToDisplay = new BigNumber();
    public string PreText = "";
    public string PostText = "";
    public bool ShowGlobalCoins = false;

    TextMeshProUGUI text = null;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text)
        {
            if (ShowGlobalCoins)
            {
                text.text = PreText + GlobalGameData.Coins.ToString() + PostText;
            }
            else
            {
                text.text = PreText + ToDisplay.ToString() + PostText;
            }
        }
    }
}
