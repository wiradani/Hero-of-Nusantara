using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {
    public EnemyBehavior enemy;
    public List<Framework_Enemy> enemyList = new List<Framework_Enemy>();
    
    int randNum;
	// Use this for initialization
	void Start () {
        enemy = Resources.Load<EnemyBehavior>("Enemy/Enemy");
        enemyList = Framework_GameManager.currentLevel.enemyOnLevel;
    }

    bool waitActive = false;
    bool canSpawn = false;

    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(8.0F);
        canSpawn = true;
        waitActive = false;
    }

    // Update is called once per frame
    void Update () {
        randNum = Random.Range(0, enemyList.Count);

        if (!waitActive)
        {
            StartCoroutine(Wait());
        }
        if (canSpawn)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Player"));
            EnemyBehavior enemyClone = Instantiate<EnemyBehavior>(enemy, new Vector3(transform.position.x+7.716f,
                transform.position.y, 0), transform.rotation);
            enemyClone.enemyData = enemyList[randNum];

            canSpawn = false;
        }

        
    }
}
