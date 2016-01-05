using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticlePrefabSpawner : MonoBehaviour {
    [SerializeField]private List<ParticleSystem> particles = new List<ParticleSystem>();

    public void SpawnParticleFromList(int index, Transform trans)
    {
        if(particles[index] != null)
        Instantiate(particles[index], trans.position, trans.rotation);
    }
}
