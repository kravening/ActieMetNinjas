using UnityEngine;
using System.Collections;

public class ParticleAudioOnCollision : MonoBehaviour {
    private AudioSourceController audioController;
	// Use this for initialization
	void Start () {
        audioController = GetComponent<AudioSourceController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Floor")
        {
            audioController.ChangeAudioSourceByIndex(0);
        }
    }
}
