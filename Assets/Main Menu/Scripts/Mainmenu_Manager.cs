using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu_Manager : MonoBehaviour
{

    public void GoToUpgrade()
    {
        Framework_GameManager.instance.GoToUpgrade();
    }


    public void GoToArena()
    {
        Framework_GameManager.instance.GoToArena();
    }
}
