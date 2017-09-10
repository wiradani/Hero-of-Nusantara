using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Framework_Humanoid : MonoBehaviour
{
    public SpriteRenderer body, staticArm, dynamicShoulder, dynamicArm, staticLeg, dynamicLeg, weapon;

    void Start()
    {
        UpdatePlayerAppeareance();
    }

    public void UpdatePlayerAppeareance()
    {
        body.sprite = Framework_GameManager.humanoidSpriteDatabase["player_" + Framework_GameManager.playerData.costume.id + "_body"];
        staticArm.sprite = Framework_GameManager.humanoidSpriteDatabase["player_" + Framework_GameManager.playerData.costume.id + "_static_arm"];
        dynamicArm.sprite = Framework_GameManager.humanoidSpriteDatabase["player_" + Framework_GameManager.playerData.costume.id + "_dynamic_arm"];
        dynamicShoulder.sprite = Framework_GameManager.humanoidSpriteDatabase["player_" + Framework_GameManager.playerData.costume.id + "_dynamic_shoulder"];
        staticLeg.sprite = Framework_GameManager.humanoidSpriteDatabase["player_" + Framework_GameManager.playerData.costume.id + "_static_leg"];
        dynamicLeg.sprite = Framework_GameManager.humanoidSpriteDatabase["player_" + Framework_GameManager.playerData.costume.id + "_dynamic_leg"];
        weapon.sprite = Framework_GameManager.weaponSpriteDatabase[Framework_GameManager.playerData.weapon.id];
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }
}
