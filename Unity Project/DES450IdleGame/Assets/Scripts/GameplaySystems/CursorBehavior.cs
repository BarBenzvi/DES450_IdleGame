using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    public BigNumber CoinsPerClick = new BigNumber(1, 0);
    public BigNumber DamagePerClick = new BigNumber(1, 0);
    public bool Instakill = false;
    public bool SpellClick = false;
    public bool MonsterBuff = false;

    int collidingUIZones = 0;
    Health collidingBoat = null;
    MonsterBehavior collidingMonster = null;

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
                    BigNumber damage = DamagePerClick * GlobalGameData.ClickDamageMultiplier;
                    if (Instakill)
                    {
                        if(Random.Range(0, 100) == 99)
                        {
                            // Deal maximum damage to insure instant kill
                            damage = collidingBoat.StartHealth;
                        }
                    }
                    collidingBoat.ApplyDamage(damage);
                }
                else // If clicking on the ocean, gain coins (and check for spell click)
                {
                    GlobalGameData.Coins += CoinsPerClick * GlobalGameData.ClickIncomeMultiplier * GlobalGameData.GlobalCurrencyMultiplier;
                    if(SpellClick)
                    {
                        List<SpellEffect> spells = FindObjectOfType<SpellManager>().ActiveSpells;
                        foreach(SpellEffect spell in spells)
                        {
                            if(!spell.Active)
                            {
                                spell.Timer *= 0.99f;
                            }
                        }
                    }
                }

                if(collidingMonster && MonsterBuff)
                {
                    collidingMonster.ClickDamageBuffActive = true;
                    collidingMonster.clickTimer = 5.0f;
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

            MonsterBehavior mb = collision.GetComponent<MonsterBehavior>();
            if(mb != null)
            {
                collidingMonster = mb;
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

            MonsterBehavior mb = collision.GetComponent<MonsterBehavior>();
            if (mb == collidingMonster)
            {
                collidingMonster = null;
            }
        }
    }
}
