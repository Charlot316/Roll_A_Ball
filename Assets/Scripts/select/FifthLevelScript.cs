using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FifthLevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("cy");
        Time.timeScale = 1f;
        currentplay.scene = 5;
    }
}
