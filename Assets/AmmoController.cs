using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmmoController : MonoBehaviour {// script for keeping track of ammo
    private int basePlayerAmmo = 1000;
    public int PlayerAmmo { get; set; }

    void Start()
    {
        PlayerAmmo = basePlayerAmmo;
    }
}
