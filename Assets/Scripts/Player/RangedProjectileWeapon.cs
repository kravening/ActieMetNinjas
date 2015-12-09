using UnityEngine;
using System.Collections;

public class RangedProjectileWeapon : WeaponBase
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject muzzlePosition;
    [SerializeField]
    private float currentAngleOffset;

    // behaviour Modifiers
    [SerializeField]
    private float bulletSpreadAmount;
    [SerializeField]
    private bool multipleProjectiles;
    [SerializeField]
    private int projectileAmount;
    [SerializeField]
    private float BulletSpacing;
    [SerializeField]
    private bool isShotgun;
    // Use this for initialization
    void Start()
    {
        findPlayer();
        ResetAngleOffset();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBools();
        //Debug.Log(BulletSpacing);
    }
    private void CheckBools()
    {
        if (!canAttack && Time.time > attackTimeStamp)                                         //weapon attack cooldown check
        {
            canAttack = true;                                                                  // allows you to "attack"
        }
        if (Time.time > reloadTimeStamp)                                                       //reload cooldown check
        {
            isReloading = false;                                                               // you aren't reloading anymore woohoo!
        }
    }

    private void ReloadSequence()                                                              // reloads the weapon;
    {
        findPlayer();
        if (weaponAmmo <= 0 && isPickup == false)                                              //don't reload if object is not equipped, but weapon has to be equipped anyway to be able call this function
        {
            if (ammoController.PlayerAmmo >= 1)                                                // checks if player has any ammo left
            {
                isReloading = true;                                                            // sets bool
                reloadTimeStamp = Time.time + reloadTime;                                      // sets time when reload is "done"
                if (ammoController.PlayerAmmo <= baseWeaponAmmo)                               // if contains less than maximum ammo of the clip, only remove what you can miss
                {
                    int ammoToBeAdded = ammoController.PlayerAmmo;                             // stores value in temporary var
                    weaponAmmo += ammoToBeAdded;                                               // adds ammo to the "clip" based on whats left
                    ammoController.PlayerAmmo = ammoController.PlayerAmmo - ammoToBeAdded;     // should set ammo to 0
                }
                else
                {
                    ammoController.PlayerAmmo = ammoController.PlayerAmmo - baseWeaponAmmo;    // removes ammo
                    weaponAmmo = baseWeaponAmmo;                                               // adds ammo to the "clip"
                }
            }
            else
            {
                Debug.Log("you have no ammo of that type left");
            }
        }
        Debug.Log(ammoController.PlayerAmmo);
    }

    public void Attack()
    {
        if (weaponAmmo >= 1)
        {
            if (!isPickup && !isReloading)
            {
                if (canAttack)
                {
                    if (isAutomatic)
                    {
                        Fire();
                    }
                    else
                    {
                        ManualFire();
                    }
                }
            }
        }
        else
        {
            ReloadSequence();                                                                   // reloads weapon for you if you hit 0 while trying to fire
        }
    }

    public void ManualReload()
    {
        if (weaponAmmo != baseWeaponAmmo)                                                       // you can't reload if ammo is full
        {
            ammoController.PlayerAmmo = ammoController.PlayerAmmo + weaponAmmo;                 // adds clip ammo to player total
            weaponAmmo = 0;
        }
        ReloadSequence();
    }

    public void ManualFire()
    {
        if (triggerReleased)
        {
            triggerReleased = false;
            Fire();
        }
    }

    public void Fire()
    {
        if (multipleProjectiles)
        {
            for (int i = 0; i < projectileAmount; i++)
            {
                currentAngleOffset += BulletSpacing; //increases angle for next bullet
                createMultiple();
            }
        }
        else
        {
            createBullet();
        }
        weaponAmmo--; // enable it later
        if (weaponAmmo <= 0)                                                        // reloads weapon for you if you hit 0 after firing
        {
            ReloadSequence();
        }
        ResetAngleOffset();
    }

    private void createBullet()
    {
        float bulletspread = returnRandom(-bulletSpreadAmount, bulletSpreadAmount);
        Quaternion bulletRotation = transform.rotation;
        bulletspread = returnRandom(-bulletSpreadAmount, bulletSpreadAmount);
        bulletRotation.y += bulletspread;
        if (multipleProjectiles == true && isShotgun == false)
        {
            bulletRotation.y += currentAngleOffset;
        }
        Instantiate(bullet, muzzlePosition.transform.position, bulletRotation);
        canAttack = false;
        attackTimeStamp = Time.time + attackCooldownPeriod;
        //Debug.Log(bulletRotation.y);
    }
    private void createMultiple()
    {
       // float randomNumberY = Random.Range(-bulletSpreadAmount, bulletSpreadAmount); if you want a random spread use this instead of currentAngleoffset
        GameObject datBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        datBullet.transform.Rotate(0, currentAngleOffset, 0);
        // datBullet.transform.Rotate(0, randomNumberY, 0);
        canAttack = false;
        attackTimeStamp = Time.time + attackCooldownPeriod;
    }


    private void ResetAngleOffset()
    {
        currentAngleOffset = -(BulletSpacing * projectileAmount) / 2; //Mathf.PI*2; // still not perfect but margin of error is small enough for now
    }

    private float returnRandom(float min, float max)
    {
        return Random.Range(min, max);
    }
}
