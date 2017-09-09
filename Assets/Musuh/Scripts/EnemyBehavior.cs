using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;
    public Framework_Enemy enemyData;
    public WeaponBehavior weapon;
    bool inArea = false;
	public float speed = 1;
    public int darah=1;

    private Vector3 posisi;

    //public static Enemy_BoneStructure bones = GameObject.Enemy_BoneStructure();
	// Use this for initialization
	void Start () {
        enemy = this.gameObject;
        
        enemy.name = enemyData.id;
        var bones = enemy.GetComponent<Enemy_BoneStructure>();
        ////// Get Bones Sprites //////
        bones.SetSprites(enemyData.id, enemyData.type);

        if (enemyData.type == EnemyType.Range)
            weapon = Resources.Load<WeaponBehavior>("Enemy/werange");
        /*
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
        */
        //enemy.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(enemyData.id);

        enemy.GetComponent<CircleCollider2D>().radius = enemyData.stoppingDistance;
        speed = enemyData.speed;
        
        player = GameObject.Find("Player");
        enemy.GetComponent<Animator>().speed = 0.75F;
        //var trail = GameObject.Find("Weapon Head");
        //trail.GetComponent<TrailRenderer>().enabled = false;
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
        {
            StopAllCoroutines();
            inArea = false; resetAll();
        }
        else { inArea = true; }

        if (!inArea)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            enemyRun();
        }
        else
        {
            if (!waitActive)
            {
                StartCoroutine(Wait(3.0f));
                enemyIdle();
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
                else if (enemyData.type == EnemyType.Shield)
                {
                    StartCoroutine(ShieldAttack());
                    StopAllCoroutines();
                }
                else if (enemyData.type == EnemyType.Range)
                {
                    StartCoroutine(RangeAttack());
                    StopAllCoroutines();
                }
            }
        }
	}

    void enemyRun()
    {
        if(enemyData.type==EnemyType.Melee)
            enemy.GetComponent<Animator>().Play("meleeRun");
        else if (enemyData.type == EnemyType.Range)
            enemy.GetComponent<Animator>().Play("rangeRun");
        else if (enemyData.type == EnemyType.Shield)
            enemy.GetComponent<Animator>().Play("shieldRun");
    }

    void enemyIdle()
    {
        if (enemyData.type == EnemyType.Melee)
            enemy.GetComponent<Animator>().Play("meleeIdle");
        else if (enemyData.type == EnemyType.Range)
            enemy.GetComponent<Animator>().Play("rangeIdle");
        else if (enemyData.type == EnemyType.Shield)
            enemy.GetComponent<Animator>().Play("shieldIdle");
    }

    void resetAll()
    {
        waitActive = false;
        stopAttack = false;
        canAttack = false;
    }

    void Attack ()
    {
        posisi = new Vector3(transform.position.x - 7.716f, transform.position.y, 0);
        Vector3 weapon_position = new Vector3(posisi.x + 0.36F,
                                                posisi.y + 0.84F, 0);

		SceneManager.SetActiveScene(SceneManager.GetSceneByName("Player"));
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

    IEnumerator ShieldAttack()
    {
        waitActive = true;
        enemy.GetComponent<Animator>().Play("shieldAttack");
        yield return new WaitForSeconds(1.5f);
        canAttack = false;
        stopAttack = false;
        waitActive = false;
    }

    IEnumerator RangeAttack()
    {
        waitActive = true;
        enemy.GetComponent<Animator>().Play("rangeAttack");
        yield return new WaitForSeconds(1.0f);
        canAttack = false;
        stopAttack = false;
        waitActive = false;
    }

    void GetDamage(int damage)
    {
        darah -= damage;
        if (darah <= 0) Destroy(gameObject);
    }
}
