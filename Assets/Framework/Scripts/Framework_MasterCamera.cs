using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Framework_MasterCamera : MonoBehaviour
{
    public static Framework_MasterCamera instance;

    void Start()
    {
        instance = this;
    }

    public void DeleteCameras(string _sceneName)
    {
        GameObject[] goArray = SceneManager.GetSceneByName(_sceneName).GetRootGameObjects(); 

        foreach (GameObject c in goArray)
        {
            if (c.GetComponent<Framework_MasterCamera>() == null && c.GetComponent<Camera>() != null)
            {
                Destroy(c.gameObject);
            }
        }

    }
}
