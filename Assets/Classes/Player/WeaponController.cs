using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
    [SerializeField]
    private GameObject leftWeaponSlot;
    [SerializeField]
    private GameObject rightWeaponSlot;

    public void Attack(int wichWeapon)
    {
        if(wichWeapon == 0)// left weapon
        {
            leftWeaponSlot.GetComponent<WeaponContainer>().weapon.GetComponent<RangedProjectileWeapon>().InstantiateBullet();
            //Debug.Log("left");
        }else if(wichWeapon == 1) // right weapon
        {
           //Debug.Log("right");
           //change it so it checks the weapon type that is equiped in a function that returns a string or whatever.
           rightWeaponSlot.GetComponent<WeaponContainer>().weapon.GetComponent<RangedProjectileWeapon>().InstantiateBullet();
        }
        else
        {
            Debug.Log("Attack : this doesn't work did you give me the wrong value?");
        }
    }

    public void ManualReload(int wichWeapon)
    {
        if (wichWeapon == 0)// left weapon
        {
            leftWeaponSlot.GetComponent<WeaponContainer>().weapon.GetComponent<RangedProjectileWeapon>().ManualReload();
        }
        else if (wichWeapon == 1) // right weapon
        {
            //change it so it checks the weapon type that is equiped in a function that returns a string or whatever.
            rightWeaponSlot.GetComponent<WeaponContainer>().weapon.GetComponent<RangedProjectileWeapon>().ManualReload();
        }
        else
        {
            Debug.Log("Reload : this doesn't work did you give me the wrong value?");
        }
    }

    public void ChangeWeapon(GameObject weapon, int wichWeapon)
    {
        Transform weaponGroundPos = weapon.transform; //saves weapon to pickup transform so you can drop equipped weapon on that position;
        if(wichWeapon == 0)
        {
            leftWeaponSlot.GetComponent<WeaponContainer>().toggleBool(); //toggle bool for old weapon
            GameObject holdGameObject = leftWeaponSlot; // temporarily store current weapon in here
            holdGameObject.transform.position = weaponGroundPos.position; // changes position of weapon you where holding to the old position of the picked up weapon
            leftWeaponSlot = weapon; // replaces current weapon with picked-up one
            weapon = holdGameObject; //replace picked up weapon with old weapon

            leftWeaponSlot.GetComponent<WeaponContainer>().toggleBool();//toggle bool for new weapon
        }
        else if(wichWeapon == 1)
        {
            rightWeaponSlot.GetComponent<WeaponContainer>().toggleBool(); //toggle bool for old weapon
            GameObject holdGameObject = rightWeaponSlot; // temporarily store current weapon in here
            holdGameObject.transform.position = weaponGroundPos.position; // changes position of weapon you where holding to the old position of the picked up weapon
            leftWeaponSlot = weapon; // replaces current weapon with picked-up one
            weapon = holdGameObject; //replace picked up weapon with old weapon

            rightWeaponSlot.GetComponent<WeaponContainer>().toggleBool();//toggle bool for new weapon


        }
    }
}
