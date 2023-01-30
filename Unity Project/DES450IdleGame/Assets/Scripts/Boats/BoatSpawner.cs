using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    public Vector2 SpawnTimeRange = new Vector2(4.0f, 6.0f);
    public Vector2Int SpawnCountRange = new Vector2Int(1, 3);
    public GameObject BoatPrefab = null;
    public Vector2 XYExtents = new Vector2(10.5f, 6.5f);

    float timer = 0.0f;
    void Start()
    {
        timer = 1.0f;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // Spawn boats
        if (timer <= 0.0f)
        {
            int count = Random.Range(SpawnCountRange.x, SpawnCountRange.y + 1);
            int lastSide = 4;

            for (int i = 0; i < count; ++i)
            {
                int side = Random.Range(0, 4);
                // Make sure this boat isn't being spawned on the same side as the previous boat
                while (side == lastSide)
                {
                    side = Random.Range(0, 4);
                }

                // Based on the side (edge of screen), generate a position
                /*
                / side values:
                / - 0 = left
                / - 1 = right
                / - 2 = bottom
                / - 3 = top
                */
                float x = side < 2 ? XYExtents.x * ((side * 2) - 1) : Random.Range(-9.0f, 9.0f);
                float y = side > 1 ? XYExtents.y * (((side - 2) * 2) - 1) : Random.Range(-5.0f, 5.0f);

                Instantiate(BoatPrefab, new Vector3(x, y, 0.0f), Quaternion.identity);
            }

            timer = Random.Range(SpawnTimeRange.x, SpawnTimeRange.y);
        }
    }
}
