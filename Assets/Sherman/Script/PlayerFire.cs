using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("Particle")]
    public ParticleSystem particle_1;
    public ParticleSystem particle_2;

    [Header("Sound effects")]
    public AudioSource gun_firing;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Fire!");
            gun_fire();
        }
    }

    void gun_fire()
    {
        particle_1.Play();
        particle_2.Play();
    }
}
