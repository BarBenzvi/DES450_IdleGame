using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GlobalGameData
{
    // Global variable for the player's current amount of coins
    public static BigNumber Coins = new BigNumber(0, 0);

    // Global variable for the player's current amount of platinum
    public static BigNumber Platinum = new BigNumber(0, 0);

    public static BigNumber BoatIncomeMultiplier = new BigNumber(1, 0);
    public static BigNumber BoatHealthMultiplier = new BigNumber(1, 0);
    public static float     BoatSpawnrateMultiplier = 0.2f;
}
