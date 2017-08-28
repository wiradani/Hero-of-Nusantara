using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wira : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void BeliWeapon(string id)
    {
        if (id == "spear")
        //beli spear
        Framework_GameManager.playerData.weapon = Weapon.SPEAR;
    }
}
