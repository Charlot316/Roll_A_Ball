using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ChooseMenu;
    public void Click(){
        Time.timeScale = 0;
        ChooseMenu.SetActive(true);
    }
}
