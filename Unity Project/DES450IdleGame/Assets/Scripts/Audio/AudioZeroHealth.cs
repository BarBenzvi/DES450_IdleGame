using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZeroHealth : MonoBehaviour
{
    public GameObject BoatExplodeVFX;

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

        GameObject explodeVFX = Instantiate(BoatExplodeVFX);
        explodeVFX.GetComponent<ParticleSystem>().Play();
        explodeVFX.GetComponentInChildren<ParticleSystem>().Play();
        explodeVFX.transform.position = gameObject.transform.position;
    }

    void HealthReduced()
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().BoatTakeDamage();
        }
    }
}
