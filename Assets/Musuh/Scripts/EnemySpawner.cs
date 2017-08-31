using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public EnemyBehavior enemy;
    public List<Framework_Enemy> enemyList = new List<Framework_Enemy>();
    
    int randNum;
	// Use this for initialization
	void Start () {
        enemyList = Framework_GameManager.currentLevel.enemyOnLevel;
        Debug.Log("Enemy:  "+ enemyList.Count);
        enemy = (EnemyBehavior)Resources.Load("musuh");
    }

    bool waitActive = false;
    bool canSpawn = false;

    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(5.0F);
        canSpawn = true;
        waitActive = false;
    }

    // Update is called once per frame
    void Update () {
        randNum = Random.Range(0, enemyList.Count-2);

        if (!waitActive)
        {
            StartCoroutine(Wait());
        }
        if (canSpawn)
        {
            EnemyBehavior enemyClone = Instantiate(enemy, new Vector3(transform.position.x,
                transform.position.y, 0), Quaternion.identity);
            enemyClone.enemyData = enemyList[randNum];

            canSpawn = false;
        }

        
    }
}
