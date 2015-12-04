using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {
    [SerializeField]private float lifeSpan;
	// Use this for initialization
	void Start () {
        lifeSpan = lifeSpan + Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	        if(lifeSpan <= Time.time)
        {
            Destroy(this.gameObject);
        }
	}
}
