using UnityEngine;
using System.Collections;

public class ParticleSystemAutoDestroy : MonoBehaviour {
    private ParticleSystem emitter;
	private float DestroyDelay = 1f;
	// Use this for initialization
	void Start () {
		DestroyDelay += Time.time;
        emitter = this.gameObject.GetComponent<ParticleSystem>();
	}
	void FixedUpdate() {
        if (emitter.particleCount <= 0 && DestroyDelay >= Time.time)
        {
            Destroy(this.gameObject);
        }
	}
}
