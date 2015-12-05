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
        if(weaponAmmo <= 0)
        {
            isReloading = true;
            reloadTimeStamp = Time.time + reloadTime;
            weaponAmmo = baseWeaponAmmo;
        }
        if(Time.time > reloadTimeStamp)
        {
            isReloading = false;
        }
	}

    public void InstantiateBullet()
    {
        if (!isPickup && !isReloading)
        {
            if (canAttack)
            {
                Instantiate(bullet, muzzlePosition.transform.position, transform.rotation);
                canAttack = false;
                attackTimeStamp = Time.time + attackCooldownPeriod;
                weaponAmmo--;
            }
            else
            {

            }
        }
    }

    public void ManualReload()
    {
        weaponAmmo = 0;
    }
}
