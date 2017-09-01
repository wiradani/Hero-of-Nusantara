using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CostumeButtonListControl : MonoBehaviour
{

    [SerializeField]
    private GameObject buttonTemplate;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < Framework_GameManager.costumeDatabase.Count; i++)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Upgrade"));
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<CostumeButtonListButton>().setText(Framework_GameManager.costumeDatabase[i]);

            button.transform.SetParent(gameObject.transform, false);

        }
    }
}
