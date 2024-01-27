using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    void OnParticleTriggerEnter(GameObject other)
    {
        Debug.Log("Particle collision detected with: " + other.name);
      //  print(collision.gameObject.name);

        // Additional actions you might want to take on collision:
        // - Destroy particles
        // - Play sounds
        // - Trigger other events
    }

    private void Update()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[GetComponent<ParticleSystem>().main.maxParticles];
        int particleCount = GetComponent<ParticleSystem>().GetParticles(particles);

        for (int i = 0; i < particleCount; i++)
        {
            particles[i].position = new Vector3(
                particles[i].position.x,
                0,
                particles[i].position.z // Set Z to 0 to confine to 2D plane
            );
        }

        GetComponent<ParticleSystem>().SetParticles(particles, particleCount);
    }
}
