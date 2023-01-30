using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : MonoBehaviour
{
    // Min/Max coins the boat will give when destroyed
    public BigNumber MinCoins = new BigNumber(2, 0);
    public BigNumber MaxCoins = new BigNumber(5, 0);

    public float Movespeed = 5.0f;
    public float Turnspeed = 5.0f;

    // Amount of time the boat spends at its target point before moving to the next point or exiting the map
    public Vector2 TimeAtPointRange = new Vector2(4.0f, 6.0f);

    // X/Y ranges for where the boat will go
    public Vector2 PointXRange = new Vector2(-5.0f, 5.0f);
    public Vector2 PointYRange = new Vector2(-3.0f, 3.0f);

    // Range of number of points to go to before exiting the map
    public Vector2Int NumPointsRange = new Vector2Int(1, 3);


    Rigidbody2D rb2d = null;

    Vector2 dir = Vector2.zero;
    Vector2 exitDir = Vector2.zero;
    Vector2 targetPoint = Vector2.zero;
    float timer = 0.0f;
    int points = 0;

    void Start()
    {
        points = Random.Range(NumPointsRange.x, NumPointsRange.y + 1);
        targetPoint = new Vector2(Random.Range(PointXRange.x, PointXRange.y), Random.Range(PointYRange.x, PointYRange.y));
        timer = Random.Range(TimeAtPointRange.x, TimeAtPointRange.y);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Exiting the map
        if (timer <= 0.0f)
        {
            dir = Vector2.Lerp(dir, exitDir, Turnspeed * Time.deltaTime);
            rb2d.velocity = dir.normalized * Movespeed;
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            rb2d.velocity = dir * Movespeed;
        }
        // Close enough to our target point
        else if (Vector2.Distance(transform.position, targetPoint) < 0.2f)
        {
            timer -= Time.deltaTime;
            rb2d.velocity = Vector2.zero;
            if (timer <= 0.0f)
            {
                points -= 1;
                // Either move to new point or start exiting the map in a random direction
                if(points <= 0)
                {
                    float randAngle = Random.Range(0.0f, 2 * Mathf.PI);
                    exitDir = new Vector2(Mathf.Cos(randAngle), Mathf.Sin(randAngle));
                }
                else
                {
                    targetPoint = new Vector2(Random.Range(PointXRange.x, PointXRange.y), Random.Range(PointYRange.x, PointYRange.y));
                    timer = Random.Range(TimeAtPointRange.x, TimeAtPointRange.y);
                }
            }
        }
        // Currently moving towards a point
        else
        {
            Vector2 pointDir = new Vector3(targetPoint.x, targetPoint.y) - transform.position;
            dir = Vector2.Lerp(dir, pointDir.normalized, Turnspeed * Time.deltaTime);
            rb2d.velocity = dir.normalized * Movespeed;
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        }
    }

    void ReachedZeroHealth()
    {
        GlobalGameData.Coins += BigNumber.RandomRange(MinCoins, MaxCoins);

        FullyDestroyBoat();
    }

    public void FullyDestroyBoat()
    {
        Destroy(GetComponent<Health>().GetHealthbar());
        Destroy(gameObject);
    }

}
