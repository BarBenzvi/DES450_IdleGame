using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only kill boats (for now)
        BoatBehavior bh = collision.GetComponent<BoatBehavior>();
        if (bh)
        {
            // Fully destroy immediately so that it doesn't generate coins
            bh.FullyDestroyBoat();
        }
    }
}
