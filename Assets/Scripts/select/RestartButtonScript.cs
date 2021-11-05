using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void click()
    {
        Time.timeScale = 1f;
        switch (currentplay.scene)
        {
            case 1: SceneManager.LoadScene("nwh"); break;
            case 2: SceneManager.LoadScene("shw"); break;
            case 3: SceneManager.LoadScene("hxl"); break;
            case 4: SceneManager.LoadScene("zcx"); break;
            case 5: SceneManager.LoadScene("cy"); break;
            default: SceneManager.LoadScene("ChooseLevel"); break;
        }

    }
}
