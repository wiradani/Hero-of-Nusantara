using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BoneStructure : MonoBehaviour {
    public SpriteRenderer Body, LeftShoulder, RightShoulder, LHWeapon, RHWeapon, LeftLeg, RightLeg;
    public GameObject LWHead, RWHead;

    public void SetSprites(string id, EnemyType type)
    {
        Body.enabled = true;
        LeftShoulder.enabled = true;
        RightShoulder.enabled = true;
        LHWeapon.enabled = true;
        RHWeapon.enabled = true;
        LeftLeg.enabled = true;
        RightLeg.enabled = true;
        RightShoulder.sortingOrder = -1;

        Body.sprite = Framework_GameManager.enemySpriteDatabase[id + "_body"];
        LeftShoulder.sprite = Framework_GameManager.enemySpriteDatabase[id + "_left_arm"];
        RightShoulder.sprite = Framework_GameManager.enemySpriteDatabase[id + "_right_arm"];
        LeftLeg.sprite = Framework_GameManager.enemySpriteDatabase[id + "_left_leg"];
        RightLeg.sprite = Framework_GameManager.enemySpriteDatabase[id + "_right_leg"];
        if(type!=EnemyType.Range)
            RHWeapon.sprite = Framework_GameManager.enemySpriteDatabase[id + "_rh_weapon"];
        else RHWeapon.enabled = false;
        if (type != EnemyType.Melee)
            LHWeapon.sprite = Framework_GameManager.enemySpriteDatabase[id + "_lh_weapon"];
        else LHWeapon.enabled = false;
        if (type == EnemyType.Shield)
            RightShoulder.sortingOrder = -3;
    }

}
