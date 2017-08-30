using System.Collections;
using System.Collections.Generic;

public class Framework_Weapon
{
    public string id;
    public float damage;
    public string name;
    public bool purchased;
    public int cost;

    public Framework_Weapon(string _id, float _damage, string _name, bool _purchased, int _cost)
    {
        id = _id;
        damage = _damage;
        name = _name;
        purchased = _purchased;
        cost = _cost;
    }
}
