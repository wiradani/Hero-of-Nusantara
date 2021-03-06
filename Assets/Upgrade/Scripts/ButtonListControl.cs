﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{

    [SerializeField]
    private GameObject buttonTemplate;

	public Framework_Humanoid avatar;
	public static ButtonListControl instance;

	void Awake(){
		instance = this;
	}

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < Framework_GameManager.weaponDatabase.Count; i++)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Upgrade"));
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().setText(Framework_GameManager.weaponDatabase[i]);

            button.transform.SetParent(gameObject.transform, false);
			
        }
    }

}
