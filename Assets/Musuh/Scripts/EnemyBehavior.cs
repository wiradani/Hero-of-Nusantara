using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;
    public WeaponBehavior weapon;
    bool inArea = false;
	public float speed = 1;

	// Use this for initialization
	void Start () {
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
        

        if (enemy.GetComponent<CircleCollider2D>().IsTouching(player.GetComponent<Collider2D>()))
            inArea = true;

        if (!inArea)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
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
        
        Vector3 weapon_position = new Vector3(enemy.GetComponent<Transform>().position.x + 0.36F,
                                                enemy.GetComponent<Transform>().position.y + 0.84F, 0);

        WeaponBehavior IO = Instantiate(weapon, weapon_position, weapon.transform.rotation);
        IO.ifParent = false;
        IO.GetComponent<SpriteRenderer>().enabled = true;
    }
}
