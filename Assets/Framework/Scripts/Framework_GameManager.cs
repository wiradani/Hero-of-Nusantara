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

    public static Dictionary<string,Sprite> humanoidSpriteDatabase = new Dictionary<string, Sprite>();

    public static Framework_Level currentLevel;
    // Use this for initialization
    void Awake()
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
        
        weaponDatabase.Add(new Framework_Weapon("sling", 0.1f, "Sling", false, 10));
        weaponDatabase.Add(new Framework_Weapon("javelin", 0.5f, "Javelin", false, 20));

        costumeDatabase.Add(new Framework_CostumeData("default", "Default", 1));
        costumeDatabase.Add(new Framework_CostumeData("assasin", "Assasin", 1));

        playerData = new Framework_PlayerData();

        List<Framework_Enemy> x = new List<Framework_Enemy>();
        List<Framework_Enemy> y = new List<Framework_Enemy>();
        List<Framework_Enemy> z = new List<Framework_Enemy>();

        x.Add(new Framework_Enemy("brute", "Brute", 1f, EnemyType.Melee, 0f));
        levelDatabase.Add(new Framework_Level("act1lvl1", x));

        y.Add(new Framework_Enemy("brute", "Brute", 1f, EnemyType.Melee, 0f));
        y.Add(new Framework_Enemy("shield", "Shield", .5f, EnemyType.Shield, 0f));
        levelDatabase.Add(new Framework_Level("act1lvl2", y));

        z.Add(new Framework_Enemy("brute", "Brute", 1f, EnemyType.Melee, 0f));
        z.Add(new Framework_Enemy("shield", "Shield", .5f, EnemyType.Shield, 0f));
        z.Add(new Framework_Enemy("range", "Range", 1f, EnemyType.Range, 2f));
        levelDatabase.Add(new Framework_Level("act1lvl3", z));


        Sprite[] allCostume = Resources.LoadAll<Sprite>("Player Costume/");
        foreach (Sprite aCostume in allCostume)
        {
            Framework_GameManager.humanoidSpriteDatabase.Add(aCostume.name, aCostume);
        }
    }

    public void GoToArena()
    {
        currentLevel = levelDatabase[0];
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("Musuh", LoadSceneMode.Additive);
        StartCoroutine(Framework_MasterCamera.instance.DeleteCameras("Musuh"));

        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        StartCoroutine(Framework_MasterCamera.instance.DeleteCameras("Player"));
    }

    public void GoToUpgrade()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("Upgrade", LoadSceneMode.Additive);
        StartCoroutine(Framework_MasterCamera.instance.DeleteCameras("Upgrade"));
    }
}
