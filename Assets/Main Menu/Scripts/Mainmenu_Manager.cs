using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu_Manager : MonoBehaviour
{
    public GameObject selectLevel;
    public GameObject act1;

    public void GoToUpgrade()
    {
        Framework_GameManager.instance.GoToUpgrade();
    }


    public void GoToArena()
    {
        Framework_GameManager.instance.GoToArena();
    }

    public void GoToDialogue()
    {
        Framework_GameManager.instance.GoToDialogue();
    }

    public void GoToAct1()
    {
        selectLevel.SetActive(false);
        act1.SetActive(true);
    }

	public void GoToCredit(){
		Framework_GameManager.instance.ToCredit ();
	}
}
