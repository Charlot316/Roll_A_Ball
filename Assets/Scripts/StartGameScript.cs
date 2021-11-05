using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click()
    {
        SceneManager.LoadScene("ChooseLevel");
    }
}
