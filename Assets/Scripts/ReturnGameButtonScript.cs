using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGameButtonScript : MonoBehaviour
{
    public GameObject ChooseMenu;
    public void Click(){
        Time.timeScale = 1f;
        ChooseMenu.SetActive(false);
    }
}
