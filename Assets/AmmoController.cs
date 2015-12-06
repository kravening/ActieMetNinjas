using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmmoController : MonoBehaviour {// script for keeping track of ammo
    public int playerAmmo = 200;
    public int PlayerAmmo { get; set; }

    void Start()
    {
        PlayerAmmo = playerAmmo;
    }

    void Update()
    {
        playerAmmo = PlayerAmmo;
    }
}
