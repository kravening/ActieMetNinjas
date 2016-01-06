using UnityEngine;
using System.Collections;

public class ParticleSystemAutoDestroy : MonoBehaviour {
    private ParticleSystem emitter;
	private float destroyDelay = 1f;
	// Use this for initialization
	void Start () {
		destroyDelay = destroyDelay + Time.time;
        emitter = this.gameObject.GetComponent<ParticleSystem>();
	}
	void FixedUpdate() {
        if (emitter.particleCount <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
