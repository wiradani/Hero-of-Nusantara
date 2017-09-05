using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;
    public Framework_Enemy enemyData = new Framework_Enemy(null,null,1,EnemyType.Melee,5);
    public WeaponBehavior weapon;
    bool inArea = false;
	public float speed = 1;

    public static Enemy_BoneStructure bones;
	// Use this for initialization
	void Start () {
        enemy = this.gameObject;
        //enemy.name = enemyData.id;

        /*///// Get Bones Sprites //////
        bones.getBones();

        bones.setSprites(bones.Body, "e1"+enemy.name);
        bones.setSprites(bones.LeftShoulder, "e1" + enemy.name);
        bones.setSprites(bones.RightShoulder, "e1" + enemy.name);
        bones.setSprites(bones.LHWeapon, "e1" + enemy.name);
        bones.setSprites(bones.RHWeapon, "e1" + enemy.name);
        bones.setSprites(bones.LeftLeg, "e1" + enemy.name);
        bones.setSprites(bones.RightLeg, "e1" + enemy.name);
        ///*//*

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
        */
        player = GameObject.Find("player");
        enemy.GetComponent<Animator>().speed = 0.75F;
        enemy.GetComponent<TrailRenderer>().enabled = false;

        enemyData.type = EnemyType.Melee;
    }

    bool waitActive = false;
    bool canAttack = false;
    bool stopAttack = false;

    IEnumerator Wait (float time) {
        waitActive = true;
        yield return new WaitForSeconds(time);
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
            enemy.GetComponent<Animator>().Play("Run");
        }
        else
        {
            if (!waitActive)
            {
                StartCoroutine(Wait(3.0f));
                enemy.GetComponent<Animator>().Play("Idle");
            }
            if (canAttack && !stopAttack)
            {
                stopAttack = true;
                resetAll();

                if (enemyData.type == EnemyType.Melee)
                {
                    StartCoroutine(MeleeAttack());
                    StopAllCoroutines(); 
                }
            }
        }
	}

    void resetAll()
    {
        waitActive = false;
        stopAttack = false;
        canAttack = false;
    }

    void Attack ()
    {
        
        Vector3 weapon_position = new Vector3(enemy.GetComponent<Transform>().position.x + 0.36F,
                                                enemy.GetComponent<Transform>().position.y + 0.84F, 0);

        WeaponBehavior IO = Instantiate<WeaponBehavior>(weapon, weapon_position, weapon.transform.rotation);
        IO.ifParent = false;
        IO.hopping = false;
        IO.enemy = this.gameObject;
        
    }

    void startTrails()
    {
        //var trail = transform.Find("Core/_Body/_Right Shoulder/Right Shoulder/_RH Weapon/RH Weapon/Weapon Head");
        var trail = GameObject.Find("Weapon Head");
        trail.GetComponent<TrailRenderer>().enabled = true;
    }

    void endTrails()
    {
        //var trail = transform.Find("Core/_Body/_Right Shoulder/Right Shoulder/_RH Weapon/RH Weapon/Weapon Head");
        var trail = GameObject.Find("Weapon Head");
        trail.GetComponent<TrailRenderer>().enabled = false;
    }


    IEnumerator MeleeAttack()
    {
        waitActive = true;
        enemy.GetComponent<Animator>().Play("meleeAttack");
        yield return new WaitForSeconds(0.5f);
        canAttack = false;
        stopAttack = false;
        waitActive = false;
    }

    void ShieldAttack()
    {
        enemy.GetComponent<Animator>().Play("shieldAttack");
    }
}
