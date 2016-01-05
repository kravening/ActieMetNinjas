using UnityEngine;
using System.Collections;

public class ParticleSystemAutoDestroy : MonoBehaviour {
    private ParticleSystem emitter;
	// Use this for initialization
	void Start () {
        emitter = this.gameObject.GetComponent<ParticleSystem>();
	}
	void FixedUpdate() {
        if (emitter.particleCount <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
