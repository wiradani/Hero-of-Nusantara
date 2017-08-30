using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framework_MasterCamera : MonoBehaviour
{
    public static Framework_MasterCamera instance;

    void Start()
    {
        instance = this;
    }

    public void DeleteCameras()
    {
        foreach (Camera c in GameObject.FindObjectsOfType<Camera>())
        {
            if (c != this)
            {
                Destroy(c.gameObject);
            }
        }

    }
}
