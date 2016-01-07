using UnityEngine;
using System.Collections;

public class AmmoBox : MonoBehaviour {
	[SerializeField]private int AmmoAmount = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Destroy (this.gameObject);
		}
	}

	public int AmmoPickup(){
		return AmmoAmount;
	}
}
