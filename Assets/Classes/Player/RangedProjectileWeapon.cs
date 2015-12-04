using UnityEngine;
using System.Collections;

public class RangedProjectileWeapon : WeaponBase {
    [SerializeField]private GameObject bullet;
    [SerializeField]private GameObject muzzlePosition;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(!canAttack && Time.time > attackTimeStamp)
        {
            canAttack = true;
        }
	}

    public void instantiateBullet()
    {
        if (!isPickup)
        {
            if (canAttack)
            {
                Instantiate(bullet, muzzlePosition.transform.position, transform.rotation);
                canAttack = false;
                attackTimeStamp = Time.time + attackCooldownPeriod;
            }
        }
    }
}
