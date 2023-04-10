using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloraUnlocker : MonoBehaviour
{
    public enum FloraTypes { SEAGRASS, CORAL, KELP }

    public BigNumber PlatinumCost = new BigNumber(1, 0);
    public int MinimumMonsterLevel = 1;

    public MainUIManager UIManager = null;
    public FloraTypes ToUnlock = FloraTypes.SEAGRASS;

    public Button ConnectedButton = null;

    MonsterBehavior m = null;

    private void Start()
    {
        m = GameObject.Find("SeaMonster").GetComponent<MonsterBehavior>();
    }

    private void Update()
    {
        if(ConnectedButton)
        {
            ConnectedButton.interactable = CanAfford();
        }
    }

    private bool CanAfford()
    {
        if(GlobalGameData.Platinum < PlatinumCost)
        {
            return false;
        }
        if(m.Level < MinimumMonsterLevel)
        {
            return false;
        }

        return true;
    }

    public void TryPurchase()
    {
        if(m.Level >= MinimumMonsterLevel && GlobalGameData.Platinum >= PlatinumCost)
        {
            GlobalGameData.Platinum -= PlatinumCost;

            switch (ToUnlock)
            {
                case FloraTypes.SEAGRASS:
                    UIManager.UnlockSeagrass();
                    break;
                case FloraTypes.CORAL:
                    UIManager.UnlockCoral();
                    break;
                case FloraTypes.KELP:
                    UIManager.UnlockKelp();
                    break;
            }
        }
    }
}
