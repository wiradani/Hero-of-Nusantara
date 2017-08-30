using System.Collections;
using System.Collections.Generic;

public class Framework_Level
{
    public string id;
    public List<Framework_Enemy> enemyOnLevel = new List<Framework_Enemy>();

    public Framework_Level(string _id, List<Framework_Enemy> _enemyOnLevel)
    {
        id = _id;
        enemyOnLevel = _enemyOnLevel;
    }
}
