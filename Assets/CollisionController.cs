using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {


	void OnTriggerEnter(Collider other){
		Debug.Log ("ayy");
		if (other.tag == "Ammo") {
			GetComponent<AmmoController>().playerAmmo += other.gameObject.GetComponent<AmmoBox>().AmmoPickup();
			Debug.Log(GetComponent<AmmoController>().playerAmmo);
		}
	}
}
