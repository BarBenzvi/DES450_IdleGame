using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZeroHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReachedZeroHealth()
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().BoatDeath();
        }
    }

    void HealthReduced()
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().BoatTakeDamage();
        }
    }
}
