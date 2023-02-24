using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanParralax : MonoBehaviour
{
    public float AnimSpeed;
    public float MoveDistance;
    private float origX;
    private float newX;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        origX = transform.position.x;
        newX = origX - MoveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //lero towards new x
        float posX = Mathf.Lerp(origX, newX - 2f, timer * AnimSpeed);

        //set position
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);

        //if you moved past it
        if (transform.position.x <= newX)
        {
            //move back to original position, reset timer
            transform.position = new Vector3(origX, transform.position.y, transform.position.z);
            timer = 0f;
        }
    }
}
