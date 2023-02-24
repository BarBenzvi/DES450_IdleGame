using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraUnlocker : MonoBehaviour
{
    public enum FloraTypes { SEAGRASS, CORAL, KELP }

    public BigNumber PlatinumCost = new BigNumber(1, 0);
    public int MinimumMonsterLevel = 1;

    public MainUIManager UIManager = null;
    public FloraTypes ToUnlock = FloraTypes.SEAGRASS;

    public void TryPurchase()
    {
        MonsterBehavior m = GameObject.Find("SeaMonster").GetComponent<MonsterBehavior>();
        if(m.Level >= MinimumMonsterLevel && GlobalGameData.Platinum >= PlatinumCost)
        {
            GlobalGameData.Platinum -= PlatinumCost;

            switch (ToUnlock)
            {
                case FloraTypes.SEAGRASS:
                    UIManager.SeagrassLock = false;
                    break;
                case FloraTypes.CORAL:
                    UIManager.CoralLock = false;
                    break;
                case FloraTypes.KELP:
                    UIManager.KelpLock = false;
                    break;
            }
        }
    }
}
