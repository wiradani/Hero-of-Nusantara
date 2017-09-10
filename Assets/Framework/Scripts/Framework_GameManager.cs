using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Framework_GameManager : MonoBehaviour
{

    public static bool pause;
    public static Framework_GameManager instance;

    public static Framework_PlayerData playerData;
    public static List<Framework_Weapon> weaponDatabase = new List <Framework_Weapon>();
    public static List<Framework_CostumeData> costumeDatabase = new List<Framework_CostumeData>();
    public static List<Framework_Enemy> enemyDatabase = new List<Framework_Enemy>();
    public static List<Framework_Level> levelDatabase = new List<Framework_Level>();

    public static Dictionary<string,Sprite> humanoidSpriteDatabase = new Dictionary<string, Sprite>();
    public static Dictionary<string, Sprite> enemySpriteDatabase = new Dictionary<string, Sprite>();

    public static Framework_Level currentLevel;
    // Use this for initialization
    void Awake()
    {
        SetDatabase();
        instance = this;

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
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


        x.Add(new Framework_Enemy("brute_a1", "Brute", 1f, EnemyType.Melee, 4f));
        levelDatabase.Add(new Framework_Level("act1lvl1", x));

        y.Add(new Framework_Enemy("brute_a1", "Brute", 1f, EnemyType.Melee, 4f));
        y.Add(new Framework_Enemy("shield_a1", "Shield", .5f, EnemyType.Shield, 4f));
        levelDatabase.Add(new Framework_Level("act1lvl2", y));

        z.Add(new Framework_Enemy("brute_a1", "Brute", 1f, EnemyType.Melee, 4f));
        z.Add(new Framework_Enemy("shield_a1", "Shield", .5f, EnemyType.Shield, 4f));
        z.Add(new Framework_Enemy("range_a1", "Range", 1f, EnemyType.Range, 15f));
        levelDatabase.Add(new Framework_Level("act1lvl3", z));


        Sprite[] allCostume = Resources.LoadAll<Sprite>("Player Costume/");
        foreach (Sprite aCostume in allCostume)
        {
            Framework_GameManager.humanoidSpriteDatabase.Add(aCostume.name, aCostume);
        }

        Sprite[] allEnemy = Resources.LoadAll<Sprite>("Enemy Sprites/");
        foreach (Sprite aEnemy in allEnemy)
        {
            Framework_GameManager.enemySpriteDatabase.Add(aEnemy.name, aEnemy);
        }
    }

    public void GoToArena()
    {
        currentLevel = levelDatabase[2];
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

    public void BackFromUpgrade()
    {
        SceneManager.UnloadSceneAsync("Upgrade");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        StartCoroutine(Framework_MasterCamera.instance.DeleteCameras("MainMenu"));
    }
}