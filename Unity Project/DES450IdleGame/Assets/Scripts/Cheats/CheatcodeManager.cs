using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatcodeManager : MonoBehaviour
{
    public bool CheatsActive = true;

    // Update is called once per frame
    void Update()
    {
        if(!CheatsActive)
        {
            return;
        }

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if(Input.GetKeyUp(KeyCode.Alpha1))
            {
                GlobalGameData.Coins += new BigNumber(1, 2);
            }
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                GlobalGameData.Coins += new BigNumber(1, 3);
            }
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                GlobalGameData.Coins += new BigNumber(1, 4);
            }
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                GlobalGameData.Coins += new BigNumber(1, 10);
            }

            if(Input.GetKeyUp(KeyCode.D))
            {
                BigNumber.DisplayType d = BigNumber.GetDisplayType();
                if(d == BigNumber.DisplayType.NAMES)
                {
                    BigNumber.SetDisplayType(BigNumber.DisplayType.SCIENTIFIC);
                }
                else
                {
                    BigNumber.SetDisplayType(BigNumber.DisplayType.NAMES);
                }
            }

            if(Input.GetKeyUp(KeyCode.S))
            {
                GlobalGameData.SkillTreePoints += 1;
            }
        }
    }
}
