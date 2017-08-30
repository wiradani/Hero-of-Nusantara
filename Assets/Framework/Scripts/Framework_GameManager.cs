using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Framework_GameManager : MonoBehaviour
{
    public static Framework_PlayerData playerData;
    public static List<Framework_Weapon> weaponDatabase = new List <Framework_Weapon>();

    // Use this for initialization
    void Start()
    {
        weaponDatabase.Add(new Framework_Weapon("sling", 0.1f, "Sling", false, 10));
        weaponDatabase.Add(new Framework_Weapon("javelin", 0.5f, "Javelin", false, 20));

        SceneManager.LoadScene("Upgrade", LoadSceneMode.Additive);	
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }
}
