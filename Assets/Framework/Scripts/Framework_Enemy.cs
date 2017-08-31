using System.Collections;
using System.Collections.Generic;

public class Framework_Enemy
{
    public string id;
    public string name;
    public float speed;
    public EnemyType type;
    public float stoppingDistance;

    public Framework_Enemy(string _id, string _name, float _speed, EnemyType _enemyType, float _stoppingDistance)
    {
        id = _id;
        name = _name;
        speed = _speed;
        type = _enemyType;
        stoppingDistance = _stoppingDistance;
    }
}
