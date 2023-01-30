using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    public BigNumber CoinsPerClick = new BigNumber(1, 0);
    public BigNumber DamagePerClick = new BigNumber(1, 0);

    int collidingUIZones = 0;
    Health collidingBoat = null;

    void Update()
    {
        // Mouse follow behavior
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        transform.position = pos;

        if (Input.GetMouseButtonUp(0))
        {
            // If we're colliding with a UI zone, we don't want to be able to interact with the world
            if (collidingUIZones == 0)
            {
                // If clicking on a boat, deal damage. otherwise increase coins
                if (collidingBoat)
                {
                    collidingBoat.ApplyDamage(DamagePerClick);
                }
                else
                {
                    GlobalGameData.Coins += CoinsPerClick;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("UIZone"))
        {
            collidingUIZones += 1;
        }
        else
        {
            Health hp = collision.GetComponent<Health>();
            if (hp != null)
            {
                collidingBoat = hp;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("UIZone"))
        {
            collidingUIZones -= 1;
        }
        else
        {
            Health hp = collision.GetComponent<Health>();
            if (hp == collidingBoat)
            {
                collidingBoat = null;
            }
        }
    }
}
