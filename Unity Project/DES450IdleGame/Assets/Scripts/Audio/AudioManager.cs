using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource BoatDie;
    public AudioSource BoatTakeDmg;
    public AudioSource UI_Click;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BoatDeath()
    {
        BoatDie.Play();
    }

    public void BoatTakeDamage()
    {
        BoatTakeDmg.Play();
    }

    public void UIClicked()
    {
        UI_Click.Play();
    }
}
