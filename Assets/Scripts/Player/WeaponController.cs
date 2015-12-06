using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
    [SerializeField]
    private GameObject leftWeaponSlot;
    [SerializeField]
    private GameObject rightWeaponSlot;

    public void Attack(string wichWeapon)
    {
        switch (wichWeapon)
        {
            case "leftWeapon":
                leftWeaponSlot.GetComponent<WeaponContainer>().weapon.GetComponent<RangedProjectileWeapon>().InstantiateBullet();
                break;
            case "rightWeapon":
                rightWeaponSlot.GetComponent<WeaponContainer>().weapon.GetComponent<RangedProjectileWeapon>().InstantiateBullet();
                break;
        }
    }
    public void ReleaseTrigger(string wichWeapon)
    {
        switch (wichWeapon){
            case "leftWeapon":
                leftWeaponSlot.GetComponent<WeaponContainer>().weapon.GetComponent<RangedProjectileWeapon>().triggerReleased = true;
                break;
            case "rightWeapon":
                rightWeaponSlot.GetComponent<WeaponContainer>().weapon.GetComponent<RangedProjectileWeapon>().triggerReleased = true;
                break;
        }
    }

    public void ManualReload(string wichWeapon)
    {
        switch (wichWeapon)
        {
            case "leftWeapon":
                leftWeaponSlot.GetComponent<WeaponContainer>().weapon.GetComponent<RangedProjectileWeapon>().ManualReload();
                break;
            case "rightWeapon":
                rightWeaponSlot.GetComponent<WeaponContainer>().weapon.GetComponent<RangedProjectileWeapon>().ManualReload();
                break;
        }
    }

    public void ChangeWeapon(GameObject weapon, string wichWeapon)
    {
        Transform weaponGroundPos = weapon.transform; //saves weapon to pickup transform so you can drop equipped weapon on that position;
        GameObject holdGameObject = null;
        switch (wichWeapon)
        {
            case "leftWeapon":

            leftWeaponSlot.GetComponent<WeaponContainer>().toggleBool(); //toggle bool for old weapon
            holdGameObject = leftWeaponSlot; // temporarily store current weapon in here
            holdGameObject.transform.position = weaponGroundPos.position; // changes position of weapon you where holding to the old position of the picked up weapon
            leftWeaponSlot = weapon; // replaces current weapon with picked-up one
            weapon = holdGameObject; //replace picked up weapon with old weapon

            leftWeaponSlot.GetComponent<WeaponContainer>().toggleBool();//toggle bool for new weapon

                break;
            case "rightWeapon":

            rightWeaponSlot.GetComponent<WeaponContainer>().toggleBool(); //toggle bool for old weapon
            holdGameObject = rightWeaponSlot; // temporarily store current weapon in here
            holdGameObject.transform.position = weaponGroundPos.position; // changes position of weapon you where holding to the old position of the picked up weapon
            leftWeaponSlot = weapon; // replaces current weapon with picked-up one
            weapon = holdGameObject; //replace picked up weapon with old weapon

            rightWeaponSlot.GetComponent<WeaponContainer>().toggleBool();//toggle bool for new weapon
                break;

        }
    }
}
