using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnMenuButtonScript : MonoBehaviour
{
    public void Click(){
        SceneManager.LoadScene("Start");
    }
}
