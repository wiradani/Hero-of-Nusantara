using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Framework_GameManager : MonoBehaviour
{
    public static Framework_GameManager instance;

    public static Framework_PlayerData playerData;
    public static List<Framework_Weapon> weaponDatabase = new List <Framework_Weapon>();
    public static List<Framework_CostumeData> costumeDatabase = new List<Framework_CostumeData>();
    public static List<Framework_Enemy> enemyDatabase = new List<Framework_Enemy>();
    public static List<Framework_Level> levelDatabase = new List<Framework_Level>();

    public static Framework_Level currentLevel;
    // Use this for initialization
    void Start()
    {
        instance = this;

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);

        SetDatabase();
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    public void SetDatabase()
    {
        playerData = new Framework_PlayerData();

        weaponDatabase.Add(new Framework_Weapon("sling", 0.1f, "Sling", false, 10));
        weaponDatabase.Add(new Framework_Weapon("javelin", 0.5f, "Javelin", false, 20));



        List<Framework_Enemy> x = new List<Framework_Enemy>();
        x.Add(new Framework_Enemy("brute", "Brute", 1f, EnemyType.Melee, 0f));
        levelDatabase.Add(new Framework_Level("act1lvl1", x));
        x.Add(new Framework_Enemy("shield", "Shield", .5f, EnemyType.Shield, 0f));
        levelDatabase.Add(new Framework_Level("act1lvl2", x));
        x.Add(new Framework_Enemy("range", "Range", 1f, EnemyType.Range, 2f));
        levelDatabase.Add(new Framework_Level("act1lvl3", x));
    }

    public void GoToArena()
    {
        currentLevel = levelDatabase[0];
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("Musuh", LoadSceneMode.Additive);
        Framework_MasterCamera.instance.DeleteCameras("Musuh");
    }

    public void GoToUpgrade()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("Upgrade", LoadSceneMode.Additive);
        Framework_MasterCamera.instance.DeleteCameras("Upgrade");
    }
}
