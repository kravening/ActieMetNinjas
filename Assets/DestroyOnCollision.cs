using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField]private List<string> tags = new List<string>();
    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < tags.Count; i++)
        {
            if (other.gameObject.tag == tags[i])
            {
                GetComponent<ChildDecoupler>().DeCoupler();
                GetComponent<ParticlePrefabSpawner>().SpawnParticleFromList(0, transform);
                Destroy(this.gameObject);
                break;
            }
        }
    }
}
