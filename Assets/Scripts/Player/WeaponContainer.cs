using UnityEngine;
using System.Collections;

public class WeaponContainer : MonoBehaviour {
    public GameObject weapon; // weapon in hand, variables from it has to be read.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        weapon.transform.position = transform.position; // "holds" the weapon
        weapon.transform.rotation = transform.rotation; // copy rotation from upper body
	}

    public void toggleBool()
    {
        if (weapon.GetComponent<WeaponBase>().isPickup == true)
        {
            weapon.GetComponent<WeaponBase>().isPickup = false;
        }
        else
        {
            weapon.GetComponent<WeaponBase>().isPickup = true;
        }
    }
}
