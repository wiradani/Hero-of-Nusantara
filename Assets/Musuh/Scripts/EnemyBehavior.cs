using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;
    public Framework_Enemy enemyData;
    public WeaponBehavior weapon;
    bool inArea = false;
	public float speed = 1;

	// Use this for initialization
	void Start () {
        enemy = this.gameObject;
        enemy.name = enemyData.id;

        ////// Get Bones Sprites //////
        

        ////

        if (enemyData.type == EnemyType.Range)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("enemy1_1");
            weapon = Resources.Load<WeaponBehavior>("werange");

        }
        else if (enemyData.type == EnemyType.Melee)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("enemy1_9");
            weapon = null;
        }
        else if (enemyData.type == EnemyType.Shield)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("enemy1_18");
            weapon = null;
        }
        enemy.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(enemyData.id);
        enemy.GetComponent<CircleCollider2D>().radius = enemyData.stoppingDistance;
        speed = enemyData.speed;
        player = GameObject.Find("player");
        enemy.GetComponent<Animator>().speed = 0.5F;
    }

    bool waitActive = false;
    bool canAttack = false;

    IEnumerator Wait () {
        waitActive = true;
        yield return new WaitForSeconds(3.0F);
        canAttack = true;
        waitActive = false;
    }

    // Update is called once per frame
    void Update () {


        if (!enemy.GetComponent<CircleCollider2D>().IsTouching(player.GetComponent<Collider2D>()))
            inArea = false;
        else inArea = true;

        if (!inArea)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            enemy.GetComponent<Animator>().enabled = true;
        }
        else
        {
            enemy.GetComponent<Animator>().enabled = false;
            if (!waitActive)
                StartCoroutine(Wait());
            if (canAttack)
            {
                Attack();
                canAttack = false;
            }
        }
	}

    void Attack ()
    {
        if (enemyData.type == EnemyType.Range)
        {
            Vector3 weapon_position = new Vector3(enemy.GetComponent<Transform>().position.x + 0.36F,
                                                    enemy.GetComponent<Transform>().position.y + 0.84F, 0);

            WeaponBehavior IO = Instantiate<WeaponBehavior>(weapon, weapon_position, weapon.transform.rotation);
            IO.ifParent = false;
            IO.hopping = false;

        }
    }

}
