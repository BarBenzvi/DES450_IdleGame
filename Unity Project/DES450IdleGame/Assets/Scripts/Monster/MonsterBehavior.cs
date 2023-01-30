using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    public Vector2 WorldExtents = new Vector2(9.0f, 5.5f);

    public float Movespeed = 5.0f;
    public float Turnspeed = 5.0f;

    public float RoamSpeedMultiplier = 0.4f;
    public float SpeedMultiplierLerp = 2.0f;

    public BigNumber BaseDamage = new BigNumber(5, 0);
    public float AttackCooldown = 0.25f;

    Rigidbody2D rb2d = null;
    GameObject currBoat = null;
    float currSpeedMultiplier = 1.0f;
    Vector2 roamPoint = Vector2.zero;
    Vector2 dir = Vector2.zero;
    bool colliding = false;
    float timer = 0.0f;

    void Start()
    {
        roamPoint.x = Random.Range(-WorldExtents.x, WorldExtents.x);
        roamPoint.y = Random.Range(-WorldExtents.y, WorldExtents.y);

        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(currBoat == null)
        {
            GetTargetBoat();
            colliding = false;
        }

        if(currBoat == null)
        {
            Roam();
        }
        else
        {
            AttackTargetBoat();
        }

        rb2d.velocity = dir * Movespeed * currSpeedMultiplier;
    }

    void GetTargetBoat()
    {
        GameObject[] boats = GameObject.FindGameObjectsWithTag("Boat");

        GameObject closest = null;
        float closestDist = 0;

        foreach(GameObject boat in boats)
        {
            if(Mathf.Abs(boat.transform.position.x) > WorldExtents.x || Mathf.Abs(boat.transform.position.y) > WorldExtents.y)
            {
                continue;
            }

            if (closest == null)
            {
                closest = boat;
                closestDist = Vector2.Distance(boat.transform.position, transform.position);
            }
            else
            {
                float dist = Vector2.Distance(boat.transform.position, transform.position);
                if(dist < closestDist)
                {
                    closest = boat;
                    closestDist = dist;
                }
            }
        }

        currBoat = closest;
    }

    void AttackTargetBoat()
    {
        if (Mathf.Abs(currBoat.transform.position.x) > WorldExtents.x || Mathf.Abs(currBoat.transform.position.y) > WorldExtents.y)
        {
            currBoat = null;
            return;
        }

        currSpeedMultiplier = Mathf.Lerp(currSpeedMultiplier, 1.0f, SpeedMultiplierLerp * Time.deltaTime);

        Vector2 boatDir = currBoat.transform.position - transform.position;
        dir = Vector2.Lerp(dir, boatDir.normalized, Turnspeed * currSpeedMultiplier * Time.deltaTime);

        timer -= Time.deltaTime;

        if(colliding && timer <= 0.0f)
        {
            currBoat.GetComponent<Health>().ApplyDamage(BaseDamage);

            timer = AttackCooldown;
        }
    }

    void Roam()
    {
        currSpeedMultiplier = Mathf.Lerp(currSpeedMultiplier, RoamSpeedMultiplier, SpeedMultiplierLerp * Time.deltaTime);

        if(Vector2.Distance(transform.position, roamPoint) < 0.2f)
        {
            roamPoint.x = Random.Range(-WorldExtents.x, WorldExtents.x);
            roamPoint.y = Random.Range(-WorldExtents.y, WorldExtents.y);
        }

        Vector2 pointDir = new Vector3(roamPoint.x, roamPoint.y) - transform.position;
        dir = Vector2.Lerp(dir, pointDir.normalized, Turnspeed * currSpeedMultiplier * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == currBoat)
        {
            colliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currBoat)
        {
            colliding = false;
        }
    }
}
