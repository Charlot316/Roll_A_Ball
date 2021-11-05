using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("nwh");
        Time.timeScale = 1f;
        currentplay.scene = 1;
    }
}
