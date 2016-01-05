using UnityEngine;
using System.Collections;

public class ChildDecoupler : MonoBehaviour {
    [SerializeField]private ParticleSystem emitter;

    public void DeCoupler()
    {
		if (emitter != null) {
			emitter.transform.parent = null;
			emitter.emissionRate = 0;
		}
    }
}
