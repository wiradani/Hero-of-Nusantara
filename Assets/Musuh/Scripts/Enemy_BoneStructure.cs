using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BoneStructure : MonoBehaviour {
    public Transform Body;
    public Transform LeftShoulder;
    public Transform RightShoulder;
    public Transform LHWeapon;
    public Transform RHWeapon;
    public Transform LeftLeg;
    public Transform RightLeg;

    public void setSprites(Transform bone, string path)
    {
        bone.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(path);
    }

    public void getBones()
    {
        Body = transform.Find("Core/_Body/Body");
        LeftShoulder = transform.Find("Core/_Body/_Left Shoulder/Left Shoulder");
        RightShoulder = transform.Find("Core/_Body/_Right Shoulder/Right Shoulder");
        LHWeapon = transform.Find("Core/_Body/_Left Shoulder/Left Shoulder/_LH Weapon/LH Weapon");
        RHWeapon = transform.Find("Core/_Body/_Right Shoulder/Right Shoulder/_RH Weapon/RH Weapon");
        LeftLeg = transform.Find("Core/_Left Leg/Left Leg");
        RightLeg = transform.Find("Core/_Right Leg/Right Leg");
    }
}
