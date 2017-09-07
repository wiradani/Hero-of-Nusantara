using System.Collections;
using System.Collections.Generic;

public class Framework_PlayerData
{
    public bool isDead;
    public Framework_Weapon weapon;
    public Framework_CostumeData costume;

    public Framework_PlayerData()
    {
        weapon = Framework_GameManager.weaponDatabase[0];
        costume = Framework_GameManager.costumeDatabase[0];
    }
}
